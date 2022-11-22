using System.Runtime.CompilerServices;

namespace NonCrypto;

public static class Hash
{
    public static uint MurmurHash3_X86_32(byte[] buffer, int seed)
    {
        static uint Scramble(uint x)
        {
            x *= 0xcc9e2d51;
            x = (x << 15) | (x >> 17);
            x *= 0x1b873593;
            return x;
        }

        var hash = (uint)seed;

        // Read in groups of 4.
        var i = 0;
        for (; i + 3 < buffer.Length; i += 4)
        {
            var k = Unsafe.As<byte, uint>(ref buffer[i]);
            hash ^= Scramble(k);
            hash = (hash << 13) | (hash >> 19);
            hash = hash * 5 + 0xe6546b64;
        }

        // Read the rest.
        uint rest = 0;
        switch (buffer.Length & 3)
        {
            case 3:
                rest |= (uint)buffer[i + 2] << 16;
                goto case 2;
            case 2:
                rest |= (uint)buffer[i + 1] << 8;
                goto case 1;
            case 1:
                rest |= buffer[i];
                hash ^= Scramble(rest);
                break;
        }

        // Finalize.
        hash ^= (uint)buffer.Length;
        hash ^= hash >> 16;
        hash *= 0x85ebca6b;
        hash ^= hash >> 13;
        hash *= 0xc2b2ae35;
        hash ^= hash >> 16;
        return hash;
    }

    public static byte[] MurmurHash3_X86_128(byte[] buffer, int seed)
    {
        uint Rot32(uint x, byte r)
        {
            return (x << r) | (x >> (32 - r));
        }

        uint Mix32(uint x)
        {
            x ^= x >> 16;
            x *= 0x85ebca6b;
            x ^= x >> 13;
            x *= 0xc2b2ae35;
            x ^= x >> 16;
            return x;
        }

        var h1 = (uint)seed;
        var h2 = h1;
        var h3 = h1;
        var h4 = h1;

        // Read in groups of 16.
        var i = 0;
        while (i + 15 < buffer.Length)
        {
            var k1 = Unsafe.As<byte, uint>(ref buffer[i]);
            i += 4;
            var k2 = Unsafe.As<byte, uint>(ref buffer[i]);
            i += 4;
            var k3 = Unsafe.As<byte, uint>(ref buffer[i]);
            i += 4;
            var k4 = Unsafe.As<byte, uint>(ref buffer[i]);
            i += 4;

            k1 *= 0x239b961b;
            k1 = Rot32(k1, 15);
            k1 *= 0xab0e9789;
            h1 ^= k1;

            h1 = Rot32(h1, 19);
            h1 += h2;
            h1 = h1 * 5 + 0x561ccd1b;

            k2 *= 0xab0e9789;
            k2 = Rot32(k2, 16);
            k2 *= 0x38b34ae5;
            h2 ^= k2;

            h2 = Rot32(h2, 17);
            h2 += h3;
            h2 = h2 * 5 + 0x0bcaa747;

            k3 *= 0x38b34ae5;
            k3 = Rot32(k3, 17);
            k3 *= 0xa1e38b93;
            h3 ^= k3;

            h3 = Rot32(h3, 15);
            h3 += h4;
            h3 = h3 * 5 + 0x96cd1c35;

            k4 *= 0xa1e38b93;
            k4 = Rot32(k4, 18);
            k4 *= 0x239b961b;
            h4 ^= k4;

            h4 = Rot32(h4, 13);
            h4 += h1;
            h4 = h4 * 5 + 0x32ac3b17;
        }

        // Read the rest.
        uint r1 = 0;
        uint r2 = 0;
        uint r3 = 0;
        uint r4 = 0;
        var index = buffer.Length - 1;
        switch (buffer.Length & 15)
        {
            case 15:
                r4 |= (uint)buffer[index--] << 16;
                goto case 14;
            case 14:
                r4 |= (uint)buffer[index--] << 8;
                goto case 13;
            case 13:
                r4 |= buffer[index--];
                r4 *= 0xa1e38b93;
                r4 = Rot32(r4, 18);
                r4 *= 0x239b961b;
                h4 ^= r4;
                goto case 12;
            case 12:
                r3 |= (uint)buffer[index--] << 24;
                goto case 11;
            case 11:
                r3 |= (uint)buffer[index--] << 16;
                goto case 10;
            case 10:
                r3 |= (uint)buffer[index--] << 8;
                goto case 9;
            case 9:
                r3 |= buffer[index--];
                r3 *= 0x38b34ae5;
                r3 = Rot32(r3, 17);
                r3 *= 0xa1e38b93;
                h3 ^= r3;
                goto case 8;
            case 8:
                r2 |= (uint)buffer[index--] << 24;
                goto case 7;
            case 7:
                r2 |= (uint)buffer[index--] << 16;
                goto case 6;
            case 6:
                r2 |= (uint)buffer[index--] << 8;
                goto case 5;
            case 5:
                r2 |= buffer[index--];
                r2 *= 0xab0e9789;
                r2 = Rot32(r2, 16);
                r2 *= 0x38b34ae5;
                h2 ^= r2;
                goto case 4;
            case 4:
                r1 |= (uint)buffer[index--] << 24;
                goto case 3;
            case 3:
                r1 |= (uint)buffer[index--] << 16;
                goto case 2;
            case 2:
                r1 |= (uint)buffer[index--] << 8;
                goto case 1;
            case 1:
                r1 |= buffer[index];
                r1 *= 0x239b961b;
                r1 = Rot32(r1, 15);
                r1 *= 0xab0e9789;
                h1 ^= r1;
                break;
        }

        // Finalize.
        h1 ^= (uint)buffer.Length;
        h2 ^= (uint)buffer.Length;
        h3 ^= (uint)buffer.Length;
        h4 ^= (uint)buffer.Length;

        h1 += h2;
        h1 += h3;
        h1 += h4;
        h2 += h1;
        h3 += h1;
        h4 += h1;

        h1 = Mix32(h1);
        h2 = Mix32(h2);
        h3 = Mix32(h3);
        h4 = Mix32(h4);

        h1 += h2;
        h1 += h3;
        h1 += h4;
        h2 += h1;
        h3 += h1;
        h4 += h1;

        // Make result array.
        var res = new byte[16];
        Unsafe.WriteUnaligned(ref res[0], h1);
        Unsafe.WriteUnaligned(ref res[4], h2);
        Unsafe.WriteUnaligned(ref res[8], h3);
        Unsafe.WriteUnaligned(ref res[12], h4);
        return res;
    }

