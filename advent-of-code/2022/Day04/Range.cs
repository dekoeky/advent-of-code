namespace advent_of_code._2022.Day04;

internal readonly record struct Range(int RangeStart, int RangeEnd)
{
    public static Range Parse(ReadOnlySpan<char> input)
    {
        var i = input.IndexOf('-');

        var start = int.Parse(input[..i]);
        var end = int.Parse(input[(i + 1)..]);

        return new Range(start, end);
    }

    public readonly bool FullyContains(Range other)
        => RangeStart <= other.RangeStart && RangeEnd >= other.RangeEnd;

    public readonly bool Overlaps(Range other)
        => RangeStart <= other.RangeEnd
        && other.RangeStart <= RangeEnd;
}
