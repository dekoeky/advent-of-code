using System.Text;

namespace advent_of_code._2016.Day02;

internal static class Keypad
{
    public static readonly char[,] Simple = Parse(
        """
        1 2 3
        4 5 6
        7 8 9
        """);

    //    {
    //    { '1', '2', '3' },
    //    { '4', '5', '6' },
    //    { '7', '8', '9' },
    //};

    public static readonly char[,] Advanced = Parse(
        """
            1
          2 3 4
        5 6 7 8 9
          A B C
            D
        """);

    public static char[,] Parse(string input)
    {
        // Assume keys of one digit/letter

        var lines = SplitOn.NewLines(input);
        var rows = lines.Length;
        var longestRowLength = lines.Max(l => l.Length);
        var cols = (longestRowLength + 1) / 2;

        var keypad = new char[rows, cols];

        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
            {
                var line = lines[r].PadRight(longestRowLength, ' ');
                if (line[c * 2] is { } key && key is not ' ')
                    keypad[r, c] = key;
            }

        return keypad;
    }

    public static string ToString(char[,] keypad)
    {
        var sb = new StringBuilder();

        for (var r = 0; r < keypad.GetLength(0); r++)
            for (var c = 0; c < keypad.GetLength(1); c++)
                sb.Append(keypad[r, c] == default ? ' ' : keypad[r, c]);

        return sb.ToString();
    }
}
