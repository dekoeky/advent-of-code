namespace advent_of_code._2018.Day20;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var graph = BuildGraph(input);
        return BFSMaxDistance(graph, (0, 0));
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        var graph = BuildGraph(input);
        return CountFarRooms(graph, (0, 0), 1000);
    }

    private static Graph BuildGraph(ReadOnlySpan<char> input)
    {
        // Strip ^ and $
        var regex = input[1..^1];

        // Graph: room -> neighbors
        var graph = new Graph();

        // To remember where we branched off
        var stack = new Stack<XY>();

        var current = new XY(X: 0, Y: 0);

        foreach (var c in regex)
            switch (c)
            {
                case 'N':
                case 'S':
                case 'E':
                case 'W':
                    var next = Move(current, c);
                    AddEdge(graph, current, next);
                    current = next;
                    break;

                case '(':
                    stack.Push(current);
                    break;

                case '|':
                    current = stack.Peek();
                    break;

                case ')':
                    current = stack.Pop();
                    break;
            }

        return graph;
    }

    private static XY Move(XY p, char dir)
        => dir switch
        {
            'N' => (p.X, p.Y - 1),
            'S' => (p.X, p.Y + 1),
            'E' => (p.X + 1, p.Y),
            'W' => (p.X - 1, p.Y),
            _ => p
        };

    private static void AddEdge(
        Graph g,
        XY a,
        XY b)
    {
        if (!g.TryGetValue(a, out var aNeighbors))
            g[a] = aNeighbors = [];

        if (!g.TryGetValue(b, out var bNeighbors))
            g[b] = bNeighbors = [];

        // Room a leads to b
        // Room b leads to a as well
        aNeighbors.Add(b);
        bNeighbors.Add(a);
    }

    private static int BFSMaxDistance(Graph g, XY start)
    {
        var q = new Queue<XY>();
        var dist = new Dictionary<XY, int>();

        q.Enqueue(start);
        dist[start] = 0;

        var max = 0;

        while (q.Count > 0)
        {
            var p = q.Dequeue();
            var d = dist[p];

            if (d > max)
                max = d;

            if (!g.TryGetValue(p, out var neighbors))
                continue;

            foreach (var n in neighbors)
                if (!dist.ContainsKey(n))
                {
                    dist[n] = d + 1;
                    q.Enqueue(n);
                }
        }

        return max;
    }

    private static int CountFarRooms(
        Graph g,
        XY start,
        int threshold)
    {
        var q = new Queue<XY>();
        var distances = new Dictionary<XY, int>();

        q.Enqueue(start);
        distances[start] = 0;

        var count = 0;

        while (q.Count > 0)
        {
            var p = q.Dequeue();
            var d = distances[p];

            if (d >= threshold)
                count++;

            if (!g.TryGetValue(p, out var neighbors))
                continue;

            foreach (var neighbor in neighbors)
                if (!distances.ContainsKey(neighbor))
                {
                    distances[neighbor] = d + 1;
                    q.Enqueue(neighbor);
                }
        }

        return count;
    }

    // Types to make it a bit more readable
    private class Graph : Dictionary<XY, NeighborCollection>;
    private class NeighborCollection : HashSet<XY>;
}