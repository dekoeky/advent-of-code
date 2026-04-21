using System.Text.RegularExpressions;

namespace advent_of_code._2018.Day07;

internal partial record Instruction(char Before, char After)
{
    [GeneratedRegex("Step (?<before>[A-Z]) must be finished before step (?<after>[A-Z]) can begin\\.")]
    private static partial Regex Rgx { get; }

    public static IEnumerable<Instruction> ParseMany(string input)
    {
        foreach (Match match in Rgx.Matches(input))
        {
            var before = match.Groups["before"].Value[0];
            var after = match.Groups["after"].Value[0];

            yield return new Instruction(before, after);
        }
    }
}