namespace advent_of_code._2020.Day03;

internal static class Calculations
{
    public static long Part1(ReadOnlySpan<char> input)
        => TreesFound(input.To2DArray(), (3, 1));


    private static long TreesFound(char[,] map, (int X, int Y) slope)
    {
        var (x, y) = (0, 0);
        var (h, w) = (map.GetLength(0), map.GetLength(1));
        var trees = 0;

        while (y < h)
        {
            x += slope.X;
            y += slope.Y;

            if (x >= w) x %= w;
            if (y >= h) break;

            if (map[y, x] == '#') trees++;
        }

        return trees;
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        (int X, int Y)[] slopes = [
            (1, 1),
            (3, 1),
            (5, 1),
            (7, 1),
            (1, 2),
            ];

        var map = input.To2DArray();
        var trees = slopes.Select(slope => TreesFound(map, slope));

        return trees.Product();
    }
}