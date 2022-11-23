using System.Collections;
using System.Runtime.CompilerServices;

namespace DataStructures;

public sealed class BitArray : ICollection
{
    private readonly uint[] _arr;

    public BitArray(ulong length)
    {
        if (length > (ulong)Array.MaxLength << 5) throw new ApplicationException(nameof(length));

        var elements = (int)((length + 31) >> 5);
        _arr = new uint[elements];
        Length = (long)length;
    }

    public bool this[long index]
    {
        get => Get(index);
        set => Set(index, value);
    }

    public long Length { get; }

    public IEnumerator GetEnumerator()
    {
        return new BitArrayEnumerator(this);
    }

    public void CopyTo(Array array, int index)
    {
    }

    public int Count => (int)Length;
    public bool IsSynchronized => false;
    public object SyncRoot => this;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool Get(long index)
    {
        return (_arr[index >> 5] & (1U << (int)index)) != 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Set(long index, bool value)
    {
        ref var val = ref _arr[index >> 5];
        if (value) val |= 1U << (int)index;
        else val &= ~(1U << (int)index);
    }

    private sealed class BitArrayEnumerator : IEnumerator
    {
        private readonly BitArray _arr;
        private bool _curr;
        private long _index;

        public BitArrayEnumerator(BitArray arr)
        {
            _arr = arr;
            _index = -1;
            _curr = false;
        }

        public bool MoveNext()
        {
            if (_index < _arr.Length - 1)
            {
                _index++;
                _curr = _arr.Get(_index);
                return true;
            }

            _index = _arr.Length;
            return false;
        }

        public void Reset()
        {
            _index = -1;
        }

        public object Current
        {
            get
            {
                if (_index == -1 || _index >= _arr.Length) throw new InvalidOperationException();
                return _curr;
            }
        }
    }
}