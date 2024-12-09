using System.Text;

namespace advent_of_code._2024.Day06;

public static class String2D
{
    public static char[,] StringTo2DArray(string inputString)
    {
        // Split the input string by newline to get each line
        var lines = inputString.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

        // Determine the number of rows and columns
        var rows = lines.Length;
        var cols = lines[0].Length;

        // Create a 2D array to store the characters
        var result = new char[rows, cols];

        // Fill the 2D array with characters from each line
        for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
                result[i, j] = lines[i][j];

        return result;
    }

    public static string Array2DToString(char[,] characters)
    {
        var newlineLength = Environment.NewLine.Length;
        var rows = characters.GetLength(0);
        var cols = characters.GetLength(1);
        var length = characters.Length + (rows - 1) * newlineLength;
        var sb = new StringBuilder(length);

        for (var r = 0; r < rows; r++)
        {
            if (r > 0) sb.Append(Environment.NewLine);
            for (var c = 0; c < cols; c++)
                sb.Append(characters[r, c]);
        }

        return sb.ToString();
    }
}