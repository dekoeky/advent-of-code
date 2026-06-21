namespace advent_of_code._2020.Day17;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var activeCubes = Parse(input);
        var activate = new HashSet<Cube>();
        var deActivate = new HashSet<Cube>();

        Debug.WriteLine($"After {0} cycles: {activeCubes.Count} active cubes");

        for (var cycle = 0; cycle < 6; cycle++)
        {
            // If a cube is active and exactly 2 or 3 of its neighbors are also active, the cube remains active.
            // Otherwise, the cube becomes inactive.
            foreach (var cube in activeCubes)
                if (!TwoOrThreeNeighborsActive(activeCubes, cube))
                    deActivate.Add(cube);

            var inactiveCubes = activeCubes
                .SelectMany(c => c.EnumerateNeighbors())
                .Distinct()
                .Where(c => !activeCubes.Contains(c));

            // If a cube is inactive but exactly 3 of its neighbors are active, the cube becomes active.
            // Otherwise, the cube remains inactive.
            foreach (var cube in inactiveCubes)
                if (ExactlyThreeNeighborsActive(activeCubes, cube))
                    activate.Add(cube);

            foreach (var cube in deActivate)
                activeCubes.Remove(cube);
            foreach (var cube in activate)
                activeCubes.Add(cube);

            deActivate.Clear();
            activate.Clear();

            Debug.WriteLine($"After {cycle + 1} cycles: {activeCubes.Count} active cubes");
        }

        return activeCubes.Count;
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }

    private static bool TwoOrThreeNeighborsActive(HashSet<Cube> activeCubes, Cube cube)
    {
        var n = 0;

        foreach (var neighbor in cube.EnumerateNeighbors())
            if (activeCubes.Contains(neighbor))
                if (++n > 3) return false;

        return n == 2 || n == 3;
    }

    private static bool ExactlyThreeNeighborsActive(HashSet<Cube> activeCubes, Cube cube)
    {
        var n = 0;

        foreach (var neighbor in cube.EnumerateNeighbors())
            if (activeCubes.Contains(neighbor))
                if (++n > 3) return false;

        return n == 3;
    }

    private static HashSet<Cube> Parse(ReadOnlySpan<char> input)
    {
        var cubes = new HashSet<Cube>(10 * 10);
        var r = 0;

        foreach (var line in input.EnumerateLines())
        {
            for (var c = 0; c < line.Length; c++)
                if (line[c] == '#')
                    cubes.Add(new Cube(c, r, 0));

            r++;
        }

        return cubes;
    }
}
