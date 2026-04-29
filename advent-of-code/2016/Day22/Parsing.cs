namespace advent_of_code._2016.Day22;

internal static partial class Parsing
{
    public static NodeDiskUsage[] ParseNodeDiskUsages(this string input)
    {
        return [.. SplitOn.NewLines(input).Skip(2).Select(NodeDiskUsage.Parse)];
    }
}