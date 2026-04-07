using advent_of_code.Helpers;

namespace advent_of_code._2023.Day05;

internal static class Calculations
{
    public static (long[] seedNumbers, List<List<MapRange>> maps) ParseInput(string input)
    {
        var blocks = SplitOn.EmptyLines(input);

        string seedLine = blocks[0];
        var nums = seedLine
          .Split(':')[1]
          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
          .Select(long.Parse)
          .ToArray();

        var allMaps = new List<List<MapRange>>();

        foreach (var block in blocks.Skip(1))
        {
            var lines = block.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                             .Skip(1); // skip header

            var ranges = new List<MapRange>();
            foreach (var line in lines)
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                long dest = long.Parse(parts[0]);
                long src = long.Parse(parts[1]);
                long len = long.Parse(parts[2]);
                ranges.Add(new MapRange(src, dest, len));
            }

            allMaps.Add(ranges);
        }

        return (nums, allMaps);
    }

    public static long Part1(string input)
    {
        var (seeds, allMaps) = ParseInput(input);
        long best = long.MaxValue;

        foreach (var seed in seeds)
        {
            long value = seed;
            foreach (var map in allMaps)
                value = ApplyMap(value, map);

            if (value < best)
                best = value;
        }

        return best;
    }

    private static long ApplyMap(long value, List<MapRange> map)
    {
        foreach (var (src, dest, len) in map)
            if (value >= src && value < src + len)
                return dest + (value - src);

        return value;
    }

    public static long Part2(string input)
    {
        var (nums, allMaps) = ParseInput(input);
        var intervals = new List<Range>();
        for (int i = 0; i < nums.Length; i += 2)
        {
            long start = nums[i];
            long len = nums[i + 1];
            intervals.Add(new Range(start, start + len));
        }

        foreach (var map in allMaps)
            intervals = ApplyMap(intervals, map);

        return intervals.Min(r => r.Start);
    }

    static List<Range> ApplyMap(List<Range> intervals, List<MapRange> map)
    {
        var result = new List<Range>();

        foreach (var (start, end) in intervals)
        {
            var pending = new List<Range> { new Range(start, end) };
            var mapped = new List<Range>();

            foreach (var (src, dest, len) in map)
            {
                var srcL = src;
                var srcR = src + len;

                var nextPending = new List<Range>();

                foreach (var (pStart, pEnd) in pending)
                {
                    var l = Math.Max(pStart, srcL);
                    var r = Math.Min(pEnd, srcR);

                    if (l < r)
                    {
                        var mappedL = dest + (l - srcL);
                        var mappedR = dest + (r - srcL);
                        mapped.Add(new Range(mappedL, mappedR));

                        if (pStart < l)
                            nextPending.Add(new Range(pStart, l));

                        if (r < pEnd)
                            nextPending.Add(new Range(r, pEnd));
                    }
                    else
                    {
                        nextPending.Add(new Range(pStart, pEnd));
                    }
                }

                pending = nextPending;
            }

            result.AddRange(mapped);
            result.AddRange(pending);
        }

        return result;
    }
}