using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day21.Operations;

internal sealed partial record SwapLetterOperation(char A, char B) : Operation
{
    [GeneratedRegex(@"^swap letter (?<a>[a-z]) with letter (?<b>[a-z])$")]
    private static partial Regex SwapLetterRegex();

    internal static bool TryParse(string input, [NotNullWhen(true)] out Operation? op)
    {
        var m = SwapLetterRegex().Match(input);
        if (!m.Success)
        {
            op = null;
            return false;
        }

        op = new SwapLetterOperation(
            m.Groups["a"].Value[0],
            m.Groups["b"].Value[0]
        );
        return true;
    }

    public override void Apply(Span<char> password)
    {
        for (int i = 0; i < password.Length; i++)
            if (password[i] == A)
                password[i] = B;
            else if (password[i] == B)
                password[i] = A;
    }

    public override void Revert(Span<char> scrambled) => Apply(scrambled);
}
