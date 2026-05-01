namespace AdventOfCode._2018.Day05;

internal static class Calculations
{
    private const int CapitalOffset = 'a' - 'A'; // 97 - 65 = 32

    public static int Part1(ReadOnlySpan<char> input) => Collapse(input);

    public static int Part2(ReadOnlySpan<char> input)
    {
        var min = int.MaxValue;

        for (char c = 'A'; c <= 'Z'; c++)
            min = Math.Min(min, Collapse(input, c, char.ToLower(c)));

        return min;
    }

    private static int Collapse(ReadOnlySpan<char> input, params char[] ignore)
    {
        Span<char> temp = stackalloc char[input.Length];

        var l = 0;

        for (var i = 0; i < input.Length; i++)
        {
            if (ignore.Contains(input[i])) continue;

            // Add letter
            temp[l++] = input[i];

            if (l < 2) continue;

            if (!Opposite(temp[l - 1], temp[l - 2])) continue;

            l -= 2;
        }

        return l;
    }

    private static bool Opposite(char a, char b) => Math.Abs(a - b) == CapitalOffset;
}