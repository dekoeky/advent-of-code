namespace advent_of_code._2019.Day05;

internal static class IntCodeProgram
{
    public static int[] Parse(ReadOnlySpan<char> input)
    {
        var n = input.Count(',') + 1;
        Span<Range> r = n <= 100 ? stackalloc Range[n] : new Range[n];
        int[] result = new int[n];

        input.Split(r, ',');

        for (var i = 0; i < n; i++)
            result[i] = int.Parse(input[r[i]]);

        return result;
    }
}