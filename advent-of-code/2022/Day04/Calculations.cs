namespace advent_of_code._2022.Day04;

internal static class Calculations
{
    public static int Part1(string input)
        => RangePairs.Parse(input)
        .Pairs
        .Count(p => p.OneRangeFullyContainsTheOther());

    public static int Part2(string input)
        => RangePairs.Parse(input)
        .Pairs
        .Count(p => p.OneRangeOverlapsTheOther());
}
