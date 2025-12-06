using advent_of_code.Helpers;

namespace advent_of_code._2024.Day20;

internal static class RowColExtensions
{
    public static IEnumerable<RowCol> EnumerateUpRightDownLeftCells<T>(this T[,] data, RowCol centerCell)
    {
        if (centerCell.Row > 0)
            yield return centerCell with { Row = centerCell.Row - 1 };

        if (centerCell.Row < data.GetLength(0))
            yield return centerCell with { Col = centerCell.Col + 1 };

        if (centerCell.Col < data.GetLength(1))
            yield return centerCell with { Row = centerCell.Row + 1 };

        if (centerCell.Col > 0)
            yield return centerCell with { Col = centerCell.Col - 1 };
    }
}