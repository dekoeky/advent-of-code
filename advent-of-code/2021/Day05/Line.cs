namespace AdventOfCode._2021.Day05;

internal readonly record struct Line(Point A, Point B)
{
    private const string Splitter = " -> ";

    public static Line Parse(ReadOnlySpan<char> input)
    {
        var splitterStart = input.IndexOf(Splitter);
        var splitterEnd = splitterStart + Splitter.Length;

        var a = Point.Parse(input[..splitterStart]);
        var b = Point.Parse(input[splitterEnd..]);

        return new Line(a, b);
    }

    public static Line[] ParseMany(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var i = 0;
        var lines = new Line[n];

        foreach (var inputLine in input.EnumerateLines())
            lines[i++] = Parse(inputLine);

        return lines;
    }

    public readonly IEnumerable<Point> EnumeratePoints()
    {
        // For now, assume vertical or horizontal or 45°
        var deltaX = Math.Sign(B.X - A.X);
        var deltaY = Math.Sign(B.Y - A.Y);

        var steps = Math.Max(Math.Abs(B.X - A.X), Math.Abs(B.Y - A.Y));

        var x = A.X;
        var y = A.Y;

        for (var s = 0; s <= steps; s++)
        {
            yield return new Point(x, y);
            x += deltaX;
            y += deltaY;
        }
    }
}