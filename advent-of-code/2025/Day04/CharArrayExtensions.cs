namespace advent_of_code._2025.Day04;

public static class CharArrayExtensions
{
    public static IEnumerable<T> LoopSurroundingValues<T>(this T[,] data, int row, int col) where T : struct
    {
        if (data.TryGetValue(row - 1, col - 1, out var value)) yield return value;
        if (data.TryGetValue(row - 1, col + 0, out value)) yield return value;
        if (data.TryGetValue(row - 1, col + 1, out value)) yield return value;
        if (data.TryGetValue(row + 0, col + 1, out value)) yield return value;
        if (data.TryGetValue(row + 1, col + 1, out value)) yield return value;
        if (data.TryGetValue(row + 1, col + 0, out value)) yield return value;
        if (data.TryGetValue(row + 1, col - 1, out value)) yield return value;
        if (data.TryGetValue(row + 0, col - 1, out value)) yield return value;
    }

    public static bool HaxMaxNAdjacentRollsOfPaper(this char[,] data, int row, int col, int n) =>
        data.LoopSurroundingValues(row, col).All(item => item is '.' or 'x' || --n > 0);
}