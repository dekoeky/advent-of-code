namespace advent_of_code._2021.Day01;

internal static class Calculations
{
    public static int Part1(int[] input)
    {
        var count = 0;

        for (int i = 1; i < input.Length; i++)
            if (input[i] > input[i - 1])
                count++;

        return count;
    }

    public static int Part2(int[] input, int n = 3)
    {
        if (n >= input.Length) return 0;

        var count = 0;

        var previousSum = input.Take(n).Sum();

        for (int i = 3; i < input.Length; i++)
        {
            var newSum = previousSum
                + input[i]          // Add the newest value
                - input[i - 3];     // Remove the oldest value

            // Count if the sum increased
            if (newSum > previousSum)
                count++;

            // Store the sum for next check
            previousSum = newSum;
        }

        return count;
    }
}