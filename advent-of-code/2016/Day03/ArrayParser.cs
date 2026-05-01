namespace AdventOfCode._2016.Day03;

internal static class ArrayParser
{
    public static int[,] Parse(string input)
    {
        var lines = SplitOn.NewLines(input);

        var rows = lines.Length;
        var parts = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var cols = parts.Length;

        var array = new int[rows, cols];

        for (var r = 0; r < rows; r++)
        {
            parts = lines[r].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (var c = 0; c < cols; c++)
                array[r, c] = int.Parse(parts[c]);
        }

        return array;
    }

    public static IEnumerable<TriangleDefinition> Part1(string input)
    {
        var values = Parse(input);

        for (var r = 0; r < values.GetLength(0); r++)
            yield return new TriangleDefinition(values[r, 0], values[r, 1], values[r, 2]);
    }

    public static IEnumerable<TriangleDefinition> Part2(string input)
    {
        var values = Parse(input);
        var rows = values.GetLength(0);

        for (var i = 0; i < values.Length; i++)
            yield return new TriangleDefinition(
            values[i % rows, i / rows],
            values[++i % rows, i / rows],
            values[++i % rows, i / rows]
        );
    }
}