namespace advent_of_code._2020.Day17;

internal readonly struct Cube4D : ICube<Cube4D>
{
    public const int NeighborCount = 80;

    public readonly int X, Y, Z, W;
    public Cube4D(int x, int y, int z, int w) => (X, Y, Z, W) = (x, y, z, w);

    public static Cube4D From2D(int x, int y) => new(x, y, 0, 0);

    public IEnumerable<Cube4D> EnumerateNeighbors()
    {
        for (int dx = -1; dx <= 1; dx++)
            for (int dy = -1; dy <= 1; dy++)
                for (int dz = -1; dz <= 1; dz++)
                    for (int dw = -1; dw <= 1; dw++)
                        if (!(dx == 0 && dy == 0 && dz == 0 && dw == 0))
                            yield return new Cube4D(X + dx, Y + dy, Z + dz, W + dw);
    }
}