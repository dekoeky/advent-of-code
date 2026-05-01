using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day21.Operations;

internal sealed partial record RotateStepsOperation(bool Left, int Steps) : Operation
{
    [GeneratedRegex(@"^rotate (?<dir>left|right) (?<steps>\d+) steps?$")]
    private static partial Regex RotateStepsRegex();

    internal static bool TryParse(string input, [NotNullWhen(true)] out Operation? op)
    {
        var m = RotateStepsRegex().Match(input);
        if (!m.Success)
        {
            op = null;
            return false;
        }

        op = new RotateStepsOperation(
            m.Groups["dir"].Value == "left",
            int.Parse(m.Groups["steps"].Value)
        );
        return true;
    }

    public override void Apply(Span<char> password) => Apply(password, Steps, Left);

    public static void Apply(Span<char> password, int steps, bool left)
    {
        var l = password.Length;

        // No use in rotating full circles...
        steps = steps % l;

        // No use in rotating 0 steps --> just do nothing
        if (steps == 0) return;

        Span<char> temp = stackalloc char[steps];

        if (left)
        {
            // Store the part that falls of the left end
            password[..steps].CopyTo(temp);

            // Shift the right characters to the left
            for (var i = 0; i < l - steps; i++)
                password[i] = password[i + steps];

            // Append the stored part to the right end
            for (var i = 0; i < temp.Length; i++)
                password[i + l - steps] = temp[i];
        }
        else
        {
            // Store the part that falls of the right end
            password.Slice(l - steps, steps).CopyTo(temp);

            // Shift the left characters to the right
            for (var i = l - 1; i >= steps; i--)
                password[i] = password[i - steps];

            // Append the stored part to the left end
            temp.CopyTo(password);
        }
    }

    public override void Revert(Span<char> scrambled) => Apply(scrambled, Steps, !Left);
}
