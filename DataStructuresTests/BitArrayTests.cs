namespace DataStructuresTests;

public class BitArrayTests
{
    private readonly BitArray _arr;
    private readonly BitArray _arrLen0;

    public BitArrayTests()
    {
        _arr = new BitArray(1024);
        _arrLen0 = new BitArray(0);
    }

    [Fact]
    public void CreateWithInvalidSize()
    {
        var a = -1L;
        var exception = Record.Exception(() => new BitArray((ulong)a));
        Assert.NotNull(exception);

        exception = Record.Exception(() => new BitArray(long.MaxValue));
        Assert.NotNull(exception);
    }

    [Fact]
    public void Length()
    {
        Assert.Equal(_arr.Length, 1024);
        var _ = _arr[2];
        Assert.Equal(_arr.Length, 1024);
        _arr[2] = false;
        Assert.Equal(_arr.Length, 1024);
        _arr[2] = true;
        Assert.Equal(_arr.Length, 1024);

        Assert.Equal(_arrLen0.Length, 0);
    }

    [Fact]
    public void Set()
    {
        Assert.Equal(_arr[10], false);
        Assert.Equal(_arr[11], false);

        Assert.Equal(_arr[32], false);
        Assert.Equal(_arr[32], false);

        _arr[10] = true;
        Assert.Equal(_arr[10], true);
        Assert.Equal(_arr[11], false);

        _arr[32] = true;
        Assert.Equal(_arr[32], true);
        Assert.Equal(_arr[33], false);

        _arr[33] = true;
        Assert.Equal(_arr[32], true);
        Assert.Equal(_arr[33], true);

        _arr[32] = false;
        Assert.Equal(_arr[32], false);
        Assert.Equal(_arr[33], true);

        _arr[33] = false;
        Assert.Equal(_arr[32], false);
        Assert.Equal(_arr[33], false);
    }

    [Fact]
    public void SetInInvalidPosition()
    {
        var exception = Record.Exception(() => _arrLen0[0] = true);
        Assert.NotNull(exception);

        exception = Record.Exception(() => _arrLen0[-2] = true);
        Assert.NotNull(exception);

        exception = Record.Exception(() => _arr[-2] = true);
        Assert.NotNull(exception);

        exception = Record.Exception(() => _arrLen0[long.MaxValue] = true);
        Assert.NotNull(exception);
    }

    [Fact]
    public void Enumerator()
    {
        _arr[2] = true;
        _arr[20] = true;
        var res = _arr.Cast<bool>().Aggregate(false, (current, x) => current ^ x);
        Assert.Equal(res, false);

        _arr[21] = true;
        res = _arr.Cast<bool>().Aggregate(false, (current, x) => current ^ x);
        Assert.Equal(res, true);
    }
}