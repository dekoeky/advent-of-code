namespace advent_of_code._2025.Day09;

public readonly record struct RowCol(int Row, int Col)
{
    public static RowCol Parse(string input)
    {
        var parts = input.Split(',');

        return new RowCol(int.Parse(parts[0]), int.Parse(parts[1]));
    }

    /// <summary>
    ///  Returns each tile of the rectangle created between this <see cref="RowCol"/> and <paramref name="other"/>.
    /// </summary>
    public IEnumerable<RowCol> TilesBetween(RowCol other)
    {
        var (minRow, maxRow) = other.Row < Row
            ? (other.Row, Row)
            : (Row, other.Row);

        var (minCol, maxCol) = other.Col < Col
            ? (other.Col, Col)
            : (Col, other.Col);

        for (var r = minRow; r <= maxRow; r++)
            for (var c = minCol; c <= maxCol; c++)
                yield return new RowCol(r, c);
    }
    public IEnumerable<RowCol> TilesBetween2(RowCol other)
    {
        var (minRow, maxRow) = other.Row < Row
            ? (other.Row, Row)
            : (Row, other.Row);

        var (minCol, maxCol) = other.Col < Col
            ? (other.Col, Col)
            : (Col, other.Col);

        for (var r = minRow; r <= maxRow; r++)
            for (var c = minCol; c <= maxCol; c++)
            {
                var x = new RowCol(r, c);

                if (x == this) continue;
                if (x == other) continue;

                yield return x;
            }
    }

    public IEnumerable<RowCol> SurroundingCells()
    {
        yield return new RowCol(Row - 1, Col - 1); // Top Left
        yield return new RowCol(Row - 1, Col + 0); // Top
        yield return new RowCol(Row - 1, Col + 1); // Top Right
        yield return new RowCol(Row + 0, Col + 1); // Right
        yield return new RowCol(Row + 1, Col + 1); // Bottom Right
        yield return new RowCol(Row + 1, Col + 0); // Bottom
        yield return new RowCol(Row + 1, Col - 1); // Bottom Left
        yield return new RowCol(Row + 0, Col - 1); // Left
    }

    public long RectangleArea(RowCol other)
        => Math.Abs((other.Row - Row) + 1)
        * (long)Math.Abs((other.Col - Col) + 1);
}