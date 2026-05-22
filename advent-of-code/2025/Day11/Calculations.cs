namespace advent_of_code._2025.Day11;

internal static class Calculations
{
    public static Dictionary<string, string[]> Parse(string input)
        => SplitOn.NewLines(input)
        .Select(line => line.Split(": "))
        .ToDictionary(parts => parts[0], parts => parts[1].Split(' '));

    public static int Part1(string input)
    {
        var data = Parse(input);
        data.Add("out", []);

        var memo = new Dictionary<string, int>();
        int result = CountPaths("you", data, memo);

        return result;
    }

    private static int CountPaths(string node, Dictionary<string, string[]> graph, Dictionary<string, int> memo)
    {
        if (node == "out")
            return 1;

        if (memo.TryGetValue(node, out int cached))
            return cached;

        int total = 0;
        foreach (var child in graph[node])
            total += CountPaths(child, graph, memo);

        memo[node] = total;
        return total;
    }

    public static long Part2(string input)
    {
        var graph = Parse(input);
        var memo = new Dictionary<(string, string), long>();

        var result =
           Paths("svr", "dac", graph, memo) *
           Paths("dac", "fft", graph, memo) *
           Paths("fft", "out", graph, memo)
           +
           Paths("svr", "fft", graph, memo) *
           Paths("fft", "dac", graph, memo) *
           Paths("dac", "out", graph, memo);

        return result;
    }

    static long Paths(string from, string to, Dictionary<string, string[]> graph, Dictionary<(string, string), long> memo)
    {
        if (from == to)
            return 1;

        if (memo.TryGetValue((from, to), out var cached))
            return cached;

        long total = 0;

        if (graph.TryGetValue(from, out var neighbors))
            foreach (var next in neighbors)
                total += Paths(next, to, graph, memo);

        memo[(from, to)] = total;
        return total;
    }
}
