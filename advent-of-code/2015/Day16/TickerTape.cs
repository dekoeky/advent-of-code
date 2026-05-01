namespace AdventOfCode._2015.Day16;

internal class TickerTape
{
    public static Dictionary<string, int> Parse(string input)
        => SplitOn.NewLines(input)
        .Select(l => l.Split(':', StringSplitOptions.TrimEntries))
        .ToDictionary(p => p[0], p => int.Parse(p[1]));
}
