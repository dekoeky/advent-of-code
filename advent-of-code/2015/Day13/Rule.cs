using System.Text.RegularExpressions;

namespace AdventOfCode._2015.Day13;

partial record Rule(string Name, int HappinessGain, string Neighbor)
{

    [GeneratedRegex("^([A-Za-z]+)\\s+would\\s+(gain|lose)\\s+(\\d+)\\s+happiness units by sitting next to\\s+([A-Za-z]+)\\.$")]
    private static partial Regex CreateRegex();

    private static readonly Regex regex = CreateRegex();

    public static Rule Parse(string input)
    {
        var m = regex.Match(input);

        var left = m.Groups[1].Value;
        var isGain = m.Groups[2].Value == "gain";
        var amount = int.Parse(m.Groups[3].Value);
        var happinessGain = isGain ? amount : -amount;
        var neighbor = m.Groups[4].Value;

        return new Rule(left, happinessGain, neighbor);
    }

    public string ToParsableString() => $"{Name} would {(HappinessGain >= 0 ? "gain" : "lose")} {Math.Abs(HappinessGain)} happiness units by sitting next to {Neighbor}";

    public string GetApplicableText() => HappinessGain > 0
            ? $"{Name} gains {HappinessGain} because he/she sits next to {Neighbor}"
            : $"{Name} loses {-HappinessGain} because he/she sits next to {Neighbor}";
}