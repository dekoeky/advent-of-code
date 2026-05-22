namespace advent_of_code._2024.Day05;

internal static class Parsing
{
    public static void Parse(ReadOnlySpan<char> input, out PageOrderingRule[] rules, out int[][] updates)
    {
        var lineCount = input.Count('\n') + 1;
        var ruleCount = input.Count(PageOrderingRule.Splitter);
        var updateCount = lineCount - ruleCount - 1;

        var i = 0;
        rules = new PageOrderingRule[ruleCount];
        updates = new int[updateCount][];

        Span<Range> ranges = stackalloc Range[50];

        var rulesComplete = false;

        foreach (var line in input.EnumerateLines())
        {
            if (line.IsEmpty)
            {
                rulesComplete = true;
                i = 0;
                continue;
            }

            if (rulesComplete)
            {
                var pageCount = line.Split(ranges, ',');
                if (pageCount == ranges.Length) throw new Exception("Span too small");
                var pages = new int[pageCount];
                for (var j = 0; j < pageCount; j++)
                    pages[j] = int.Parse(line[ranges[j]]);
                updates[i++] = pages;
            }
            else
                rules[i++] = PageOrderingRule.Parse(line);
        }
    }
}
