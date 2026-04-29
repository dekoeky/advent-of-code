namespace advent_of_code._2025.Day11;

internal static class Calculations
{
    public static Dictionary<string, string[]> Parse(string input)
        => SplitOn.NewLines(input)
        .Select(line => line.Split(": "))
        .ToDictionary(parts => parts[0], parts => parts[1].Split(' '));

    public static int Perform(string input)
    {
        var data = Parse(input);
        data.Add("out", []);

        var memo = new Dictionary<string, int>();
        int result = CountPaths("you", data, memo);

        return result;
    }

    public static int Perform2(string input)
    {
        throw new NotImplementedException();
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
}
