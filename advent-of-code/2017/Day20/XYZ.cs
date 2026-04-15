namespace advent_of_code._2017.Day20;

internal record struct XYZ(int X, int Y, int Z)
{
    public readonly int Magnitude() => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
}
