using System.Text.RegularExpressions;

namespace AdventOfCode._2017.Day20;

internal partial record struct Particle(XYZ P, XYZ V, XYZ A)
{
    [GeneratedRegex(@"<(-?\d+),(-?\d+),(-?\d+)>")]
    static partial Regex Rgx { get; }

    public static Particle Parse(string input)
    {
        var matches = Rgx.Matches(input);

        return new Particle(
            ToXyz(matches[0]),
            ToXyz(matches[1]),
            ToXyz(matches[2])
            );

        static XYZ ToXyz(Match match)
        {
            var x = int.Parse(match.Groups[1].ValueSpan);
            var y = int.Parse(match.Groups[2].ValueSpan);
            var z = int.Parse(match.Groups[3].ValueSpan);

            return new XYZ(x, y, z);
        }
    }
}
