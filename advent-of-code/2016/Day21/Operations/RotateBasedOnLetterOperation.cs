using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day21.Operations;

internal sealed partial record RotateBasedOnLetterOperation(char Letter) : Operation
{
    [GeneratedRegex(@"^rotate based on position of letter (?<c>[a-z])$")]
    private static partial Regex RotateBasedOnLetterRegex();

    internal static bool TryParse(string input, [NotNullWhen(true)] out Operation? op)
    {
        var m = RotateBasedOnLetterRegex().Match(input);
        if (!m.Success)
        {
            op = null;
            return false;
        }

        op = new RotateBasedOnLetterOperation(
            m.Groups["c"].Value[0]
        );
        return true;
    }

    public override void Apply(Span<char> password)
    {
        var index = password.IndexOf(Letter);

        // If Letter not found --> do nothing
        if (index == -1) return;

        // If Letter found in first 5 characters --> rotate right 1 + index = rotate right 1-
        var steps = 1 + index;

        // If Letter found after first 5 characters -> rotate right 1 + index + 1 = rotate right 6-...
        if (index >= 4) steps++;

        //Debug.WriteLine($"(rotate right {steps})");
        RotateStepsOperation.Apply(password, steps, false);
    }

    public override void Revert(Span<char> scrambled)
    {
        if (scrambled.Contains(Letter) == false) return;

        var l = scrambled.Length;
        Span<char> temp = stackalloc char[l];
        Span<char> x = stackalloc char[l];

        // Try each N moves left
        for (var i = 0; i < l; i++)
        {
            // Start with the scrambled output (our method input)
            scrambled.CopyTo(temp);

            // Rotate it left i steps, hoping this was the input of our Apply step
            RotateStepsOperation.Apply(temp, i, true);

            // Store for if this is a winner
            temp.CopyTo(x);

            // Apply this operation, to see if the result is our scrambled input
            Apply(temp);

            // This amount of steps moved did not result in a valid unscrambled input
            if (!temp.SequenceEqual(scrambled))
                continue;

            // Copy the winning 'unscrambled' password into the span, provided to this method
            x.CopyTo(scrambled);
            return;
        }

        throw new InvalidOperationException("Could not find the reverse");
    }
}
