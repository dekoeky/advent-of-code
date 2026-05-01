namespace AdventOfCode._2022.Day04;

internal readonly record struct RangePair(Range A, Range B)
{
    public static RangePair Parse(ReadOnlySpan<char> input)
    {
        var i = input.IndexOf(',');

        var a = Range.Parse(input[..i]);
        var b = Range.Parse(input[(i + 1)..]);

        return new RangePair(a, b);
    }

    public readonly bool OneRangeFullyContainsTheOther()
        => A.FullyContains(B) || B.FullyContains(A);

    public readonly bool OneRangeOverlapsTheOther()
        => A.Overlaps(B);
}
