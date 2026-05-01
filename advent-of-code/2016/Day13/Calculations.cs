using System.Numerics;

namespace AdventOfCode._2016.Day13;

internal static class Calculations
{
    public static int Part1(int fav, (int x, int y) target) => Execute(fav, target: target, maxSteps: null).Steps;

    public static int Part2(int fav, int maxSteps) => Execute(fav, target: null, maxSteps: maxSteps).Seen;

    private static (int Seen, int Steps) Execute(int fav, (int x, int y)? target, int? maxSteps)
    {
        var start = (x: 1, y: 1);
        var queue = new Queue<((int x, int y) pos, int steps)>();
        var seen = new HashSet<(int x, int y)>();
        int steps = 0;
        (int x, int y) pos;

        queue.Enqueue((start, 0));
        seen.Add(start);

        while (queue.Count > 0)
        {
            (pos, steps) = queue.Dequeue();

            if (pos == target)
                break;

            if (steps == maxSteps)
                continue;

            foreach (var n in Neighbors(pos))
                if (!seen.Contains(n) && IsOpen(n.x, n.y, fav))
                {
                    seen.Add(n);
                    queue.Enqueue((n, steps + 1));
                }
        }

        return (seen.Count, steps);
    }

    private static bool IsOpen(int x, int y, int fav)
    {
        if (x < 0 || y < 0) return false;

        long v = x * x
            + 3 * x
            + 2 * x * y
            + y
            + y * y
            + fav;

        // Count Bits
        int bits = BitOperations.PopCount((uint)v);

        // Open, when even
        return bits % 2 == 0;
    }

    private static IEnumerable<(int x, int y)> Neighbors((int x, int y) p)
    {
        yield return (p.x + 1, p.y);
        yield return (p.x - 1, p.y);
        yield return (p.x, p.y + 1);
        yield return (p.x, p.y - 1);
    }
}