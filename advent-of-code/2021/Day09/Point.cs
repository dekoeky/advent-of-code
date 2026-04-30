namespace advent_of_code._2021.Day09;

internal readonly record struct Point(int Row, int Col)
{
    public readonly IEnumerable<Point> SurroundingPoints()
    {
        yield return new Point(Row - 1, Col);
        yield return new Point(Row + 1, Col);
        yield return new Point(Row, Col - 1);
        yield return new Point(Row, Col + 1);
    }
}