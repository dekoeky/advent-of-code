using advent_of_code.Helpers;

namespace advent_of_code._2016.Day08;

internal static class Screen
{
    public static bool[,] GetResult(string input)
    {
        var screen = new bool[50, 6];
        var lines = SplitOn.NewLines(input);

        foreach (var line in lines)
        {
            // rect 1x2
            // rotate row y=0 by 2
            // rotate column x=32 by 1
            if (line.StartsWith("rect"))
            {
                var parts = line.Split(["rect ", "x"], StringSplitOptions.RemoveEmptyEntries);
                var cols = int.Parse(parts[0]);
                var rows = int.Parse(parts[1]);
                Rect(screen, rows, cols);
            }
            else if (line.StartsWith("rotate row"))
            {
                var parts = line.Split(["rotate row y=", " by "], StringSplitOptions.RemoveEmptyEntries);
                var row = int.Parse(parts[0]);
                var right = int.Parse(parts[1]);
                RotateRow(screen, row, right);
            }
            else if (line.StartsWith("rotate column"))
            {
                var parts = line.Split(["rotate column x=", " by "], StringSplitOptions.RemoveEmptyEntries);
                var col = int.Parse(parts[0]);
                var down = int.Parse(parts[1]);
                RotateColumn(screen, col, down);
            }
        }


        return screen;
    }

    public static string ToString(bool[,] screen)
    {
        var sw = new StringWriter();

        for (var r = 0; r < screen.GetLength(1); r++)
        {
            if (r > 0)
                sw.WriteLine();

            for (var c = 0; c < screen.GetLength(0); c++)
                sw.Write(screen[c, r] ? '#' : ' ');
        }

        return sw.ToString();
    }

    private static void Rect(bool[,] screen, int rows, int cols)
    {
        for (int y = 0; y < rows; y++)
            for (int x = 0; x < cols; x++)
                screen[x, y] = true;
    }

    private static void RotateColumn(bool[,] screen, int x, int down)
    {
        int height = screen.GetLength(1);
        down %= height;

        var buffer = new bool[height];

        // Read column into buffer
        for (int y = 0; y < height; y++)
            buffer[y] = screen[x, y];

        // Write rotated values back
        for (int y = 0; y < height; y++)
        {
            int src = (y - down + height) % height;
            screen[x, y] = buffer[src];
        }
    }
    private static void RotateRow(bool[,] screen, int y, int right)
    {
        int width = screen.GetLength(0);
        right %= width;

        var buffer = new bool[width];

        // Read row into buffer
        for (int x = 0; x < width; x++)
            buffer[x] = screen[x, y];

        // Write rotated values back
        for (int x = 0; x < width; x++)
        {
            int src = (x - right + width) % width;
            screen[x, y] = buffer[src];
        }
    }
}
