using advent_of_code.Helpers;

namespace advent_of_code._2017.Day14;

internal static class Calculations
{
    const int FREE_VALUE = 0;
    const int USED_VALUE = 1;
    const char FREE_SYMBOL = '.';
    const char USED_SYMBOL = '#';

    public static int Part1(string keyString) => CreateGrid(keyString).Count(v => v > 0);

    private static int[,] CreateGrid(string keyString)
    {
        var grid = new int[128, 128];

        foreach (var row in Enumerable.Range(0, 128))
        {
            var hash = Day10.Calculations.DenseHash($"{keyString}-{row}");

            if (hash.Length != 16) throw new InvalidOperationException();

            for (var col = 0; col < 128; col++)
                //grid[row, col] = hash[col / 8] >> (col % 8) & 1;
                grid[row, col] = (hash[col / 8] >> (7 - (col % 8))) & 1;
        }

        PrintGrid(grid);

        return grid;
    }

    private static void PrintGrid(int[,] grid)
    {
        for (var r = 0; r < grid.GetLength(0); r++)
        {
            for (var c = 0; c < grid.GetLength(1); c++)
                Debug.Write(grid[r, c] == FREE_VALUE ? FREE_SYMBOL : USED_SYMBOL);

            Debug.WriteLine();
        }
        Debug.WriteLine();
    }

    public static int Part2(string keyString)
    {
        var grid = CreateGrid(keyString);
        var regions = CreateRegions(grid);

        return regions;
    }

    public static int CreateRegions(int[,] grid)
    {
        int numberOfRegions = 0;
        int regionId = 2;

        for (var r = 0; r < grid.GetLength(0); r++)
            for (var c = 0; c < grid.GetLength(1); c++)
            {
                var value = grid[r, c];

                // Nothing to fill in if free
                if (value == FREE_VALUE) continue;

                // Already assigned to a region
                if (value > USED_VALUE) continue;

                grid[r, c] = regionId++;
                numberOfRegions++;

                FloodFill(grid, r, c);
            }

        return numberOfRegions;
    }
    private static void FloodFill(int[,] grid, int startRow, int startCol)
    {
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);

        var region = grid[startRow, startCol];

        var stack = new Stack<(int r, int c)>();
        stack.Push((startRow - 1, startCol));
        stack.Push((startRow + 1, startCol));
        stack.Push((startRow, startCol - 1));
        stack.Push((startRow, startCol + 1));

        while (stack.Count > 0)
        {
            var (rr, cc) = stack.Pop();

            // off the grid
            if (rr < 0 || rr >= rows || cc < 0 || cc >= cols) continue;

            if (grid[rr, cc] == FREE_VALUE) continue;
            if (grid[rr, cc] > USED_VALUE) continue;

            grid[rr, cc] = region;

            stack.Push((rr - 1, cc));
            stack.Push((rr + 1, cc));
            stack.Push((rr, cc - 1));
            stack.Push((rr, cc + 1));
        }
    }
}
