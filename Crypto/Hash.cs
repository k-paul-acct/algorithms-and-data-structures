using System.Text;

namespace Crypto;

public static class Hash
{
    public static uint Murmur3_32(string key, int seed)
    {
        static uint Scramble(uint k)
        {
            k *= 0xcc9e2d51;
            k = (k << 15) | (k >> 17);
            k *= 0x1b873593;
            return k;
        }

        var buff = Encoding.Unicode.GetBytes(key);
        var hash = (uint)seed;

        // Read in groups of 4.
        var i = 0;
        for (; i + 3 < buff.Length;)
        {
            var k = (uint)(buff[i++] | (buff[i++] << 8) | (buff[i++] << 16) | (buff[i++] << 24));
            hash ^= Scramble(k);
            hash = (hash << 13) | (hash >> 19);
            hash = hash * 5 + 0xe6546b64;
        }

        // Read the rest.
        uint rest = (buff.Length & 3) switch
        {
            3 => (uint)((buff[i++] << 16) | (buff[i++] << 8) | buff[i]),
            2 => (uint)((buff[i++] << 8) | buff[i]),
            1 => buff[i],
            _ => 0
        };

        hash ^= Scramble(rest);

        // Finalize.
        hash ^= (uint)buff.Length;
        hash ^= hash >> 16;
        hash *= 0x85ebca6b;
        hash ^= hash >> 13;
        hash *= 0xc2b2ae35;
        hash ^= hash >> 16;

        return hash;
    }

    public static uint Fnv1_32(string key)
    {
        var buff = Encoding.Unicode.GetBytes(key);
        var hash = 0x811c9dc5;
        foreach (var b in buff)
        {
            hash *= 0x01000193;
            hash ^= b;
        }

        return hash;
    }

    public static uint Fnv1a_32(string key)
    {
        var buff = Encoding.Unicode.GetBytes(key);
        var hash = 0x811c9dc5;
        foreach (var b in buff)
        {
            hash ^= b;
            hash *= 0x01000193;
        }

        return hash;
    }
}