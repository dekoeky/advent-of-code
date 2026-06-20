namespace advent_of_code._2020.Day15;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input) => Execute(input, 2020);

    public static int Part2(ReadOnlySpan<char> input) => Execute(input, 30000000);

    private static int Execute(ReadOnlySpan<char> input, int target)
    {
        var start = Parse(input);

        // We need an array large enough to store last-seen positions.
        // Using int[] is fastest and avoids dictionary overhead.
        var last = new int[target];

        int turn = 1;
        int lastSpoken = 0;

        // Initialize starting numbers except the last one
        for (int i = 0; i < start.Length - 1; i++)
        {
            last[start[i]] = turn;
            turn++;
        }

        lastSpoken = start[start.Length - 1];

        // Main loop
        for (; turn < target; turn++)
        {
            int prev = last[lastSpoken];
            last[lastSpoken] = turn;

            lastSpoken = prev == 0 ? 0 : turn - prev;
        }

        return lastSpoken;
    }

    private static int[] Parse(ReadOnlySpan<char> input)
    {
        Span<Range> r = stackalloc Range[10];
        var n = input.Split(r, ',');
        var result = new int[n];
        for (var i = 0; i < n; i++)
            result[i] = int.Parse(input[r[i]]);
        return result;
    }
}
