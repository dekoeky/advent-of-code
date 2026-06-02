namespace advent_of_code._2020.Day18;

internal static partial class Calculations
{
    public static long Part1(ReadOnlySpan<char> input)
    {
        var sum = 0L;

        foreach (var line in input.EnumerateLines())
            sum += new ParserV1(line).ParseExpression();

        return sum;
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        var sum = 0L;

        foreach (var line in input.EnumerateLines())
            sum += new ParserV2(line).ParseExpression();

        return sum;
    }
}
