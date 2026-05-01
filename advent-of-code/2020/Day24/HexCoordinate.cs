namespace AdventOfCode._2020.Day24;

internal readonly record struct HexCoordinate(int X, int Y, int Z)
{
    public readonly IEnumerable<HexCoordinate> EnumerateNeighbors()
    {
        foreach (var direction in Enum.GetValues<HexDirection>())
            yield return Move(direction);
    }

    public static readonly HexCoordinate Zero = new(0, 0, 0);

    public HexCoordinate Move(HexDirection direction) => direction switch
    {
        HexDirection.East => this with { X = X + 1, Y = Y - 1 },
        HexDirection.SouthEast => this with { Y = Y - 1, Z = Z + 1 },
        HexDirection.SouthWest => this with { X = X - 1, Z = Z + 1 },
        HexDirection.West => this with { X = X - 1, Y = Y + 1 },
        HexDirection.NorthWest => this with { Y = Y + 1, Z = Z - 1 },
        HexDirection.NorthEast => this with { X = X + 1, Z = Z - 1 },
        _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
    };
}
