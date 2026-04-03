using advent_of_code.Helpers;

namespace advent_of_code._2023.Day05;

internal class Almanac
{
    public List<long> Seeds { get; set; } = [];
    public List<MappingGroup> MappingGroups { get; set; } = [];

    public static Almanac Parse(string input)
    {
        var parts = SplitOn.EmptyLines(input);

        return new Almanac
        {
            Seeds = [.. parts[0].Split(' ').Skip(1).Select(long.Parse)],
            MappingGroups = [.. parts.Skip(1).Select(MappingGroup.Parse)]
        };
    }
}

class MappingGroup
{
    public string From { get; set; }
    public string To { get; set; }
    public Mapping[] MappingRanges { get; set; }

    public long Map(long input)
    {
        foreach (var mapping in MappingRanges)
            if (mapping.IsInSourceRange(input))
                return mapping.Map(input);

        //Any source numbers that aren't mapped correspond to the same destination number.
        //So, seed number 10 corresponds to soil number 10.
        return input;
    }

    public static MappingGroup Parse(string input)
    {
        var lines = SplitOn.NewLines(input);

        string[] separators = ["-to-", " "];
        var parts = lines[0].Split(separators, StringSplitOptions.RemoveEmptyEntries);
        var from = parts[0];
        var to = parts[1];

        return new MappingGroup
        {
            From = from,
            To = to,
            MappingRanges = [.. lines.Skip(1).Select(Mapping.Parse)],
        };
    }
}