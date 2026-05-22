namespace advent_of_code._2020.Day02;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
        => CountValidPasswords(input, (policy, password) => policy.ValidatePart1(password));

    public static int Part2(ReadOnlySpan<char> input)
        => CountValidPasswords(input, (policy, password) => policy.ValidatePart2(password));

    private static int CountValidPasswords(ReadOnlySpan<char> input, Func<PasswordPolicy, ReadOnlySpan<char>, bool> validate)
    {
        var valid = 0;

        foreach (var line in input.EnumerateLines())
        {
            var semicolon = line.IndexOf(':');

            var policy = PasswordPolicy.Parse(line[..semicolon]);
            var password = line[(semicolon + 2)..];

            if (validate(policy, password))
                valid++;
        }

        return valid;
    }
}