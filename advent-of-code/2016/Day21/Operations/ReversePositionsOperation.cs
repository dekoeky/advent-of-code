using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day21.Operations;

internal sealed partial record ReversePositionsOperation(int X, int Y) : Operation
{
    [GeneratedRegex(@"^reverse positions (?<x>\d+) through (?<y>\d+)$")]
    private static partial Regex ReversePositionsRegex();

    internal static bool TryParse(string input, [NotNullWhen(true)] out Operation? op)
    {
        var m = ReversePositionsRegex().Match(input);
        if (!m.Success)
        {
            op = null;
            return false;
        }

        op = new ReversePositionsOperation(
            int.Parse(m.Groups["x"].Value),
            int.Parse(m.Groups["y"].Value)
        );
        return true;
    }

    public override void Apply(Span<char> password)
    {
        var n = Y - X + 1;
        Span<char> temp = stackalloc char[n];

        password.Slice(X, n).CopyTo(temp);
        temp.Reverse();
        temp.CopyTo(password.Slice(X, n));
    }
    public override void Revert(Span<char> scrambled) => Apply(scrambled);
}
