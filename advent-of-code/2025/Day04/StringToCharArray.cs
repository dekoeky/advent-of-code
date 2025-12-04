namespace advent_of_code._2025.Day04;

public static class StringToCharArray
{
    public static char[,] To2DArray(this string input) => To2DArray((ReadOnlySpan<char>)input);
    public static char[,] To2DArray(this ReadOnlySpan<char> input)
    {
        GetSize(input, out var rows, out var cols);

        var data = new char[rows, cols];
        var i = 0;
        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
            {
                while (input[i] is '\r' or '\n')
                    i++;

                data[r, c] = input[i++];
            }

        return data;
    }

    private static void GetSize(ReadOnlySpan<char> input, out int rows, out int cols)
    {
        rows = 1;
        cols = 0;

        foreach (var ch in input)
            if (ch is '\r' or '\n')
            {
                // in case of CR LF, the LF is ignored
                if (cols == 0) continue;

                // Increase the amount of rows, assuming each row has data
                rows++;

                // Reset the column count, to indicate a new line has just started.
                // The last row will indicate the column count
                cols = 0;
            }
            else
            {
                cols++;
            }
    }
}