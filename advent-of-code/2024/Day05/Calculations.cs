namespace advent_of_code._2024.Day05;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input) => Execute(input).Score1;

    public static int Part2(ReadOnlySpan<char> input) => Execute(input).Score2;

    private static (int Score1, int Score2) Execute(ReadOnlySpan<char> input)
    {
        Parsing.Parse(input, out var rules, out var updates);

        var comparison = new ComparisonByRules(rules);

        var validSum = 0;
        var invalidSum = 0;

        foreach (var update in updates)
        {
            var isUpdateValid = true;

            foreach (var rule in rules)
            {
                var a = update.IndexOf(rule.A);
                if (a == -1) continue;

                var b = update.IndexOf(rule.B);
                if (b == -1) continue;

                if (a > b)
                {
                    isUpdateValid = false;

                    // No need for checking other rules
                    break;
                }
            }

            if (isUpdateValid)
            {
                validSum += Print(update, "VALID", true);
            }
            else
            {
                Print(update, "INVALID");
                update.Sort(comparison);
                invalidSum += Print(update, "SORTED", true);
            }
            Debug.WriteLine();
        }

        return (validSum, invalidSum);
    }

    private static int Print(int[] pages, string name, bool withCenterValue = false)
    {
        var centerValue = -1;
        if (withCenterValue)
            centerValue = pages[pages.Length / 2];

        Debug.Write($"[{name,7}] ");
        var first = true;

        foreach (var page in pages)
        {
            if (!first) Debug.Write(',');
            first = false;
            if (centerValue == page)
                Debug.Write($"[{page}]");
            else
                Debug.Write(page);
        }
        Debug.WriteLine();

        return centerValue;
    }
}
