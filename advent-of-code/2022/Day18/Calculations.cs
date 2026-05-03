using Bounds = ((int x, int y, int z) min, (int x, int y, int z) max);

namespace advent_of_code._2022.Day18;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var cubes = UnitCube.ParseMany(input);

        var sum = 0;

        foreach (var cube in cubes)
        {
            var faces = 6;

            if (cubes.Contains((cube.X + 1, cube.Y, cube.Z))) faces--;
            if (cubes.Contains((cube.X - 1, cube.Y, cube.Z))) faces--;
            if (cubes.Contains((cube.X, cube.Y + 1, cube.Z))) faces--;
            if (cubes.Contains((cube.X, cube.Y - 1, cube.Z))) faces--;
            if (cubes.Contains((cube.X, cube.Y, cube.Z + 1))) faces--;
            if (cubes.Contains((cube.X, cube.Y, cube.Z - 1))) faces--;

            sum += faces;
        }

        return sum;
    }

    public static int Part2(string input)
    {
        var cubes = UnitCube.ParseMany(input);
        var bounds = GetBounds(cubes);
        var air = GetAir(cubes, bounds);

        var faces = 0;

        foreach (var cube in air)
        {
            if (cubes.Contains((cube.X + 1, cube.Y, cube.Z))) faces++;
            if (cubes.Contains((cube.X - 1, cube.Y, cube.Z))) faces++;
            if (cubes.Contains((cube.X, cube.Y + 1, cube.Z))) faces++;
            if (cubes.Contains((cube.X, cube.Y - 1, cube.Z))) faces++;
            if (cubes.Contains((cube.X, cube.Y, cube.Z + 1))) faces++;
            if (cubes.Contains((cube.X, cube.Y, cube.Z - 1))) faces++;
        }

        return faces;
    }

    private static UnitCube[] GetAir(UnitCube[] cubes, Bounds bounds)
    {
        UnitCube start = (UnitCube)bounds.min;
        HashSet<UnitCube> air = [];
        Queue<UnitCube> q = new();

        q.Enqueue(start);

        while (q.Count > 0)
        {
            var cube = q.Dequeue();

            if (air.Contains(cube)) continue;

            // Check bounds
            if (cube.X < bounds.min.x) continue;
            if (cube.Y < bounds.min.y) continue;
            if (cube.Z < bounds.min.z) continue;
            if (cube.X > bounds.max.x) continue;
            if (cube.Y > bounds.max.y) continue;
            if (cube.Z > bounds.max.z) continue;

            // This cube is lava
            if (cubes.Contains(cube)) continue;

            // This cube is air!
            air.Add(cube);

            // Check all neighbors next
            q.Enqueue((cube.X + 1, cube.Y, cube.Z));
            q.Enqueue((cube.X - 1, cube.Y, cube.Z));
            q.Enqueue((cube.X, cube.Y + 1, cube.Z));
            q.Enqueue((cube.X, cube.Y - 1, cube.Z));
            q.Enqueue((cube.X, cube.Y, cube.Z + 1));
            q.Enqueue((cube.X, cube.Y, cube.Z - 1));
        }

        return [.. air]; ;
    }

    private static Bounds GetBounds(IEnumerable<UnitCube> cubes)
    {
        (int min, int max) x = (int.MaxValue, int.MinValue);
        var y = x;
        var z = x;

        foreach (var cube in cubes)
        {
            x.min = Math.Min(x.min, cube.X);
            x.max = Math.Max(x.max, cube.X);
            y.min = Math.Min(y.min, cube.Y);
            y.max = Math.Max(y.max, cube.Y);
            z.min = Math.Min(z.min, cube.Z);
            z.max = Math.Max(z.max, cube.Z);
        }

        return ((x.min - 1, y.min - 1, z.min - 1), (x.max + 1, y.max + 1, z.max + 1));
    }
}
