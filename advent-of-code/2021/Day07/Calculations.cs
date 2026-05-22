namespace advent_of_code._2021.Day07;

internal static class Calculations
{
    private delegate int CalculateFuel(int target, int current);

    public static int Part1(ReadOnlySpan<char> input) => CalculateMinFuel(input, CalculateCheapFuel);

    public static int Part2(ReadOnlySpan<char> input) => CalculateMinFuel(input, ExpensiveFuelCached);

    private static int CalculateMinFuel(ReadOnlySpan<char> input, CalculateFuel calculateFuel)
    {
        var values = CommaSeparatedNumbers.Parse<int>(input);

        var left = values.Min();
        var right = values.Max();
        (int Position, int TotalFuel) best = (-1, int.MaxValue);

        for (var alignPosition = left; alignPosition < right; alignPosition++)
        {
            var totalFuel = values.Sum(p => calculateFuel(alignPosition, p));

            Debug.WriteLine($"Position: {alignPosition} -> Total Fuel: {totalFuel}");
            if (totalFuel < best.TotalFuel)
                best = (alignPosition, totalFuel);
        }

        return best.TotalFuel;
    }
    private static int CalculateCheapFuel(int alignPosition, int current) => Math.Abs(current - alignPosition);

    private static readonly Dictionary<int, int> CachedFuels = [];

    private static int ExpensiveFuelCached(int target, int current)
    {
        var delta = Math.Abs(target - current);

        if (CachedFuels.TryGetValue(delta, out var fuel))
            return fuel;

        fuel = Enumerable.Range(1, delta).Sum();
        CachedFuels.Add(delta, fuel);

        return fuel;
    }
}