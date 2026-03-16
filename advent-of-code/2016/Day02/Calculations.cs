using System.Text;

namespace advent_of_code._2016.Day02;

internal static class Calculations
{
    public static string FindBathroomCode(string input, char[,] keypad, char startKey)
    {
        Debug.WriteLine("Keypad:");
        Debug.WriteLine(Keypad.ToString(keypad));
        Debug.WriteLine();

        var (row, col) = GetStartPosition(keypad, startKey);

        var code = new StringBuilder();

        foreach (var line in input.EnumerateLines())
        {
            foreach (var move in line)
            {
                // Store the current position, in case we need to revert
                var previous = (row, col);

                // Apply the move specified in the instruction
                switch (move)
                {
                    case 'U': row = Math.Max(row - 1, 0); break;
                    case 'D': row = Math.Min(row + 1, keypad.GetLength(0) - 1); break;
                    case 'L': col = Math.Max(col - 1, 0); break;
                    case 'R': col = Math.Min(col + 1, keypad.GetLength(1) - 1); break;
                    default: throw new InvalidOperationException();
                }

                // Restore the previous position, if the last move ended on a non existing key
                if (keypad[row, col] == default)
                    (row, col) = previous;
            }

            // We stopped at this location, enter the the code
            code.Append(keypad[row, col]);
        }

        return code.ToString();
    }

    private static (int Row, int Col) GetStartPosition(char[,] keypad, char key)
    {
        for (var r = 0; r < keypad.GetLength(0); r++)
            for (var c = 0; c < keypad.GetLength(1); c++)
                if (keypad[r, c] == key)
                    return (r, c);

        throw new InvalidOperationException($"The keypad does not contain key {key}");
    }
}
