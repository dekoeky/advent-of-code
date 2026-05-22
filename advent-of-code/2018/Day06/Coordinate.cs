namespace advent_of_code._2018.Day06;

internal readonly record struct Coordinate(int X, int Y)
{
    public static Coordinate Parse(ReadOnlySpan<char> input)
    {
        Span<Range> ranges = stackalloc Range[2];

        if (input.Split(ranges, ',', StringSplitOptions.TrimEntries) != 2)
            throw new InvalidOperationException();

        return new Coordinate(
            int.Parse(input[ranges[0]]),
            int.Parse(input[ranges[1]])
            );
    }

    public static Coordinate[] ParseMany(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var result = new Coordinate[n];
        var i = 0;
        var lines = input.EnumerateLines();

        foreach (var line in lines)
            result[i++] = Parse(line);

        return result;
    }

    public readonly int ManhattanDistance(int x, int y) => ManhattanDistance(X, Y, x, y);
    public readonly int ManhattanDistance(Coordinate other)
        => ManhattanDistance(this, other);
    public static int ManhattanDistance(Coordinate a, Coordinate b)
        => ManhattanDistance(a.X, a.Y, b.X, b.Y);

    private static int ManhattanDistance(int x1, int y1, int x2, int y2)
        => Math.Abs(y2 - y1) + Math.Abs(x2 - x1);

    public static ((int X, int Y) Min, (int X, int Y) Max) BoundingBox(IEnumerable<Coordinate> coordinates)
    {
        var minX = int.MaxValue;
        var minY = int.MaxValue;
        var maxX = int.MinValue;
        var maxY = int.MinValue;

        foreach (var c in coordinates)
        {
            if (c.X < minX) minX = c.X;
            if (c.X > maxX) maxX = c.X;
            if (c.Y < minY) minY = c.Y;
            if (c.Y > maxY) maxY = c.Y;
        }

        return ((minX, minY), (maxX, maxY));
    }
}