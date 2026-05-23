namespace advent_of_code._2024.Day11;

internal static class Calculations
{
    public static long Part1(ReadOnlySpan<char> input, int n = 25) => Execute(input, n);

    public static long Part2(ReadOnlySpan<char> input, int n = 75) => Execute(input, n);

    private static long Execute(ReadOnlySpan<char> input, int n)
    {
        var counts = Parse(input);

        for (var i = 0; i < n; i++)
            counts = Expand(counts);

        return counts.Values.Sum();
    }

    private static Dictionary<long, long> Expand(Dictionary<long, long> counts)
    {
        var newCounts = new Dictionary<long, long>(counts.Count * 2);

        foreach (var (value, count) in counts)
            if (value == 0)
            {
                newCounts.IncreaseValue(1, count);
            }
            else if (TrySplit(value, out var upper, out var lower))
            {
                newCounts.IncreaseValue(upper, count);
                newCounts.IncreaseValue(lower, count);
            }
            else
            {
                newCounts.IncreaseValue(value * 2024, count);
            }

        return newCounts;
    }

    private static bool TrySplit(long value, out long upper, out long lower)
    {
        upper = lower = 0;

        var n = CountDigits(value);

        if (n % 2 != 0) return false;

        var order = (int)Math.Pow(10, n / 2);
        upper = value / order;
        lower = value - upper * order;

        return true;
    }

    private static int CountDigits(long value)
    {
        var n = 0;

        while (value > 0)
        {
            n++;
            value /= 10;
        }

        return n;
    }

    private static Dictionary<long, long> Parse(ReadOnlySpan<char> input)
    {
        var counts = new Dictionary<long, long>();

        while (true)
        {
            var i = input.IndexOf(' ');

            var numberInput = i == -1
                ? input
                : input[..i];

            var value = int.Parse(numberInput);

            counts[value] = counts.TryGetValue(value, out var count)
                ? ++count
                : 1;

            if (input.Length <= numberInput.Length)
                break;

            input = input[++i..];
        }

        return counts;
    }
}
