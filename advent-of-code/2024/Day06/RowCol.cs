using System.Diagnostics.CodeAnalysis;

namespace advent_of_code._2024.Day06;

[method: SetsRequiredMembers]
public readonly record struct RowCol(int Row, int Col)
{
    public static RowCol operator -(RowCol a, RowCol b) => new(a.Row - b.Row, a.Col - b.Col);

    public static RowCol operator +(RowCol a, RowCol b) => new(a.Row + b.Row, a.Col + b.Col);
}