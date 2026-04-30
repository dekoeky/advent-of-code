using System.Numerics;

namespace advent_of_code._2021.Day06;

internal static class Calculations
{
    public static long CountTotalFish(ReadOnlySpan<char> input, int days)
    {
        // Holds the amount of fish (value), per internal timer count (index)
        // Using long datatype, because we expect many fish!
        var internalTimerCounts = ParseCounts<long>(input);

        for (var day = 0; day < days; day++)
        {
            var newFish = internalTimerCounts[0];

            // Decrement internal timers of all fish, by rotating the counts left
            RotateLeft(internalTimerCounts);

            // Create the number of new fish, with internal timer of 8
            internalTimerCounts[8] = newFish;

            // The fish that spawned new fish, are now internal timer of 6
            internalTimerCounts[6] += newFish;
        }

        return internalTimerCounts.Sum();
    }

    /// <remarks>Index 0 is overwritten.</remarks>
    public static void RotateLeft<T>(Span<T> span)
    {
        for (var i = 0; i < span.Length - 1; i++)
            span[i] = span[i + 1];
    }

    private static T[] ParseCounts<T>(ReadOnlySpan<char> input)
        where T : struct, INumberBase<T>
    {
        var counts = new T[9]; // 0, 1, 2, 3, 4, 5, 6, 7, 8 ==> So 9 large

        foreach (var r in input.Split(','))
        {
            var i = int.Parse(input[r]);
            counts[i] = counts[i] + T.One;
        }
        return counts;
    }
}