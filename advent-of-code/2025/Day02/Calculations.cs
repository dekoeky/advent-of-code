using System.Diagnostics;

namespace advent_of_code._2025.Day02;

internal static class Calculations
{
    public static long SumOfInvalidIds(string ranges, NumberValidationDelegate validationFunction) =>
        SumOfInvalidIds(IdRanges.Parse(ranges), validationFunction);

    public static long SumOfInvalidIds(IEnumerable<IdRange> ranges, NumberValidationDelegate validationFunction)
    {
        var sum = 0L;
        foreach (var range in ranges)
        {
            var invalids = range.GetInvalidNumbers(validationFunction).ToList();

            if (invalids.Count > 0)
            {
                Debug.WriteLine($"Range {range} contains invalids:");
                foreach (var invalid in invalids)
                    Debug.WriteLine($"    {invalid}");
            }

            sum += invalids.Sum();
        }

        return sum;
    }
}