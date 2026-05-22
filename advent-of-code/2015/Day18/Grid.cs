namespace advent_of_code._2015.Day18;

internal static class Grid
{
    public static char[,] Parse(string input)
    {
        var lines = SplitOn.NewLines(input);
        var ROWS = lines.Length;
        var COLS = lines[0].Length;
        var result = new char[ROWS, COLS];

        for (var r = 0; r < lines.Length; r++)
            for (var c = 0; c < lines[r].Length; c++)
                result[r, c] = lines[r][c];

        return result;
    }

    private static readonly (int dRow, int dCol)[] NeighborOffsets =
    [
        (-1, -1), (-1, 0), (-1, 1),
        ( 0, -1),          ( 0, 1),
        ( 1, -1), ( 1, 0), ( 1, 1),
    ];

    public static IEnumerable<T> GetNeighbors<T>(this T[,] grid, int row, int col)
    {
        int rowCount = grid.GetLength(0);
        int colCount = grid.GetLength(1);

        foreach (var (dRow, dCol) in NeighborOffsets)
        {
            int r = row + dRow;
            int c = col + dCol;

            if ((uint)r < (uint)rowCount && (uint)c < (uint)colCount)
                yield return grid[r, c];
        }
    }

    public static int CountNeighbors<T>(this T[,] grid, int row, int col, Func<T, bool> f)
    {
        int count = 0;
        int rowCount = grid.GetLength(0);
        int colCount = grid.GetLength(1);

        foreach (var (dRow, dCol) in NeighborOffsets)
        {
            int r = row + dRow;
            int c = col + dCol;

            if ((uint)r < (uint)rowCount && (uint)c < (uint)colCount && f(grid[r, c]))
                count++;
        }

        return count;
    }

    public static int Count<T>(this T[,] grid, Func<T, bool> f)
    {
        int count = 0;

        for (var r = 0; r < grid.GetLength(0); r++)
            for (var c = 0; c < grid.GetLength(1); c++)
                if (f(grid[r, c])) count++;

        return count;
    }

    public static void WriteCorners<T>(this T[,] grid, T value)
    {
        // ASSUME at least 2 rows, 2 cols
        var R = grid.GetLength(0) - 1;
        var C = grid.GetLength(1) - 1;

        grid[0, 0] = value;
        grid[R, 0] = value;
        grid[0, C] = value;
        grid[R, C] = value;
    }

    public static void PrintDebug(this char[,] grid, int indent = 4)
    {
        for (var r = 0; r < grid.GetLength(0); r++)
        {
            for (var i = 0; i < indent; i++) Debug.Write(' ');

            for (var c = 0; c < grid.GetLength(1); c++)
                Debug.Write(grid[r, c]);

            Debug.WriteLine();
        }
        Debug.WriteLine();
    }
}