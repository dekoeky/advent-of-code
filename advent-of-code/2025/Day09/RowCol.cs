namespace advent_of_code._2025.Day09;

public readonly record struct RowCol(long Row, long Col)
{
    public static RowCol Parse(string input)
    {
        var parts = input.Split(',');

        return new RowCol(long.Parse(parts[0]), long.Parse(parts[1]));
    }
}