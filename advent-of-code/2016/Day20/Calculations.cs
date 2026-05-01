using IP = System.UInt32;


namespace AdventOfCode._2016.Day20;

internal static class Calculations
{
    /// <summary>
    /// Calculate the lowest ip that is not blacklisted.
    /// </summary>
    public static IP LowestValidIP(string input)
    {
        var blacklist = Parse(input);

        IP lowest = 0;
        foreach (var (start, end) in blacklist)
            if (lowest < start)
            {
                Debug.WriteLine($"ip {lowest} is below range {start}-{end}");
                return lowest;
            }
            else if (lowest < end)
            {

                lowest = end + 1;
                Debug.WriteLine($"ip {lowest} is inside {start}-{end}, next valid candidate is {lowest}");
            }

        return lowest;
    }

    /// <summary>
    /// Calculate the number of valid (non-blacklisted) ips, with the default ip range.
    /// </summary>
    public static ulong ValidIps(string input) => ValidIps(input, (IP.MinValue, IP.MaxValue));

    /// <summary>
    /// Calculate the number of valid (non-blacklisted) ips, with the given ip range.
    /// </summary>
    public static ulong ValidIps(string input, (IP Min, IP Max) ipRange)
    {
        var blacklist = Parse(input);

        Merge(blacklist);

        // Get the amount of ips in the full IP range
        var range = GetRange(ipRange);

        // For each (non-overlapping) blacklist range, count how many ips are excluded
        var blacklisted = blacklist.Sum(GetRange);

        // The number of valid ips is the full range of ips - blacklisted
        var validIps = range - blacklisted;

        Debug.WriteLine($"IP Range:          {ipRange.Min,10}-{ipRange.Max,10} (# {range})");
        Debug.WriteLine($"BlackListed Range: {blacklisted}");
        Debug.WriteLine($"Allowed Range:     {validIps}");

        return validIps;
    }

    /// <summary>
    /// Merges all overlapping ranges inside the blacklist.
    /// </summary>
    private static void Merge(List<(IP Start, IP End)> blacklist)
    {
        // Assuming ordering happened before

        var i = 0;
        while (i < blacklist.Count - 1)
        {
            var current = blacklist[i];
            var next = blacklist[i + 1];
            var overlap = next.Start <= current.End;

            // If no overlap, we can skip this range (keep it included)
            if (!overlap)
            {
                i++;
                continue;
            }

            // Merge by taking the first start, and the last end
            var merged = (Start: Math.Min(current.Start, next.Start), End: Math.Max(current.End, next.End));

            // Overwrite the current index, remove the next (i and i+1 merged into i)
            blacklist[i] = merged;
            blacklist.RemoveAt(i + 1);
            Debug.WriteLine($"merged ({current.Start}-{current.End}) and ({next.Start}-{next.End}) into ({merged.Start}-{merged.End})");

            // do not increase i, because we want to check the merged range again with the next range
        }
    }

    private static ulong GetRange((IP Min, IP Max) validRange)
    {
        // The range of valid values for this datatype is the MAX - MIN +1
        // Because a range of 0 inclusive -> 3 inclusive has 4 valid values: 0, 1, 2, 3

        // Since theoretically the COUNT of the full range of IP datatype cant be stored in IP datatype,
        // we cast to a larger data type, just to be sure the count fits.

        return validRange.Max - validRange.Min + 1ul;
    }

    /// <summary>
    /// Parses the given input to a blacklist, which is a list of blacklisted ranges, sorted by start.
    /// </summary>
    private static List<(uint Start, uint End)> Parse(string input)
        => [.. SplitOn.NewLines(input).Select(line =>
        {
            var parts = line.Split('-');
            return (Start: IP.Parse(parts[0]), End: IP.Parse(parts[1]));
        }).OrderBy(r=>r.Start)];
}
