using System.Text;

namespace advent_of_code.Helpers;

public static class CharArray
{
    public static string ToString(char[,] characters)
    {
        var rows = characters.GetLength(0);
        var columns = characters.GetLength(1);

        var sb = new StringBuilder();

        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < columns; c++)
            {
                sb.Append(characters[r, c]);
            }

            // Don't add a newline for the last row
            if (r == rows - 1) break;

            sb.AppendLine();
        }

        return sb.ToString();
    }
}