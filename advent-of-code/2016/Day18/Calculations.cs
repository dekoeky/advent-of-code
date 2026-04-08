namespace advent_of_code._2016.Day18;

internal static class Calculations
{
    private const char SAFE = '.';
    private const char TRAP = '^';

    public static int SafeRows(string firstRow, int rows)
    {
        int l = firstRow.Length;
        var safeCount = firstRow.Count(c => c == SAFE);

        Span<char> previous = stackalloc char[l];
        Span<char> current = stackalloc char[l];

        firstRow.CopyTo(current);

        while (--rows > 0)
        {
            current.CopyTo(previous);
            for (int i = 0; i < l; i++)
            {
                var left = i == 0 ? SAFE : previous[i - 1];
                var center = previous[i];
                var right = i == l - 1 ? SAFE : previous[i + 1];

                var tile = (left, center, right) switch
                {
                    (TRAP, TRAP, SAFE) => TRAP,
                    (SAFE, TRAP, TRAP) => TRAP,
                    (TRAP, SAFE, SAFE) => TRAP,
                    (SAFE, SAFE, TRAP) => TRAP,
                    _ => SAFE,
                };

                current[i] = tile;

                if (tile == SAFE) safeCount++;
            }
        }

        return safeCount;
    }
}
