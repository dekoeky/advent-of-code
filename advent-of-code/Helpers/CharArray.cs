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

    extension(char[,] characters)
    {
        public bool TryFind(char match, out int r, out int c)
        {
            for (r = 0; r < characters.GetLength(0); r++)
                for (c = 0; c < characters.GetLength(1); c++)
                    if (characters[r, c] == match)
                        return true;

            r = 0;
            c = 0;
            return false;
        }

        public bool TryFind(char match, out (int r, int c) position)
        {

            for (var r = 0; r < characters.GetLength(0); r++)
                for (var c = 0; c < characters.GetLength(1); c++)
                    if (characters[r, c] == match)
                    {
                        position = (r, c);
                        return true;
                    }

            position = (0, 0);
            return false;
        }

        public int Count(char match)
        {
            var count = 0;
            var rows = characters.GetLength(0);
            var cols = characters.GetLength(1);

            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    if (characters[r, c] == match)
                        count++;

            return count;
        }
    }
}