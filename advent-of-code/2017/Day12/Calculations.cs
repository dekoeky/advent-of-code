using advent_of_code.Helpers;

namespace advent_of_code._2017.Day12;

internal static class Calculations
{
    public static Dictionary<int, int[]> Parse(string input)
    {
        Dictionary<int, int[]> result = [];

        var lines = SplitOn.NewLines(input);

        foreach (var line in lines)
        {
            // Split key and value
            var parts = line.Split(" <-> ");

            // Parse key
            var key = int.Parse(parts[0]);

            // Parse values
            parts = parts[1].Split(", ");
            var value = parts.Select(int.Parse).ToArray();

            // Store
            result.Add(key, value);
        }

        return result;
    }

    public static void Execute(string input, out int group0Size, out int groupCount)
    {
        var pipes = Parse(input);
        var groups = pipes.Select(kv => kv.Value.Append(kv.Key).ToHashSet()).ToList();

        bool merged = true;

        while (merged)
        {
            merged = false;

            for (var i = 0; i < groups.Count; i++)
                for (var j = i + 1; j < groups.Count; j++)
                {
                    var a = groups[i];
                    var b = groups[j];

                    if (!a.Any(b.Contains) && !b.Any(a.Contains))
                        continue;

                    foreach (var item in b) a.Add(item);

                    groups.RemoveAt(j);
                    j--;

                    // Indicate merges occurred
                    merged = true;
                }
        }

        var group0 = groups.Single(g => g.Contains(0));
        group0Size = group0.Count;
        groupCount = groups.Count;
    }
}
