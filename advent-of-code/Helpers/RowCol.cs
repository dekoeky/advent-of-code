using System.Diagnostics.CodeAnalysis;

namespace advent_of_code.Helpers;

[method: SetsRequiredMembers]
public readonly record struct RowCol(int Row, int Col)
{
    public static RowCol operator -(RowCol a, RowCol b) => new(a.Row - b.Row, a.Col - b.Col);

    public static RowCol operator +(RowCol a, RowCol b) => new(a.Row + b.Row, a.Col + b.Col);

    public static readonly RowCol RowAbove = new(-1, 0);
    public static readonly RowCol RowBelow = new(+1, 0);
    public static readonly RowCol ColumnLeft = new(0, -1);
    public static readonly RowCol ColumnRight = new(0, +1);
}