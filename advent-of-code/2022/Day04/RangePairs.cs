namespace AdventOfCode._2022.Day04;

internal readonly record struct RangePairs(RangePair[] Pairs)
{
    public static RangePairs Parse(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var pairs = new RangePair[n];
        var i = 0;

        foreach (var line in input.EnumerateLines())
            pairs[i++] = RangePair.Parse(line);

        return new RangePairs(pairs);
    }
}