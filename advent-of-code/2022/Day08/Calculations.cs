using advent_of_code.Helpers;

namespace advent_of_code._2022.Day08;

internal static class Calculations
{
    public static long Part1(string input)
    {
        var heights = input.To2DArray(c => c - '0');
        var gridSize = heights.Length;

        var rows = heights.GetLength(0);
        var cols = heights.GetLength(1);
        var seen = new bool[rows, cols];

        var visible = 0;
        var max = int.MinValue;

        var allRows = Enumerable.Range(0, rows);
        var allCols = Enumerable.Range(0, cols);



        // Look from left, for each row
        for (var r = 0; r < rows; r++)
        {
            max = int.MinValue;

            for (var c = 0; c < cols; c++)
            {
                // If the height of this tree is larger than max, we see it from this side
                if (heights[r, c] > max)
                {
                    if (!seen[r, c])
                    {
                        visible++;
                        seen[r, c] = true;
                    }
                    max = heights[r, c];
                }

                if (max == 9) break;
            }
        }

        // look from right, for each row
        for (var r = 0; r < rows; r++)
        {
            max = int.MinValue;

            for (var c = cols - 1; c >= 0; c--)
            {
                // If the height of this tree is larger than max, we see it from this side
                if (heights[r, c] > max)
                {
                    if (!seen[r, c])
                    {
                        visible++;
                        seen[r, c] = true;
                    }
                    max = heights[r, c];
                }

                if (max == 9) break;
            }
        }

        // look from top, for each column
        for (var c = 0; c < cols; c++)
        {
            max = int.MinValue;

            for (var r = 0; r < rows; r++)
            {
                // If the height of this tree is larger than max, we see it from this side
                if (heights[r, c] > max)
                {
                    if (!seen[r, c])
                    {
                        visible++;
                        seen[r, c] = true;
                    }
                    max = heights[r, c];
                }

                if (max == 9) break;
            }
        }

        // look from bot, for each column
        for (var c = 0; c < cols; c++)
        {
            max = int.MinValue;

            for (var r = rows - 1; r >= 0; r--)
            {
                // If the height of this tree is larger than max, we see it from this side
                if (heights[r, c] > max)
                {
                    if (!seen[r, c])
                    {
                        visible++;
                        seen[r, c] = true;
                    }
                    max = heights[r, c];
                }

                if (max == 9) break;
            }
        }

        return visible;
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        var heights = input.To2DArray(c => c - '0');
        var gridSize = heights.Length;

        var max = 0;

        for (var r = 0; r < heights.GetLength(0); r++)
            for (var c = 0; c < heights.GetLength(1); c++)
                max = Math.Max(max, ScenicScore(heights, (r, c)));

        return max;
    }

    private static int ScenicScore(int[,] heights, (int Row, int Col) treeHouse)
    {
        var l = ViewingDistance(heights, treeHouse, (0, -1));
        var r = ViewingDistance(heights, treeHouse, (0, +1));
        var u = ViewingDistance(heights, treeHouse, (-1, 0));
        var d = ViewingDistance(heights, treeHouse, (+1, 0));

        return l * r * u * d;
    }

    private static int ViewingDistance(int[,] heights, (int Row, int Col) treeHouse, (int Row, int Col) move)
    {
        var r = treeHouse.Row;
        var c = treeHouse.Col;

        var rows = heights.GetLength(0);
        var cols = heights.GetLength(1);

        var d = 0;
        var max = heights[treeHouse.Row, treeHouse.Col];

        while (true)
        {
            r += move.Row;
            c += move.Col;

            // Check bounds
            if (r < 0 || c < 0 || r >= rows || c >= cols)
                break;

            // We see another tree
            d++;

            // If its the same height (or higher)
            // this was the last seen tree in this dir
            if (heights[r, c] >= max)
                break;
        }

        return d;
    }
}