using System.Security.Cryptography;
using System.Text;

namespace advent_of_code._2015.Day04;

internal static class Calculations
{
    public static int Perform(string key, int x)
    {
        int n = 1;
        while (true)
        {
            var input = $"{key}{n}";
            var bytes = Encoding.ASCII.GetBytes(input);
            var hash = MD5.HashData(bytes);

            // Check first 5 hex chars == "00000"
            // That means first two and a half bytes are zero:
            // byte0 == 0, byte1 == 0, high nibble of byte2 == 0
            if (Filter3(hash, x))
                return n;

            n++;
        }

    }

    private static bool Filter1(byte[] hash) => hash[0] == 0 && hash[1] == 0 && (hash[2] & 0xF0) == 0;
    private static bool Filter2(byte[] hash) => hash[0] == 0 && hash[1] == 0 && (hash[2] & 0xF0) == 0;
    private static bool Filter3(byte[] hash, int n)
    {
        int i = 0;

        while (n > 0)
        {
            var h = hash[i++];

            if (n == 1)
                return (h & 0xF0) == 0;

            if (h != 0) return false;

            n -= 2;
        }

        return true;
    }
}