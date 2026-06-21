namespace advent_of_code._2020.Day17;

internal readonly struct Cube
{
    public readonly int X, Y, Z;
    public Cube(int x, int y, int z) => (X, Y, Z) = (x, y, z);
    public Cube[] BuildNeighbors()
    {
        var list = new Cube[26];
        var i = 0;

        for (int dx = -1; dx <= 1; dx++)
            for (int dy = -1; dy <= 1; dy++)
                for (int dz = -1; dz <= 1; dz++)
                    if (!(dx == 0 && dy == 0 && dz == 0))
                        list[i++] = new Cube(X + dx, Y + dy, Z + dz);

        return list;
    }

    public IEnumerable<Cube> EnumerateNeighbors()
    {
        for (int dx = -1; dx <= 1; dx++)
            for (int dy = -1; dy <= 1; dy++)
                for (int dz = -1; dz <= 1; dz++)
                    if (!(dx == 0 && dy == 0 && dz == 0))
                        yield return new Cube(X + dx, Y + dy, Z + dz);
    }



    public IEnumerable<Cube> EnumerateSelfAndNeighbors()
    {
        for (int dx = -1; dx <= 1; dx++)
            for (int dy = -1; dy <= 1; dy++)
                for (int dz = -1; dz <= 1; dz++)
                    yield return new Cube(X + dx, Y + dy, Z + dz);
    }
}