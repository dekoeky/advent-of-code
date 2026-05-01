namespace AdventOfCode._2016.Day16;

internal static class Calculations
{
    public static string Execute(string initialState, int length)
    {
        var state = initialState;
        while (state.Length < length)
        {
            state = UpdateState(state);
            Debug.WriteLine($"State: {state}");
        }
        return CheckSum(state.Substring(0, length));
    }

    private static string UpdateState(string input)
    {
        var l = input.Length * 2 + 1;
        char[] chars = new char[l];

        input.CopyTo(chars);
        chars[input.Length] = '0';

        for (var i = 0; i < input.Length; i++)
            chars[l - 1 - i] = input[i] == '1' ? '0' : '1';

        return new string(chars);
    }

    private static string CheckSum(string input)
    {
        string checksum = input;
        do
        {
            checksum = DoCheckSum(checksum);
            Debug.WriteLine($"Checksum: {checksum}");
        } while (checksum.Length % 2 == 0);

        return checksum;
    }

    private static string DoCheckSum(string input)
    {
        var l = input.Length / 2;

        var chars = new char[l];
        Array.Fill(chars, '0');

        for (var i = 0; i < l; i++)
        {
            chars[i] = input[i * 2] == input[i * 2 + 1] ? '1' : '0';
        }

        return new string(chars);
    }
}