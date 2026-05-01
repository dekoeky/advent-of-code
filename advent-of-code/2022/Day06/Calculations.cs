namespace AdventOfCode._2022.Day06;

internal static class Calculations
{
    private const int InvalidResult = int.MaxValue;

    public static int Part1(ReadOnlySpan<char> input) => FindNDistinctCharacters(input, 4);

    public static int Part2(ReadOnlySpan<char> input) => FindNDistinctCharacters(input, 14);

    private static int FindNDistinctCharacters(ReadOnlySpan<char> input, int n)
    {
        // Declare a hashset (with just enough space) to check for duplicates
        // Declare here to prevent the HasDuplicates to create it each call
        var hs = new HashSet<char>(n);

        for (var i = 0; i <= input.Length - n; i++)
            if (!HasDuplicates(input.Slice(i, n), hs))
                return i + n;

        return InvalidResult;
    }

    private static bool HasDuplicates(ReadOnlySpan<char> part, HashSet<char> hs)
    {
        for (var i = 0; i < part.Length; i++)
            if (!hs.Add(part[i]))
            {
                hs.Clear();
                return true; // Duplicates!
            }

        hs.Clear();
        return false; // No Duplicates
    }
}