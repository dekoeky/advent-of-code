namespace AdventOfCode._2016.Day22;

internal static class Calculations
{
    public static int ViablePairs(ICollection<NodeDiskUsage> usages)
    {
        var count = 0;

        foreach (var a in usages)
            foreach (var b in usages)
                if (IsViablePair(a, b)) // is viable includes checking if same, so we can keep loop simple
                    count++;

        return count;
    }

    public static bool IsViablePair(NodeDiskUsage a, NodeDiskUsage b)
        => a.Used > 0
        && a.Name != b.Name
        && a.Used <= b.Avail;

    public static int Part2(IEnumerable<NodeDiskUsage> nodes)
    {
        var grid = nodes.ToDictionary(n => (n.X, n.Y));
        int maxX = grid.Keys.Max(k => k.X);
        int maxY = grid.Keys.Max(k => k.Y);

        // Identify empty node
        var empty = grid.Values.Single(n => n.Used == 0);
        var emptyPos = (empty.X, empty.Y);

        // Identify goal node (top-right)
        var goalPos = (X: maxX, Y: 0);

        // Identify walls: nodes too large to ever receive data
        int emptySize = empty.Size;
        var walls = new HashSet<(int x, int y)>(
            grid.Values
                .Where(n => n.Used > emptySize)
                .Select(n => (n.X, n.Y))
        );

        // We need the empty node to reach the tile left of the goal
        var target = (goalPos.X - 1, goalPos.Y);

        int stepsToSetup = BFS(emptyPos, target, walls, maxX, maxY);

        // Now apply the sliding puzzle formula
        int shifts = goalPos.X; // number of left moves needed
        int total = stepsToSetup + 1 + (shifts - 1) * 5;

        return total;
    }

    private static int BFS(
        (int x, int y) start,
        (int x, int y) goal,
        HashSet<(int x, int y)> walls,
        int maxX,
        int maxY)
    {
        var q = new Queue<((int x, int y) pos, int dist)>();
        var visited = new HashSet<(int x, int y)>();

        q.Enqueue((start, 0));
        visited.Add(start);

        int[][] dirs =
        [
            [+1, 0],
            [-1, 0],
            [0, +1],
            [0, -1]
        ];

        while (q.Count > 0)
        {
            var (pos, dist) = q.Dequeue();
            if (pos == goal)
                return dist;

            foreach (var d in dirs)
            {
                int nx = pos.x + d[0];
                int ny = pos.y + d[1];

                var next = (nx, ny);

                if (nx < 0 || ny < 0 || nx > maxX || ny > maxY)
                    continue;

                if (walls.Contains(next))
                    continue;

                if (visited.Contains(next))
                    continue;

                visited.Add(next);
                q.Enqueue((next, dist + 1));
            }
        }

        throw new InvalidOperationException("No path found for empty node");
    }
}
