using System.Text;

namespace advent_of_code._2023.Day14;

/// <summary>
/// Solver for Advent of Code 2023 - Day 14: Parabolic Reflector Dish.
/// </summary>
public static class Calculations
{
    /// <summary>
    /// Computes the total load on the north support after tilting north once.
    /// </summary>
    public static long Part1(string input)
    {
        var grid = input.To2DArray();

        TiltNorth(grid);
        return ComputeNorthLoad(grid);
    }

    /// <summary>
    /// Computes the total load on the north support after 1,000,000,000 spin cycles.
    /// </summary>
    public static long Part2(string input)
    {
        const int totalCycles = 1_000_000_000;

        var grid = input.To2DArray();

        var seen = new Dictionary<string, int>();
        var loads = new List<long>();

        var cycle = 0;
        while (cycle < totalCycles)
        {
            var key = Serialize(grid);
            if (seen.TryGetValue(key, out var firstCycle))
            {
                // Cycle detected: fast-forward
                var cycleLength = cycle - firstCycle;
                var remaining = totalCycles - cycle;
                var offset = remaining % cycleLength;
                return loads[firstCycle + offset - 1];
            }

            seen[key] = cycle;

            // One full spin cycle: N, W, S, E
            TiltNorth(grid);
            TiltWest(grid);
            TiltSouth(grid);
            TiltEast(grid);

            cycle++;
            loads.Add(ComputeNorthLoad(grid));
        }

        return ComputeNorthLoad(grid);
    }

    private static void TiltNorth(char[,] grid)
    {
        int h = grid.GetLength(0);
        int w = grid.GetLength(1);

        for (int c = 0; c < w; c++)
        {
            int targetRow = 0;
            for (int r = 0; r < h; r++)
            {
                char cell = grid[r, c];
                if (cell == '#')
                {
                    targetRow = r + 1;
                }
                else if (cell == 'O')
                {
                    if (r != targetRow)
                    {
                        grid[targetRow, c] = 'O';
                        grid[r, c] = '.';
                    }
                    targetRow++;
                }
            }
        }
    }

    private static void TiltSouth(char[,] grid)
    {
        int h = grid.GetLength(0);
        int w = grid.GetLength(1);

        for (int c = 0; c < w; c++)
        {
            int targetRow = h - 1;
            for (int r = h - 1; r >= 0; r--)
            {
                char cell = grid[r, c];
                if (cell == '#')
                {
                    targetRow = r - 1;
                }
                else if (cell == 'O')
                {
                    if (r != targetRow)
                    {
                        grid[targetRow, c] = 'O';
                        grid[r, c] = '.';
                    }
                    targetRow--;
                }
            }
        }
    }

    private static void TiltWest(char[,] grid)
    {
        int h = grid.GetLength(0);
        int w = grid.GetLength(1);

        for (int r = 0; r < h; r++)
        {
            int targetCol = 0;
            for (int c = 0; c < w; c++)
            {
                char cell = grid[r, c];
                if (cell == '#')
                {
                    targetCol = c + 1;
                }
                else if (cell == 'O')
                {
                    if (c != targetCol)
                    {
                        grid[r, targetCol] = 'O';
                        grid[r, c] = '.';
                    }
                    targetCol++;
                }
            }
        }
    }

    private static void TiltEast(char[,] grid)
    {
        int h = grid.GetLength(0);
        int w = grid.GetLength(1);

        for (int r = 0; r < h; r++)
        {
            int targetCol = w - 1;
            for (int c = w - 1; c >= 0; c--)
            {
                char cell = grid[r, c];
                if (cell == '#')
                {
                    targetCol = c - 1;
                }
                else if (cell == 'O')
                {
                    if (c != targetCol)
                    {
                        grid[r, targetCol] = 'O';
                        grid[r, c] = '.';
                    }
                    targetCol--;
                }
            }
        }
    }

    private static long ComputeNorthLoad(char[,] grid)
    {
        int h = grid.GetLength(0);
        int w = grid.GetLength(1);
        long load = 0;

        for (int r = 0; r < h; r++)
        {
            int weight = h - r;
            for (int c = 0; c < w; c++)
            {
                if (grid[r, c] == 'O')
                {
                    load += weight;
                }
            }
        }

        return load;
    }

    private static string Serialize(char[,] grid)
    {
        int h = grid.GetLength(0);
        int w = grid.GetLength(1);
        var sb = new StringBuilder(h * (w + 1));

        for (int r = 0; r < h; r++)
        {
            for (int c = 0; c < w; c++)
            {
                sb.Append(grid[r, c]);
            }
            sb.Append('\n');
        }

        return sb.ToString();
    }
}