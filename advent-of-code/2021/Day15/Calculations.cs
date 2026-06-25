using Pos = (int X, int Y);

namespace advent_of_code._2021.Day15;

internal static class Calculations
{
    private static readonly Pos[] Moves = [

        (-1, 0),
        (0, -1),

        (+1, 0),
        (0, +1),
        ];

    public static int Part1(ReadOnlySpan<char> input)
    {
        var map = input.To2DArray(p => p - '0', out var rows, out var cols);
        var start = (0, 0);
        var target = (x: cols - 1, y: rows - 1);
        var visited = new Dictionary<(int x, int y), int>(rows * cols)
        {
            { start, 0 }
        };
        var pq = new PriorityQueue<Pos, int>();
        pq.Enqueue(start, 0);

        while (pq.TryDequeue(out var pos, out var risk))
        {
            // If already visited with a lower risk, skip
            if (visited.TryGetValue(pos, out var leastRisk) && leastRisk < risk)
                continue;

            // Indicate that this position can be reached with the given risk
            visited[pos] = risk;

            foreach (var (dx, dy) in Moves)
            {
                var newPosition = new Pos(pos.X + dx, pos.Y + dy);

                // Out of bounds check
                if (newPosition.X < 0
                    || newPosition.Y < 0
                    || newPosition.X >= cols
                    || newPosition.Y >= rows)
                    continue;

                // The risk of the new tile,
                // is the risk of the current tile
                // plus the risk of the next tile
                var newRisk = risk + map[newPosition.Y, newPosition.X];

                // Push into priority queue with priority = newRisk
                pq.Enqueue(newPosition, newRisk);
            }
        }

        return visited[target];
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }
}