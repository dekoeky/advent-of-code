namespace advent_of_code._2020.Day17;

internal static class Calculations
{
    private const int Capacity = 10 * 10;

    public static int Part1(ReadOnlySpan<char> input)
        => Execute<Cube3D>(input);

    public static long Part2(ReadOnlySpan<char> input)
        => Execute<Cube4D>(input);

    private static int Execute<TCube>(ReadOnlySpan<char> input)
        where TCube : struct, ICube<TCube>
    {
        var activeCubes = Parse<TCube>(input);
        var inactiveCubes = new HashSet<TCube>();
        var toBeActivated = new HashSet<TCube>();
        var toBeDeActivated = new HashSet<TCube>();
        var cycle = 0;

        for (cycle = 0; cycle < 6; cycle++)
        {
            PrintActiveCubeCount();

            // If a cube is active and exactly 2 or 3 of its neighbors are also active, the cube remains active.
            // Otherwise, the cube becomes inactive.
            foreach (var cube in activeCubes)
                if (!TwoOrThreeNeighborsActive(activeCubes, cube))
                    toBeDeActivated.Add(cube);

            inactiveCubes.Clear();
            foreach (var activeCube in activeCubes)
                foreach (var neighbor in activeCube.EnumerateNeighbors())
                    if (!activeCubes.Contains(neighbor))
                        inactiveCubes.Add(neighbor);

            // If a cube is inactive but exactly 3 of its neighbors are active, the cube becomes active.
            // Otherwise, the cube remains inactive.
            foreach (var cube in inactiveCubes)
                if (ExactlyThreeNeighborsActive(activeCubes, cube))
                    toBeActivated.Add(cube);

            // Perform deactivations and activations
            foreach (var cube in toBeDeActivated) activeCubes.Remove(cube);
            foreach (var cube in toBeActivated) activeCubes.Add(cube);

            // Prevent activating/deactivating twice
            toBeDeActivated.Clear();
            toBeActivated.Clear();

            PrintActiveCubeCount();
        }

        PrintActiveCubeCount();
        return activeCubes.Count;

        void PrintActiveCubeCount()
        {
            Debug.WriteLine($"After {cycle} cycles: {activeCubes.Count} active cubes");
        }
    }

    private static bool TwoOrThreeNeighborsActive<T>(HashSet<T> activeCubes, T cube)
        where T : struct, ICube<T>
    {
        var n = 0;

        foreach (var neighbor in cube.EnumerateNeighbors())
            if (activeCubes.Contains(neighbor))
                if (++n > 3) return false;

        return n == 2 || n == 3;
    }

    private static bool ExactlyThreeNeighborsActive<T>(HashSet<T> activeCubes, T cube)
        where T : struct, ICube<T>
    {
        var n = 0;

        foreach (var neighbor in cube.EnumerateNeighbors())
            if (activeCubes.Contains(neighbor))
                if (++n > 3) return false;

        return n == 3;
    }

    private static HashSet<T> Parse<T>(ReadOnlySpan<char> input)
        where T : struct, ICube<T>
    {
        var cubes = new HashSet<T>(Capacity);
        var r = 0;

        foreach (var line in input.EnumerateLines())
        {
            for (var c = 0; c < line.Length; c++)
                if (line[c] == '#')
                    cubes.Add(T.From2D(c, r));

            r++;
        }

        return cubes;
    }
}
