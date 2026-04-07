using System.Security.Cryptography;
using System.Text;

namespace advent_of_code._2016.Day14;

internal static class Calculations
{
    public static int Part1(string salt, int n)
    {
        int index = -1;
        var hashes = new Dictionary<int, string>();

        while (n > 0)
        {
            index++;

            // Calculate the hash for this index
            var hash = hashes.GetOrCalculateAndInsert(index, () => CalculateHash(salt, index));

            for (var i = 0; i <= hash.Length - 3; i++)
            {
                if (hash[i] != hash[i + 1]) continue;
                if (hash[i] != hash[i + 2]) continue;
                var quintuple = new string(hash[i], 5);

                for (int index2 = (index + 1); index2 <= (index + 1000); index2++)
                {
                    var hash2 = hashes.GetOrCalculateAndInsert(index2, () => CalculateHash(salt, index2));

                    //if (HasQuintuple(hash2, hash[i]))
                    if (hash2.Contains(quintuple))
                    {
                        Debug.WriteLine($"[{n,3}] Index {index,10}, hash {hash}, hash2 {hash2}, quintuple {quintuple}");

                        // Instead of checking ++valid >= n, we just check --n > 0
                        n--;

                        // Break inner loop
                        break;
                    }
                }

                // only check the first quintuple
                break;
            }
        }

        return index;
    }

    static bool HasQuintuple(string hash, char c)
    {
        int count = 0;

        foreach (var ch in hash)
        {
            if (ch == c)
            {
                count++;
                if (count == 5) return true;
            }
            else
            {
                count = 0;
            }
        }

        return false;
    }

    static string CalculateHash(string salt, int index)
    {
        var bytes = Encoding.ASCII.GetBytes($"{salt}{index}");
        var hash = MD5.HashData(bytes);
        return Convert.ToHexString(hash).ToLowerInvariant();
    }

    public static int Part2(int fav, int maxSteps)
    {
        throw new NotImplementedException();
    }
}
