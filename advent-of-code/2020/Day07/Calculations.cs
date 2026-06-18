namespace advent_of_code._2020.Day07;

internal static class Calculations
{
    public static long Part1(ReadOnlySpan<char> input)
    {
        var rules = Parse(input);

        var containsGold = new Dictionary<string, bool>();

        return rules.Keys.Count(name => ContainsGoldRecursive(rules, containsGold, name));
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        var rules = Parse(input);

        var contentCounts = new Dictionary<string, long>();

        return CountContentsRecursive(rules, contentCounts, "shiny gold");
    }

    private static bool ContainsGoldRecursive(
        Dictionary<string, Dictionary<string, int>> rules,
        Dictionary<string, bool> containsGold,
        string name
        )
    {
        // If cached, return cached result
        if (containsGold.TryGetValue(name, out var result))
            return result;

        if (!rules.TryGetValue(name, out var contents))
            result = false;

        else if (contents.ContainsKey("shiny gold"))
            result = true;

        else
            result = contents.Keys.Any(c => ContainsGoldRecursive(rules, containsGold, c));


        // Cache result
        containsGold.Add(name, result);

        // Return final result
        return result;
    }

    private static long CountContentsRecursive(
       Dictionary<string, Dictionary<string, int>> rules,
       Dictionary<string, long> contentCounts,
       string name
       )
    {
        checked
        {
            // If cached, return cached result
            if (contentCounts.TryGetValue(name, out var result))
                return result;

            if (!rules.TryGetValue(name, out var contents))
                result = 0;

            else
                result = contents.Sum(kv => (CountContentsRecursive(rules, contentCounts, kv.Key) + 1) * kv.Value);


            // Cache result
            contentCounts.Add(name, result);

            // Return final result
            return result;
        }
    }

    private static Dictionary<string, Dictionary<string, int>> Parse(ReadOnlySpan<char> input)
    {
        var all = new Dictionary<string, Dictionary<string, int>>();

        foreach (var line in input.EnumerateLines())
        {
            var (bagType, contents) = Parse1(line);
            all.Add(bagType, contents);
        }

        return all;
    }

    private static KeyValuePair<string, Dictionary<string, int>> Parse1(ReadOnlySpan<char> input)
    {
        // Assume max 10 types of bag in any other bag
        const int max = 10;

        // Everything in front of bag/bags is considered name
        var idx = input.IndexOf("bag") - 1;
        var name = input[..idx].ToString();

        // Special case: bag with no contents
        if (input.Contains("no other bags", StringComparison.OrdinalIgnoreCase))
            return new KeyValuePair<string, Dictionary<string, int>>(name, []);

        // Take only the part after "contain "
        const string splitter = "contain ";
        idx = input.IndexOf(splitter) + splitter.Length;
        input = input[idx..];


        Span<Range> ranges = stackalloc Range[max];
        var n = input.Split(ranges, ',', StringSplitOptions.TrimEntries);
        if (max <= n)
            throw new InvalidOperationException("Buffer too small");

        var counts = new Dictionary<string, int>(max);

        for (var i = 0; i < n; i++)
        {
            ExtractCountAndName(input[ranges[i]], out var count, out var name2);
            counts.Add(name2, count);
        }

        return new KeyValuePair<string, Dictionary<string, int>>(name, counts);
    }

    private static void ExtractCountAndName(ReadOnlySpan<char> input, out int count, out string name)
    {
        input = input.Trim();

        // Count is first part
        var idx = input.IndexOf(' ');
        count = int.Parse(input[..idx]);

        // Name is everyting after count, except "bag" or "bags"
        input = input[(idx + 1)..]; // +1 for removing space
        idx = input.IndexOf("bag");
        input = input[..(idx - 1)]; // -1 for removing space
        name = input.ToString();
    }
}