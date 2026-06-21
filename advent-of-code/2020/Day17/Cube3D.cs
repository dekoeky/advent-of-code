namespace advent_of_code._2020.Day17;

internal readonly struct Cube3D : ICube<Cube3D>
{
    public const int NeighborCount = 26;

    public readonly int X, Y, Z;
    public Cube3D(int x, int y, int z) => (X, Y, Z) = (x, y, z);

    public static Cube3D From2D(int x, int y) => new(x, y, 0);

    public IEnumerable<Cube3D> EnumerateNeighbors()
    {
        for (int dx = -1; dx <= 1; dx++)
            for (int dy = -1; dy <= 1; dy++)
                for (int dz = -1; dz <= 1; dz++)
                    if (!(dx == 0 && dy == 0 && dz == 0))
                        yield return new Cube3D(X + dx, Y + dy, Z + dz);
    }
}
