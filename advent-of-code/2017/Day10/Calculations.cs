using System.Text;

namespace AdventOfCode._2017.Day10;

internal static class Calculations
{
    private const int DefaultN = 256;

    public static int Part1(string input, int n = DefaultN)
    {
        byte[] elements = [.. Enumerable.Range(0, n).Select(i => (byte)i)];
        var lengths = ParsePart1(input);

        Knot(elements, lengths);

        return elements[0] * elements[1];
    }

    private static void Knot(byte[] elements, byte[] lengths, int rounds = 1)
    {
        var currentPosition = 0;
        var skipSize = 0;

        for (var round = 0; round < rounds; round++)
            foreach (var l in lengths)
            {
                if (l > elements.Length)
                    throw new InvalidOperationException("Not sure how to do this");

                // Reverse the order of that length of elements in the list, starting with the element at the current position.
                Reverse(elements, currentPosition, l);

                // Move the current position forward by that length plus the skip size.
                currentPosition = (currentPosition + l + skipSize) % elements.Length;

                // Increase the skip size by one.
                skipSize++;
            }
    }

    private static void Reverse<T>(T[] elements, int start, int length) where T : struct
    {
        for (var i = 0; i < length / 2; i++)
        {
            var a = (start + i) % elements.Length;
            var b = (start + length - i - 1) % elements.Length;
            (elements[a], elements[b]) = (elements[b], elements[a]);
        }
    }

    public static string Part2(string input, int n = DefaultN)
    {
        var denseHash = DenseHash(input, n);

        return Convert.ToHexStringLower(denseHash);
    }

    public static byte[] DenseHash(string input, int n = DefaultN)
    {
        byte[] elements = [.. Enumerable.Range(0, n).Select(i => (byte)i)];
        var lengths = ParsePart2(input);

        Knot(elements, lengths, 64);

        return ToDenseHash(elements);
    }

    private static byte[] ToDenseHash(byte[] sparseHash)
    {
        if (sparseHash.Length != 16 * 16) throw new InvalidOperationException();

        var result = new byte[16];

        for (var i = 0; i < 16; i++)
            result[i] = Xor(sparseHash.AsSpan(i * 16, 16));

        return result;
    }

    private static byte Xor(ReadOnlySpan<byte> bytes)
    {
        int value = bytes[0];

        for (var i = 1; i < bytes.Length; i++)
            value ^= bytes[i];

        return (byte)value;
    }

    public static byte[] ParsePart1(this string input) => [.. input.Split(',', StringSplitOptions.TrimEntries).Select(byte.Parse)];

    private static readonly byte[] AppendedBytes = [17, 31, 73, 47, 23];
    public static byte[] ParsePart2(this string input) => [.. Encoding.ASCII.GetBytes(input), .. AppendedBytes];
}
