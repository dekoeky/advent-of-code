using Pos = (int X, int Y);

namespace advent_of_code._2022.Day12;


internal static partial class Calculations
{
    internal static readonly Pos[] Moves = [
        (-1, 0),
        (+1, 0),
        (0, -1),
        (0, +1),
        ];
    internal static readonly Pos Invalid = new(-1, -1);

    public static long Part1(ReadOnlySpan<char> input)
    {
        var map = Parse(input, out var start, out var target, out var rows, out var cols);

        var visited = new HashSet<Pos>();
        var q = new PriorityQueue<Pos, int>();
        q.Enqueue(start, 0);

        while (q.TryDequeue(out var pos, out var steps))
        {
            if (pos == target)
                return steps;

            foreach (var (dx, dy) in Moves)
            {
                Pos newPos = (pos.X + dx, pos.Y + dy);

                // Out of bounds check
                if (newPos.X < 0
                    || newPos.Y < 0
                    || newPos.X >= cols
                    || newPos.Y >= rows)
                    continue;

                var h1 = map[pos.Y, pos.X];
                var h2 = map[newPos.Y, newPos.X];

                if (h2 > h1 + 1)
                    continue;

                // Visited check
                if (!visited.Add(newPos))
                    continue;

                q.Enqueue(newPos, steps + 1);
            }
        }

        return -1;
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        var map = Parse(input, out _, out var target, out var rows, out var cols);

        var visited = new HashSet<Pos>();
        var q = new PriorityQueue<Pos, int>();
        q.Enqueue(target, 0);

        while (q.TryDequeue(out var pos, out var steps))
        {
            if (map[pos.Y, pos.X] == 0) // 'a'
                return steps;

            foreach (var (dx, dy) in Moves)
            {
                Pos newPos = (pos.X + dx, pos.Y + dy);

                // Out of bounds check
                if (newPos.X < 0
                    || newPos.Y < 0
                    || newPos.X >= cols
                    || newPos.Y >= rows)
                    continue;

                var h1 = map[pos.Y, pos.X];
                var h2 = map[newPos.Y, newPos.X];

                if (h2 < h1 - 1)
                    continue;

                // Visited check
                if (!visited.Add(newPos))
                    continue;

                q.Enqueue(newPos, steps + 1);
            }
        }

        return -1;
    }

    private static int[,] Parse(ReadOnlySpan<char> input, out Pos start, out Pos target, out int rows, out int cols)
    {
        StringToCharArray.GetSize(input, out rows, out cols);
        start = (0, 0);
        target = (0, 0);

        var map = new int[rows, cols];

        int r = 0;

        foreach (var line in input.EnumerateLines())
        {
            int c = 0;
            foreach (var ch in line)
            {
                switch (ch)
                {
                    case 'S':
                        start = (c, r);
                        map[r, c] = 0;
                        break;

                    case 'E':
                        target = (c, r);
                        map[r, c] = 25;
                        break;

                    default:
                        map[r, c] = ch - 'a';
                        break;
                }
                c++;
            }
            r++;
        }

        return map;
    }
}