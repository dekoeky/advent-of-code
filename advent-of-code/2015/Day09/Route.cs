using System.Text.RegularExpressions;

namespace AdventOfCode._2015.Day09;

public partial record Route(string From, string To, int Distance)
{
    // 1 = from
    // 2 = to
    // 3 = distance
    [GeneratedRegex(@"^([A-Za-z]+)\s+to\s+([A-Za-z]+)\s+=\s+(\d+)$")]
    private static partial Regex GetRegex();

    private static readonly Regex regex = GetRegex();

    public static Route Parse(string input)
    {
        var match = regex.Match(input);

        var from = match.Groups[1].Value;
        var to = match.Groups[2].Value;
        int distance = int.Parse(match.Groups[3].Value);

        return new Route(from, to, distance);
    }
}