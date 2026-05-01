using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day21.Operations;

internal sealed partial record MovePositionOperation(int From, int To) : Operation
{
    [GeneratedRegex(@"^move position (?<from>\d+) to position (?<to>\d+)$")]
    private static partial Regex MovePositionRegex();

    internal static bool TryParse(string input, [NotNullWhen(true)] out Operation? op)
    {
        var m = MovePositionRegex().Match(input);
        if (!m.Success)
        {
            op = null;
            return false;
        }

        op = new MovePositionOperation(
            int.Parse(m.Groups["from"].Value),
            int.Parse(m.Groups["to"].Value)
        );
        return true;
    }

    public static void Apply(Span<char> password, int from, int to)
    {
        if (from == to) return;

        var l = password.Length;
        Span<char> temp = stackalloc char[l];
        var dummy = password[from];
        password.CopyTo(temp);

        if (from > to)
        {
            //    ---->
            // 01(2)34[5]6789
            // Move index 5 to 2

            for (var i = from; i > to; i--)
                password[i] = password[i - 1];

            password[to] = dummy;
        }
        else
        {
            //    <----
            // 01[2]34(5)6789
            // Move index 2 to 5

            for (var i = from; i < to; i++)
                password[i] = password[i + 1];

            password[to] = dummy;
        }
    }

    public override void Apply(Span<char> password) => Apply(password, From, To);

    public override void Revert(Span<char> scrambled) => Apply(scrambled, To, From);
}