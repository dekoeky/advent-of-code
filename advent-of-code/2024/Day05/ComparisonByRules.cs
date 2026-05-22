namespace advent_of_code._2024.Day05;

internal class ComparisonByRules(PageOrderingRule[] rules) : Comparer<int>
{
    public override int Compare(int x, int y)
    {
        // Assume only a single one can

        foreach (var rule in rules)
            if (rule.A == x && rule.B == y)
                return -1;
            else if (rule.A == y && rule.B == x)
                return +1;

        // Don't care
        return 0;
    }
}