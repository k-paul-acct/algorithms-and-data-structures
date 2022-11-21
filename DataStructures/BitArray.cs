namespace DataStructures;

public class BitArray
{
    private const byte BitsPerInt = sizeof(int) * 8;
    private readonly int[] _arr;

    public BitArray(long length)
    {
        var elements = (int)Math.Ceiling((double)length / BitsPerInt);
        _arr = new int[elements];
        Length = length;
    }

    public long Length { get; }

    private static (int ArrIndex, int Offset) GetBitPosition(long index)
    {
        var arrIndex = (int)(index / BitsPerInt);
        var offset = (int)(index % BitsPerInt);
        return (arrIndex, offset);
    }

    public bool GetAt(long index)
    {
        var (arrIndex, offset) = GetBitPosition(index);
        return (_arr[arrIndex] & (1 << offset)) > 0;
    }

    public void SetAtTrue(long index)
    {
        var (arrIndex, offset) = GetBitPosition(index);
        _arr[arrIndex] |= 1 << offset;
    }

    public void SetAtFalse(long index)
    {
        var (arrIndex, offset) = GetBitPosition(index);
        _arr[arrIndex] &= ~(1 << offset);
    }
}