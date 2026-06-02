namespace advent_of_code._2023.Day09;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
        => Execute(input, NextValue);

    public static int Part2(ReadOnlySpan<char> input)
        => Execute(input, PreviousValue);

    private static void Analyze(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        Debug.WriteLine($"Lines: {n}");

        foreach (var line in input.EnumerateLines())
        {
            var m = line.Count(' ') + 1;
            Debug.WriteLine($"Values: {m}");
        }
    }

    private static int Execute(ReadOnlySpan<char> input, Func<Span<int>, int> f)
    {
        var sum = 0;

        foreach (var line in input.EnumerateLines())
            sum += ProcessLine(line, f);

        return sum;
    }

    private static int ProcessLine(ReadOnlySpan<char> input, Func<Span<int>, int> f)
    {
        var n = input.Count(' ') + 1;
        Span<Range> ranges = stackalloc Range[n];
        Span<int> values = stackalloc int[n];
        input.Split(ranges, ' ');
        for (var i = 0; i < n; i++)
            values[i] = int.Parse(input[ranges[i]]);

        return f(values);
    }

    private static int NextValue(Span<int> values)
    {
        var n = values.Length;
        var diff = 0;
        var lastValues = new List<int>(values.Length)
        {
            values[^1]
        };

        while (values.ContainsAnyExcept(0))
        {
            for (var i = 1; i < n; i++)
            {
                diff = values[i] - values[i - 1];
                values[i - 1] = diff;
            }
            n--;
            values = values[..n];
            lastValues.Add(diff);
        }

        return lastValues.Sum();
    }

    private static int PreviousValue(Span<int> values)
    {
        var n = values.Length;
        var firstValues = new List<int>(values.Length)
        {
            values[0]
        };

        while (values.ContainsAnyExcept(0))
        {
            var diff = 0;

            for (var i = 1; i < n; i++)
            {
                diff = values[i] - values[i - 1];
                values[i - 1] = diff;
            }

            n--;
            values = values[..n];
            firstValues.Add(values[0]);
        }

        var sum = 0;
        for (var i = firstValues.Count - 1; i >= 0; i--)
            sum = firstValues[i] - sum;

        return sum;
    }
}
