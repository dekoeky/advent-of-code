namespace AdventOfCode._2020.Day10;

internal static partial class Calculations
{
    public static long Part1(ReadOnlySpan<char> input)
    {
        Span<int> values = stackalloc int[200];
        var count = ParseValues(input, values);

        var last = 0;

        var counts = Enumerable.Range(1, 3).ToDictionary(diff => diff, _ => 0);

        foreach (var value in values[..count])
        {
            var diff = value - last;
            counts[diff]++;
            last = value;
        }

        // Handle last adapter
        counts[3]++;

        return counts[1] * counts[3];
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        // Parse ints into a stackalloc buffer first
        Span<int> values = stackalloc int[200];
        var count = ParseValues(input, values);

        // Add charging outlet (0) and device (max+3)
        // Shift right by 1 to insert 0 at index 0
        for (var i = count; i > 0; i--)
            values[i] = values[i - 1];

        values[0] = 0;
        values[count + 1] = values[count] + 3;
        count += 2;

        // ways[i] = number of ways to reach the end from i
        Span<long> ways = stackalloc long[count];
        ways[count - 1] = 1; // last element has exactly 1 way

        for (var i = count - 2; i >= 0; i--)
        {
            long w = 0;
            var current = values[i];

            // Check next 3 adapters
            for (var j = i + 1; j < count && values[j] - current <= 3; j++)
                w += ways[j];

            ways[i] = w;
        }

        return ways[0];
    }

    private static int ParseValues(ReadOnlySpan<char> input, Span<int> values)
    {
        var count = 0;

        foreach (var line in input.EnumerateLines())
            values[count++] = int.Parse(line);

        // Sort only the used portion
        values[..count].Sort();

        return count;
    }

}