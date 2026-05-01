namespace AdventOfCode._2020.Day02;

internal readonly record struct PasswordPolicy(int A, int B, char Character)
{
    public static PasswordPolicy Parse(ReadOnlySpan<char> input)
    {
        var dash = input.IndexOf('-');
        var min = int.Parse(input[..dash]);

        var space = input.IndexOf(' ');
        var max = int.Parse(input[new Range(dash + 1, space)]);

        var character = input[space + 1];

        return new PasswordPolicy(min, max, character);
    }

    public readonly bool ValidatePart1(ReadOnlySpan<char> password)
    {
        // Parameters A and B specify a Min and Max count for the specified character

        var count = password.Count(Character);

        return count >= A && count <= B;
    }

    public readonly bool ValidatePart2(ReadOnlySpan<char> password)
    {
        // Parameters A and B are (one-based) indices
        // Exactly one of these indices should contain the specified character

        var a = password[A - 1] == Character;
        var b = password[B - 1] == Character;

        return a ^ b;
    }
}
