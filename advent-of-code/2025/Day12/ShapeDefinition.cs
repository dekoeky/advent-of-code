namespace advent_of_code._2025.Day12;

internal record ShapeDefinition(int Index, HashSet<(int Row, int Col)> TBD, bool[,] Grid, int Count)
{
    public static ShapeDefinition Parse(ReadOnlySpan<char> input)
    {
        var lines = input.EnumerateLines();

        lines.MoveNext();
        var semicolon = input.IndexOf(':');
        var index = int.Parse(input[..semicolon]);

        HashSet<(int Row, int Col)> tbd = [];
        bool[,] grid = new bool[3, 3];
        int count = 0;

        for (var r = 0; r < 3; r++)
        {
            lines.MoveNext();
            for (var c = 0; c < 3; c++)
                if (lines.Current[c] == '#')
                {
                    grid[r, c] = true;
                    tbd.Add((r, c));
                    count++;
                }
        }

        return new ShapeDefinition(index, tbd, grid, count);
    }
}
