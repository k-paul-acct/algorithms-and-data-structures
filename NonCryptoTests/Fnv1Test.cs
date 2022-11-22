using System.Text;

namespace NonCryptoTests;

public class Fnv1Test
{
    private static readonly byte[] Sample1 = Encoding.ASCII.GetBytes("");
    private static readonly byte[] Sample2 = Encoding.ASCII.GetBytes("a");
    private static readonly byte[] Sample3 = Encoding.ASCII.GetBytes("foobar");

    [Fact]
    public void Fnv1_32()
    {
        Assert.Equal(Hash.Fnv1_32(Sample1), 0x811c9dc5);
        Assert.Equal<uint>(Hash.Fnv1_32(Sample2), 0x050c5d7e);
        Assert.Equal<uint>(Hash.Fnv1_32(Sample3), 0x31f0b262);
    }

    [Fact]
    public void Fnv1_64()
    {
        Assert.Equal(Hash.Fnv1_64(Sample1), 0xcbf29ce484222325);
        Assert.Equal(Hash.Fnv1_64(Sample2), 0xaf63bd4c8601b7be);
        Assert.Equal<ulong>(Hash.Fnv1_64(Sample3), 0x340d8765a4dda9c2);
    }

    [Fact]
    public void Fnv1a_32()
    {
        Assert.Equal(Hash.Fnv1a_32(Sample1), 0x811c9dc5);
        Assert.Equal(Hash.Fnv1a_32(Sample2), 0xe40c292c);
        Assert.Equal(Hash.Fnv1a_32(Sample3), 0xbf9cf968);
    }

    [Fact]
    public void Fnv1a_64()
    {
        Assert.Equal(Hash.Fnv1a_64(Sample1), 0xcbf29ce484222325);
        Assert.Equal(Hash.Fnv1a_64(Sample2), 0xaf63dc4c8601ec8c);
        Assert.Equal(Hash.Fnv1a_64(Sample3), 0x85944171f73967e8);
    }
}