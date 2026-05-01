namespace AdventOfCode._2017.Day11;

internal record struct HexGridCoordinate(int X, int Y, int Z)
{
    public static HexGridCoordinate operator +(HexGridCoordinate a, HexGridCoordinate b)
        => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

    public readonly int Distance() => (Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z)) / 2;
}
