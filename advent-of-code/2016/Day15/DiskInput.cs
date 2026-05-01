using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day15;

internal partial record DiskInput(int Positions, int PositionAtT0)
{
    private static readonly Regex Regex = GetRegex();

    [GeneratedRegex("^Disc #(?<disc>\\d+) has (?<positions>\\d+) positions; at time=(?<time>\\d+), it is at position (?<start>\\d+)\\.$")]
    internal static partial Regex GetRegex();

    public static DiskInput Parse(string input)
    {
        var match = Regex.Match(input);

        var disc = int.Parse(match.Groups["disc"].Value);
        var positions = int.Parse(match.Groups["positions"].Value);
        var time = int.Parse(match.Groups["time"].Value);
        var start = int.Parse(match.Groups["start"].Value);

        if (time != 0) throw new InvalidOperationException();

        return new DiskInput(positions, start);
    }
}
