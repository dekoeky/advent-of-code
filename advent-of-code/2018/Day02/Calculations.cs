using advent_of_code.Helpers;

namespace advent_of_code._2018.Day02;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var two = 0;
        var three = 0;

        foreach (var line in input.EnumerateLines())
        {
            var (hasTwo, hasThree) = Analyze(line);
            if (hasTwo) two++;
            if (hasThree) three++;
        }

        return two * three;
    }

    public static (bool ContainsTwos, bool ContainsThrees) Analyze(ReadOnlySpan<char> input)
    {
        Span<int> counts = stackalloc int[26];

        foreach (var c in input)
            counts[c - 'a']++;

        return (counts.Contains(2), counts.Contains(3));
    }

    public static string Part2(string input)
    {
        var lines = SplitOn.NewLines(input);

        var best = int.MinValue;
        var minIndices = (I: -1, J: -1);

        for (var i = 0; i < lines.Length - 1; i++)
            for (var j = i + 1; j < lines.Length; j++)
            {
                var common = CountCommonLetters(lines[i], lines[j]);

                if (common > best)
                {
                    best = common;
                    minIndices = (i, j);
                }
            }

        return GetCommonLetters(lines[minIndices.I], lines[minIndices.J]);
    }

    private static int CountCommonLetters(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
    {
        var common = 0;

        for (var i = 0; i < a.Length; i++)
            if (a[i] == b[i])
                common++;

        return common;
    }

    private static string GetCommonLetters(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
    {
        Span<char> result = stackalloc char[a.Length];
        var l = 0;

        for (var i = 0; i < a.Length; i++)
            if (a[i] == b[i])
                result[l++] = a[i];

        return new string(result[..l]);
    }
}