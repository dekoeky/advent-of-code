using System.Text;

namespace advent_of_code._2018.Day10;

internal static class Calculations
{
    public static string Part1(ReadOnlySpan<char> input)
        => Execute(input).Text;

    public static int Part2(ReadOnlySpan<char> input)
        => Execute(input).Seconds;

    private static (string Text, int Seconds) Execute(ReadOnlySpan<char> input)
    {
        var n = PositionVelocity.ParseMany(input, out var positions, out var velocities);
        var seconds = 0;
        var lastTextSize = long.MaxValue;

        while (true) // Untill the text region grows again
        {
            // Move each point in the direction of their velocity
            for (int i = 0; i < n; i++)
            {
                positions[i].X += velocities[i].X;
                positions[i].Y += velocities[i].Y;
            }
            seconds++;

            var newTextSize = GetTextSize(positions);

            // If the size starts increasing again,
            // we know the previous step is the winner
            if (newTextSize <= lastTextSize)
            {
                lastTextSize = newTextSize;
                continue;
            }

            // Move each point back one second
            for (int i = 0; i < n; i++)
            {
                positions[i].X -= velocities[i].X;
                positions[i].Y -= velocities[i].Y;
            }
            seconds--;


            var text = Render(positions);

            Debug.WriteLine($"Seconds: {seconds}");
            Debug.WriteLine(text);

            return (text, seconds);
        }

        throw new InvalidOperationException();
    }

    private static long GetTextSize(Position[] data)
    {
        // TODO: Double enumeration
        int minX = data.Min(d => d.X);
        int minY = data.Min(d => d.Y);
        int maxX = data.Max(d => d.X);
        int maxY = data.Max(d => d.Y);

        var w = maxX - (long)minX;
        var h = maxY - (long)minY;
        var size = w * h;

        //Debug.WriteLine($"Size: {size} ({w}x{h})");

        return size;
    }

    private static string Render(Position[] data)
    {
        int minX = int.MaxValue, minY = int.MaxValue;
        int maxX = int.MinValue, maxY = int.MinValue;

        foreach (var p in data)
        {
            if (p.X < minX) minX = p.X;
            if (p.Y < minY) minY = p.Y;
            if (p.X > maxX) maxX = p.X;
            if (p.Y > maxY) maxY = p.Y;
        }

        var w = maxX - minX + 1;
        var h = maxY - minY + 1;
        var size = w * h;

        // Build a boolean grid
        var grid = new bool[size];

        foreach (var p in data)
        {
            long gx = p.X - minX;
            long gy = p.Y - minY;
            var index = gy * w + gx;
            grid[index] = true;
        }

        // Render to string
        var sw = new StringBuilder(size);

        for (int y = 0; y < h; y++)
        {
            var row = y * w;
            for (int x = 0; x < w; x++)
                sw.Append(grid[row + x] ? '#' : '.');

            sw.AppendLine();
        }

        return sw.ToString();
    }
}