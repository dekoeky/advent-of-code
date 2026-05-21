namespace advent_of_code._2018.Day23;

public readonly record struct Position(int X, int Y, int Z)
{
    public static Position Parse(ReadOnlySpan<char> input)
    {
        Span<Range> r = stackalloc Range[4];

        if (3 != input.SplitAny(r, ['<', ',', '>'], StringSplitOptions.RemoveEmptyEntries))
            throw new InvalidOperationException("Error extracting x, y, z");

        var x = int.Parse(input[r[0]]);
        var y = int.Parse(input[r[1]]);
        var z = int.Parse(input[r[2]]);

        return new Position(x, y, z);
    }

    public static int ManhattanDistance(Position a, Position b)
        => Math.Abs(a.X - b.X)
        + Math.Abs(a.Y - b.Y)
        + Math.Abs(a.Z - b.Z);
}
