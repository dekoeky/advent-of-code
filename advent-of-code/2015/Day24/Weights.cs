namespace AdventOfCode._2015.Day24;

public static class Weights
{
    public static int[] Parse(ReadOnlySpan<char> input)
    {
        var weights = new List<int>();

        foreach (var line in input.EnumerateLines())
            weights.Add(int.Parse(line));

        return [.. weights];
    }
}
