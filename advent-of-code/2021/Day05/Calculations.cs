namespace advent_of_code._2021.Day05;

internal static class Calculations
{
    public static int Part1(string input) => CountOverlappingPositions(input, true);

    public static int Part2(string input) => CountOverlappingPositions(input, false);

    private static int CountOverlappingPositions(string input, bool ignoreDiagonal)
    {
        var lines = Line.ParseMany(input);
        Dictionary<Point, int> counts = [];

        foreach (var line in lines)
        {
            if (ignoreDiagonal && line.A.X != line.B.X && line.A.Y != line.B.Y)
                continue;

            foreach (var point in line.EnumeratePoints())
                counts[point] = counts.GetValueOrDefault(point, 0) + 1;
        }

        return counts.Count(kv => kv.Value >= 2);
    }
}