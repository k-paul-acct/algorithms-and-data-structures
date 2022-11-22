using System.Text;
using NonCrypto;

namespace DataStructures;

public class BloomFilter
{
    private readonly BitArray _bitArray;
    private readonly Func<uint, uint, long>[] _hashFunctions;
    private readonly int _maxSize;
    private readonly int _seed;
    private const double Ln2 = 0.693147180559945309417232;

    public BloomFilter(int maxSize) : this(maxSize, Random.Shared.Next())
    {
    }

    public BloomFilter(int maxSize, double maxError) : this(maxSize, Random.Shared.Next(), maxError)
    {
    }

    public BloomFilter(int maxSize, int seed, double maxError = 0.01)
    {
        static IEnumerable<Func<uint, uint, long>> InitHashFunctions(int hashFunctionsNum, long bitsNum)
        {
            return Enumerable
                .Range(0, hashFunctionsNum)
                .Select<int, Func<uint, uint, long>>(i => (h1, h2) => (h1 + i * h2 + i * i) % bitsNum);
        }

        _maxSize = maxSize;
        _seed = seed;
        var bitsNum = (long)Math.Ceiling(-maxSize * Math.Log(maxError) / Ln2 / Ln2);
        var hashFunctionsNum = (int)Math.Ceiling(Ln2 * bitsNum / maxSize);
        _bitArray = new BitArray(bitsNum);
        _hashFunctions = InitHashFunctions(hashFunctionsNum, _bitArray.Length).ToArray();
    }

    public int Count { get; private set; }
    public bool Full => Count >= _maxSize;

    private IEnumerable<long> GetIndicesByKey(string key)
    {
        var bytes = Encoding.Default.GetBytes(key);
        var h1 = Hash.MurmurHash3_X86_32(bytes, _seed);
        var h2 = Hash.Fnv1_32(bytes);
        return _hashFunctions.Select(x => x(h1, h2));
    }

    public bool Contains(string key)
    {
        return GetIndicesByKey(key).All(i => _bitArray.GetAt(i));
    }

    public void Insert(string key)
    {
        var indices = GetIndicesByKey(key).ToArray();
        if (indices.All(i => _bitArray.GetAt(i))) return;
        foreach (var index in indices) _bitArray.SetAtTrue(index);
        Count += 1;
    }
}