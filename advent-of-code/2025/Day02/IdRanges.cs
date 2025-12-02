namespace advent_of_code._2025.Day02;

internal static class IdRanges
{
    public static IEnumerable<IdRange> Parse(string s)
    {
        var parts = s.Split(Constants.RangeSplitter);

        foreach (var part in parts)
            yield return IdRange.Parse(part);
    }
}