using Crypto;

namespace DataStructures;

public class BloomFilter
{
    private readonly BitArray _bitArray;
    private readonly Func<uint, uint, long>[] _hashFunctions;
    private readonly int _maxSize;
    private readonly int _seed;

    public BloomFilter(int maxSize) : this(maxSize, Random.Shared.Next())
    {
    }

    public BloomFilter(int maxSize, double maxError) : this(maxSize, Random.Shared.Next(), maxError)
    {
    }

    public BloomFilter(int maxSize, int seed, double maxError = 0.1)
    {
        static IEnumerable<Func<uint, uint, long>> InitHashFunctions(int hashFunctionsNum, long bitsNum)
        {
            return Enumerable
                .Range(0, hashFunctionsNum)
                .Select<int, Func<uint, uint, long>>(i => (h1, h2) => (h1 + i * h2 + i * i) % bitsNum);
        }

        _maxSize = maxSize;
        _seed = seed;
        var bitsNum = (long)Math.Ceiling(-maxSize * Math.Log(maxError) / Math.Log(2) / Math.Log(2));
        var hashFunctionsNum = (int)Math.Ceiling(-Math.Log(maxError) / Math.Log(2));
        _bitArray = new BitArray(bitsNum);
        _hashFunctions = InitHashFunctions(hashFunctionsNum, _bitArray.Length).ToArray();
    }

    public int Count { get; private set; }
    public bool Full => Count >= _maxSize;

    private IEnumerable<long> GetIndicesByKey(string key)
    {
        var h1 = Hash.Murmur3_32(key, _seed);
        var h2 = Hash.Fnv1_32(key);
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