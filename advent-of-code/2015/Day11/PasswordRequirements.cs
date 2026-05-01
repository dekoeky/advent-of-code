namespace AdventOfCode._2015.Day11;

public static class PasswordRequirements
{
    public static bool IsValid(ReadOnlySpan<char> password)
        => FirstRequirement(password)
        && ThirdRequirement(password)
        && SecondRequirement(password);

    /// <summary>
    /// Passwords must include one increasing straight of at least three letters, like abc, bcd, cde, and so on, up to xyz.
    /// They cannot skip letters; 
    /// abd doesn't count.
    /// </summary>
    public static bool FirstRequirement(ReadOnlySpan<char> input)
    {
        if (input.Length < 3) return false;

        for (int i = 0; i < input.Length - 2; i++)
            if (input[i + 1] - input[i] == 1 && input[i + 2] - input[i] == 2)
                return true;

        return false;
    }

    private static readonly char[] no = ['i', 'o', 'l'];
    const string nono = "iol";

    /// <summary>
    /// Passwords may not contain the letters i, o, or l, as these letters can be mistaken for other characters and are therefore confusing.
    /// </summary>
    public static bool SecondRequirement(ReadOnlySpan<char> input) => !input.ContainsAny(nono);

    /// <summary>
    /// Passwords must contain at least two different, non-overlapping pairs of letters, like aa, bb, or zz.
    /// </summary>
    public static bool ThirdRequirement(ReadOnlySpan<char> input)
    {
        int count = 0;
        char firstPair = '\0';

        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] == input[i + 1])
            {
                char pairChar = input[i];

                // First pair found
                if (count == 0)
                {
                    count = 1;
                    firstPair = pairChar;
                }
                // Second pair must be different
                else if (pairChar != firstPair)
                {
                    return true;
                }

                // Skip the next character to avoid overlap
                i++;
            }
        }

        return false;
    }
}