using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day21.Operations;

internal sealed partial record SwapPositionOperation(int X, int Y) : Operation
{
    [GeneratedRegex(@"^swap position (?<x>\d+) with position (?<y>\d+)$")]
    private static partial Regex SwapPositionRegex();

    internal static bool TryParse(string input, [NotNullWhen(true)] out Operation? op)
    {
        var m = SwapPositionRegex().Match(input);
        if (!m.Success)
        {
            op = null;
            return false;
        }

        op = new SwapPositionOperation(
            int.Parse(m.Groups["x"].Value),
            int.Parse(m.Groups["y"].Value)
        );
        return true;
    }

    public override void Apply(Span<char> password)
        => (password[X], password[Y]) = (password[Y], password[X]);

    public override void Revert(Span<char> scrambled) => Apply(scrambled);
}
