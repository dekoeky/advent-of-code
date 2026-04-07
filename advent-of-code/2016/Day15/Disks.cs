using advent_of_code.Helpers;

namespace advent_of_code._2016.Day15;

internal static class Disks
{
    public static List<DiskInput> Parse(string input)
        => [.. SplitOn.NewLines(input).Select(DiskInput.Parse)];
}