    public static byte[] MurmurHash3_X64_128(byte[] buffer, int seed)
    {
        static ulong Mix64(ulong x)
        {
            x ^= x >> 33;
            x *= 0xff51afd7ed558ccd;
            x ^= x >> 33;
            x *= 0xc4ceb9fe1a85ec53;
            x ^= x >> 33;
            return x;
        }

        static ulong Rot64(ulong x, byte r)
        {
            return (x << r) | (x >> (64 - r));
        }

        var h1 = (ulong)seed;
        var h2 = h1;

        // Read in groups of 16.
        var i = 0;
        while (i + 15 < buffer.Length)
        {
            var k1 = Unsafe.As<byte, ulong>(ref buffer[i]);
            i += 8;
            var k2 = Unsafe.As<byte, ulong>(ref buffer[i]);
            i += 8;

            k1 *= 0x87c37b91114253d5;
            k1 = Rot64(k1, 31);
            k1 *= 0x4cf5ad432745937f;
            h1 ^= k1;

            h1 = Rot64(h1, 27);
            h1 += h2;
            h1 = h1 * 5 + 0x52dce729;

            k2 *= 0x4cf5ad432745937f;
            k2 = Rot64(k2, 33);
            k2 *= 0x87c37b91114253d5;
            h2 ^= k2;

            h2 = Rot64(h2, 31);
            h2 += h1;
            h2 = h2 * 5 + 0x38495ab5;
        }

        // Read the rest.
        ulong r1 = 0;
        ulong r2 = 0;
        var index = buffer.Length - 1;
        switch (buffer.Length & 15)
        {
            case 15:
                r2 |= (ulong)buffer[index--] << 48;
                goto case 14;
            case 14:
                r2 |= (ulong)buffer[index--] << 40;
                goto case 13;
            case 13:
                r2 |= (ulong)buffer[index--] << 32;
                goto case 12;
            case 12:
                r2 |= (ulong)buffer[index--] << 24;
                goto case 11;
            case 11:
                r2 |= (ulong)buffer[index--] << 16;
                goto case 10;
            case 10:
                r2 |= (ulong)buffer[index--] << 8;
                goto case 9;
            case 9:
                r2 |= (ulong)buffer[index--] << 0;
                r2 *= 0x4cf5ad432745937f;
                r2 = Rot64(r2, 33);
                r2 *= 0x87c37b91114253d5;
                h2 ^= r2;
                goto case 8;
            case 8:
                r1 |= (ulong)buffer[index--] << 56;
                goto case 7;
            case 7:
                r1 |= (ulong)buffer[index--] << 48;
                goto case 6;
            case 6:
                r1 |= (ulong)buffer[index--] << 40;
                goto case 5;
            case 5:
                r1 |= (ulong)buffer[index--] << 32;
                goto case 4;
            case 4:
                r1 |= (ulong)buffer[index--] << 24;
                goto case 3;
            case 3:
                r1 |= (ulong)buffer[index--] << 16;
                goto case 2;
            case 2:
                r1 |= (ulong)buffer[index--] << 8;
                goto case 1;
            case 1:
                r1 |= buffer[index];
                r1 *= 0x87c37b91114253d5;
                r1 = Rot64(r1, 31);
                r1 *= 0x4cf5ad432745937f;
                h1 ^= r1;
                break;
        }

        // Finalize.
        h1 ^= (ulong)buffer.Length;
        h2 ^= (ulong)buffer.Length;

        h1 += h2;
        h2 += h1;

        h1 = Mix64(h1);
        h2 = Mix64(h2);

        h1 += h2;
        h2 += h1;

        // Make result array.
        var res = new byte[16];
        Unsafe.WriteUnaligned(ref res[0], h1);
        Unsafe.WriteUnaligned(ref res[8], h2);
        return res;
    }

    public static uint Fnv1_32(byte[] buffer)
    {
        var hash = 0x811c9dc5;
        foreach (var b in buffer)
        {
            hash *= 0x01000193;
            hash ^= b;
        }

        return hash;
    }

    public static ulong Fnv1_64(byte[] buffer)
    {
        var hash = 0xcbf29ce484222325;
        foreach (var b in buffer)
        {
            hash *= 0x00000100000001b3;
            hash ^= b;
        }

        return hash;
    }

    public static uint Fnv1a_32(byte[] buffer)
    {
        var hash = 0x811c9dc5;
        foreach (var b in buffer)
        {
            hash ^= b;
            hash *= 0x01000193;
        }

        return hash;
    }

    public static ulong Fnv1a_64(byte[] buffer)
    {
        var hash = 0xcbf29ce484222325;
        foreach (var b in buffer)
        {
            hash ^= b;
            hash *= 0x00000100000001b3;
        }

        return hash;
    }
}