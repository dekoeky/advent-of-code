using RC = (int Row, int Col);

namespace advent_of_code._2024.Day18;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input, int gridSize = 71, int bytes = 1024)
    {
        var start = new RC(0, 0);
        var exit = new RC(gridSize - 1, gridSize - 1);

        var corrupted = GetCorrupted(input, bytes);

        var visited = new HashSet<RC>();
        var q = new Queue<(RC Position, int Steps)>();

        q.Enqueue((start, 0));

        while (q.Count > 0)
        {
            var ((r, c), steps) = q.Dequeue();

            // Out of memory space
            if (r < 0 || c < 0 || r >= gridSize || c >= gridSize)
                continue;

            // Corrupted memory
            if (corrupted.Contains((r, c)))
                continue;

            // Check already visited
            if (!visited.Add((r, c)))
                continue;

            if ((r, c) == exit)
                return steps;

            steps++;
            q.Enqueue(((r + 1, c), steps));
            q.Enqueue(((r - 1, c), steps));
            q.Enqueue(((r, c + 1), steps));
            q.Enqueue(((r, c - 1), steps));
        }

        return int.MaxValue;
    }

    private static HashSet<(int Row, int Col)> GetCorrupted(ReadOnlySpan<char> input, int bytes)
    {
        var corrupted = new HashSet<RC>(bytes);

        var lines = input.EnumerateLines();

        for (var i = 0; i < bytes; i++)
        {
            if (!lines.MoveNext()) throw new InvalidOperationException("Not enough bytes");
            var line = lines.Current;
            var comma = line.IndexOf(',');
            var x = int.Parse(line[..comma]);
            var y = int.Parse(line[++comma..]);

            corrupted.Add((y, x));
        }

        return corrupted;
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }
}
