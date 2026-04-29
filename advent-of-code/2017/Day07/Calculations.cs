namespace advent_of_code._2017.Day07;

internal static class Calculations
{
    /// <summary>
    /// Parses input lines into a dictionary of nodes keyed by name.
    /// </summary>
    public static Dictionary<string, Node> ParseNodes(string input)
    {
        var dict = new Dictionary<string, Node>(StringComparer.Ordinal);

        foreach (var line in SplitOn.NewLines(input))
        {
            // Example:
            // fwft (72) -> ktlj, cntj, xhth
            // or:
            // pbga (66)

            var parts = line.Split("->", StringSplitOptions.TrimEntries);
            var left = parts[0].Trim();

            var tokens = left.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];

            // tokens[1] is like "(72)"
            var weightStr = tokens[1].Trim();
            if (weightStr[0] == '(' && weightStr[^1] == ')')
                weightStr = weightStr[1..^1];

            var weight = int.Parse(weightStr);

            var node = new Node(name, weight);

            if (parts.Length > 1)
            {
                var childrenPart = parts[1];
                var childNames = childrenPart.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                node.ChildNames.AddRange(childNames);
            }

            dict[name] = node;
        }

        return dict;
    }

    public static string FindRootName(Dictionary<string, Node> nodesByName)
    {
        var allNames = new HashSet<string>(nodesByName.Keys, StringComparer.Ordinal);
        var childNames = new HashSet<string>(StringComparer.Ordinal);

        foreach (var node in nodesByName.Values)
        {
            foreach (var child in node.ChildNames)
                childNames.Add(child);
        }

        allNames.ExceptWith(childNames);

        // There should be exactly one.
        return allNames.Single();
    }

    /// <summary>
    /// Links children to build a proper tree and returns the root node.
    /// </summary>
    private static Node BuildTree(Dictionary<string, Node> nodesByName, string rootName)
    {
        foreach (var node in nodesByName.Values)
        {
            node.Children.Clear();
            foreach (var childName in node.ChildNames)
            {
                if (nodesByName.TryGetValue(childName, out var child))
                    node.Children.Add(child);
            }
        }

        return nodesByName[rootName];
    }

    public static int? FindCorrectedWeight(Dictionary<string, Node> nodesByName)
    {
        var rootName = FindRootName(nodesByName);
        var root = BuildTree(nodesByName, rootName);

        var (_, corrected) = Dfs(root);
        return corrected;
    }
    private static (int total, int? corrected) Dfs(Node node)
    {
        if (node.Children.Count == 0)
            return (node.Weight, null);

        var childTotals = new int[node.Children.Count];
        int? foundCorrection = null;

        for (int i = 0; i < node.Children.Count; i++)
        {
            var (total, corr) = Dfs(node.Children[i]);
            childTotals[i] = total;
            if (corr.HasValue)
                foundCorrection = corr;
        }

        if (foundCorrection.HasValue)
            return (node.Weight + childTotals.Sum(), foundCorrection);

        // Check if children are balanced.
        // Group by total weight.
        var groups = childTotals
            .Select((w, idx) => (Weight: w, Index: idx))
            .GroupBy(x => x.Weight)
            .ToList();

        if (groups.Count > 1)
        {
            // One group has size 1 (wrong), the other is the correct weight.
            var wrongGroup = groups.Single(g => g.Count() == 1);
            var correctGroup = groups.Single(g => g.Count() > 1);

            var wrongIndex = wrongGroup.First().Index;
            var wrongChild = node.Children[wrongIndex];

            var wrongTotal = wrongGroup.Key;
            var correctTotal = correctGroup.Key;

            // Adjust own weight by the difference.
            var delta = correctTotal - wrongTotal;
            var correctedWeight = wrongChild.Weight + delta;

            return (node.Weight + childTotals.Sum(), correctedWeight);
        }

        return (node.Weight + childTotals.Sum(), null);
    }
}
