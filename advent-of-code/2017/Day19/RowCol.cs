namespace AdventOfCode._2017.Day19;

internal record struct RowCol(int Row, int Col)
{
    public static RowCol operator +(RowCol left, RowCol right) => new(left.Row + right.Row, left.Col + right.Col);

    public static readonly RowCol Down = new(+1, 0);
    public static readonly RowCol Up = new(-1, 0);
    public static readonly RowCol Left = new(0, -1);
    public static readonly RowCol Right = new(0, +1);
}