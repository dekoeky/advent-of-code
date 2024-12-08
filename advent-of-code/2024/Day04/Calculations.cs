using System.Drawing;

namespace advent_of_code._2024.Day04;

internal static class Calculations
{
    public static int CountMasCrossings(string input)
    {
        var count = 0;
        var chars = StringTo2DArray(input);
        var rows = chars.GetLength(0);
        var cols = chars.GetLength(1);

        var startPosition = new Point(0, 0);

        for (startPosition.Y = 0; startPosition.Y < rows; startPosition.Y++)
            for (startPosition.X = 0; startPosition.X < cols; startPosition.X++)
            {
                //Find the center letter for starters
                if (chars[startPosition.Y, startPosition.X] != 'A') continue;

                //Cant have a cross around this position
                if (startPosition.Y < 1 || startPosition.Y >= rows - 1) continue;
                if (startPosition.X < 1 || startPosition.X >= cols - 1) continue;


                var topLeft = chars[startPosition.Y - 1, startPosition.X - 1];
                var topRight = chars[startPosition.Y - 1, startPosition.X + 1];
                var botLeft = chars[startPosition.Y + 1, startPosition.X - 1];
                var botRight = chars[startPosition.Y + 1, startPosition.X + 1];

                var a = (topLeft == 'M' && botRight == 'S') || (topLeft == 'S' && botRight == 'M');
                var b = (botLeft == 'M' && topRight == 'S') || (botLeft == 'S' && topRight == 'M');

                if (a && b) count++;
            }

        return count;
    }

    public static int CountOccurances(string input, string wordToSearch)
    {
        var length = wordToSearch.Length;

        var count = 0;
        var chars = StringTo2DArray(input);
        var rows = chars.GetLength(0);
        var cols = chars.GetLength(1);
        char firstLetter = wordToSearch[0];

        var startPosition = new Point(0, 0);

        for (startPosition.Y = 0; startPosition.Y < rows; startPosition.Y++)
            for (startPosition.X = 0; startPosition.X < cols; startPosition.X++)
            {
                //Find the first letter for starters
                if (chars[startPosition.Y, startPosition.X] != firstLetter) continue;

                foreach (var direction in Directions.All)
                    if (Check(startPosition, direction))
                        count++;
            }

        return count;

        bool Check(Point start, Size direction)
        {
            //Start at 1, because first letter has been checked at this point
            for (int i = 1; i < length; i++)
            {
                start += direction;

                if (start.Y < 0 || start.Y >= rows) return false;
                if (start.X < 0 || start.X >= cols) return false;

                if (chars[start.Y, start.X] != wordToSearch[i]) return false;
            }
            return true;
        }
    }


    static char[,] StringTo2DArray(string inputString)
    {
        // Split the input string by newline to get each line
        string[] lines = inputString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        // Determine the number of rows and columns
        int rows = lines.Length;
        int cols = lines[0].Length;

        // Create a 2D array to store the characters
        char[,] result = new char[rows, cols];

        // Fill the 2D array with characters from each line
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = lines[i][j];
            }
        }

        return result;
    }
}
