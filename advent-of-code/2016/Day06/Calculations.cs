using System.Security.Cryptography;
using System.Text;

namespace advent_of_code._2016.Day06;

internal static class Calculations
{

    public static string ErrorCorrect1(ReadOnlySpan<char> input)
    {
        var counts = new Dictionary<int, Dictionary<char, int>>();

        foreach (var line in input.EnumerateLines())
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (!counts.TryGetValue(i, out var countsForThisIndex))
                {
                    countsForThisIndex = new Dictionary<char, int>();
                    counts.Add(i, countsForThisIndex);
                }

                var character = line[i];

                if (countsForThisIndex.TryGetValue(character, out int value))
                    countsForThisIndex[character] = ++value;
                else
                    countsForThisIndex.Add(character, 1);
            }
        }

        var resultingChars = counts.Select(c => c.Value.MaxBy(cc => cc.Value).Key).ToArray();
        return new string(resultingChars);
    }
    
    public static string ErrorCorrect2(ReadOnlySpan<char> input)
    {
        var counts = new Dictionary<int, Dictionary<char, int>>();

        foreach (var line in input.EnumerateLines())
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (!counts.TryGetValue(i, out var countsForThisIndex))
                {
                    countsForThisIndex = new Dictionary<char, int>();
                    counts.Add(i, countsForThisIndex);
                }

                var character = line[i];

                if (countsForThisIndex.TryGetValue(character, out int value))
                    countsForThisIndex[character] = ++value;
                else
                    countsForThisIndex.Add(character, 1);
            }
        }

        var resultingChars = counts.Select(c => c.Value.MinBy(cc => cc.Value).Key).ToArray();
        return new string(resultingChars);
    }
}