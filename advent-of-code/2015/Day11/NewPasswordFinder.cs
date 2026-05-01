namespace AdventOfCode._2015.Day11;

internal static class NewPasswordFinder
{
    public static string FindNext(string currentPassword)
    {
        var chars = currentPassword.ToCharArray();

        do
        {
            InCrease(chars);
            //Debug.WriteLine(new string(chars));
        } while (!PasswordRequirements.IsValid(chars));

        return new string(chars); ;
    }

    private static void InCrease(Span<char> chars)
    {

        int index = chars.Length - 1;

        while (++chars[index] > 'z')   // Increase the last letter.
            chars[index--] = 'a';      // If last increase was > 'z', fold it to 'a', and repeat for next letter
    }
}
