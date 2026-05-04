using Point = (int x, int y);

namespace advent_of_code._2019.Day03;

internal static class Calculations
{
    public delegate void PointAction(ref Point pt);

    private static readonly Point Start = (0, 0);

    public static int Part1(ReadOnlySpan<char> input)
    {
        var (visited1, visited2) = GetVisitedPoints(input);

        var closest = (int.MaxValue, int.MaxValue);
        var bestManhattanDistance = int.MaxValue;

        // TODO: this is a second loop of each point
        foreach (var pt in visited2.Keys) // skip origin
        {
            if (!visited1.ContainsKey(pt)) continue;

            var newManhattanDistance = ManhattanDistance(pt, Start);

            if (newManhattanDistance >= bestManhattanDistance)
                continue;

            bestManhattanDistance = newManhattanDistance;
            closest = pt;
        }

        return bestManhattanDistance;
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        var (visited1, visited2) = GetVisitedPoints(input);

        var closest = (int.MaxValue, int.MaxValue);
        var bestWireDistance = int.MaxValue;

        // TODO: this is a second loop of each point
        foreach (var (pt, d1) in visited2.Skip(1)) // skip origin
        {
            if (!visited1.TryGetValue(pt, out var d2)) continue;


            var d = d1 + d2;

            if (d >= bestWireDistance)
                continue;

            bestWireDistance = d;
            closest = pt;
        }

        return bestWireDistance;
    }

    private static (Dictionary<(int x, int y), int> visited1, Dictionary<(int x, int y), int> visited2) GetVisitedPoints(ReadOnlySpan<char> input)
    {
        var lines = input.EnumerateLines();

        if (!lines.MoveNext()) throw new ArgumentException("Line 1 not found");
        var line1 = lines.Current;
        if (!lines.MoveNext()) throw new ArgumentException("Line 2 not found");
        var line2 = lines.Current;

        return (GetVisited(line1), GetVisited(line2));
    }

    private static Dictionary<Point, int> GetVisited(ReadOnlySpan<char> line1)
    {
        var p = Start;
        var n = line1.Count(',') + 1;
        var steps = 0;

        Span<Range> r = stackalloc Range[n];
        line1.Split(r, ',');

        // Don't add origin: We don't need it, and makes result enumeration easier
        Dictionary<Point, int> visited = [];

        for (var i = 0; i < n; i++)
        {
            var instruction = line1[r[i]];
            var direction = instruction[0];
            var length = int.Parse(instruction[1..]);

            Action moveOneStep = direction switch
            {
                'U' => () => p.y -= 1,
                'D' => () => p.y += 1,
                'L' => () => p.x -= 1,
                'R' => () => p.x += 1,
                _ => throw new NotImplementedException(),
            };

            for (var j = 0; j < length; j++)
            {
                moveOneStep();
                steps++;
                visited.TryAdd(p, steps);
            }
        }

        return visited;
    }

    private static int ManhattanDistance(Point left, Point right)
        => Math.Abs(right.x - left.x) + Math.Abs(right.y - left.y);
}