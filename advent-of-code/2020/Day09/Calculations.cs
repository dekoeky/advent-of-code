namespace advent_of_code._2020.Day09;

internal static partial class Calculations
{
    public static long Part1(ReadOnlySpan<char> input, int preambleSize)
        => Part1(Parse(input), preambleSize);

    private static long Part1(long[] data, int preambleSize)
    {
        for (var i = preambleSize; i < data.Length; i++)
        {
            var sum = data[i];
            var preamble = data.AsSpan(i - preambleSize, preambleSize);
            if (!IsValidSumOfTwoValues(sum, preamble))
                return sum;
        }

        throw new InvalidOperationException("Solution not found");
    }

    private static bool IsValidSumOfTwoValues(long sum, ReadOnlySpan<long> values)
    {
        for (var i = 0; i < values.Length; i++)
            for (var j = i + 1; j < values.Length; j++)
                if (values[i] + values[j] == sum)
                    return true;

        return false;
    }

    private static long[] Parse(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var i = 0;
        var data = new long[n];
        foreach (var line in input.EnumerateLines())
            data[i++] = long.Parse(line);
        return data;
    }

    public static long Part2(ReadOnlySpan<char> input, int preambleSize)
    {
        var data = Parse(input);
        var invalid = Part1(data, preambleSize);
        var cr = FindContiguousSet(data, invalid);
        return MinPlusMaxValue(cr);
    }

    private static Span<long> FindContiguousSet(long[] data, long invalid)
    {
        var invalidIndex = data.IndexOf(invalid);

        // There indices, and length, specify a range of
        // the contiguous set of numbers we are currently checking
        var start = invalidIndex - 2;   // Inclusive Index
        var end = invalidIndex;         // Exclusive Index
        var len = 2;

        // This value will always contain the sum of values for the
        // contiguous set we are inspecting
        var sum = data[invalidIndex - 1]
            + data[invalidIndex - 2];

        // We keep adjusting our range, untill the sum matches
        while (sum != invalid)
            // If the sum is too large, we remove a digit from the right side
            // But only if the length of the cr is longer than one
            if (sum > invalid && len > 1)
            {
                end--;
                len--;
                sum -= data[end];
            }

            // If the sum is too small, we add a digit on the left side
            else
            {
                start--;
                len++;
                sum += data[start];
            }

        // We return the contiguous region
        return data.AsSpan(new Range(start, end));
    }

    private static long MinPlusMaxValue(Span<long> values)
    {
        var min = long.MaxValue;
        var max = long.MinValue;

        for (var i = 0; i < values.Length; i++)
        {
            min = Math.Min(min, values[i]);
            max = Math.Max(max, values[i]);
        }

        return min + max;
    }
}