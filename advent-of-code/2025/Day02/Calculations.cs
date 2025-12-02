using System.Diagnostics;

namespace advent_of_code._2025.Day02;

internal static class Calculations
{
    public static long SumOfInvalidIds(string ranges) =>
        SumOfInvalidIds(IdRanges.Parse(ranges));

    public static long SumOfInvalidIds(IEnumerable<IdRange> ranges)
    {
        var sum = 0L;
        foreach (var range in ranges)
        {
            var invalids = range.GetInvalidNumbers().ToList();

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