namespace advent_of_code._2023.Day03;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var map = input.To2DArray();
        var sum = 0;

        foreach (var (row, columns) in NumberRanges(map))
        {
            if (IsNearSymbol(map, row, columns))
                sum += Extract(map, row, columns);
        }

        return sum;
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        var map = input.To2DArray();
        var sum = 0;
        var ranges = NumberRanges(map).ToArray();
        var values = ranges.Select(r => Extract(map, r.row, r.columns)).ToArray();

        var rows = map.GetLength(0);
        var cols = map.GetLength(1);

        var count = 0;
        var tempSum = 0;

        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
            {
                if (map[r, c] != '*') continue;

                count = 0;
                tempSum = 1;
                for (var i = 0; i < ranges.Length; i++)
                {
                    if (!IsAdjacent(ranges[i], r, c)) continue;

                    if (++count > 2) break;
                    tempSum *= values[i];
                }

                if (count == 2)
                    sum += tempSum;
            }


        return sum;
    }

    internal static int Extract(char[,] input, int row, Range columns)
    {
        var value = 0;

        for (var c = columns.Start.Value; c < columns.End.Value; c++)
        {
            value *= 10;
            value += input[row, c] - '0';
        }

        return value;
    }

    private static bool IsSymbol(char c) => c != '.' && !char.IsDigit(c);

    internal static bool IsNearSymbol(char[,] input, int row, Range columns)
    {
        foreach (var (c, r) in ValidNeighbours())
            if (IsSymbol(input[r, c]))
                return true;

        return false;

        IEnumerable<(int x, int y)> ValidNeighbours()
        {
            var rows = input.GetLength(0);
            var cols = input.GetLength(1);

            var cMin = Math.Max(0, columns.Start.Value - 1);    // Inclusive
            var cMax = Math.Min(columns.End.Value + 1, cols);   // Exclusive


            for (var c = cMin; c < cMax; c++)
            {
                if (row > 0)
                    yield return (c, row - 1);

                if (row < rows - 1)
                    yield return (c, row + 1);
            }

            if (columns.Start.Value > 0) yield return (columns.Start.Value - 1, row);
            if (columns.End.Value < cols) yield return (columns.End.Value, row);
        }
    }

    internal static IEnumerable<(int row, Range columns)> NumberRanges(char[,] input)
    {
        var rows = input.GetLength(0);
        var cols = input.GetLength(1);

        int r;
        int c;
        int start;
        bool insideNumber;

        for (r = 0; r < rows; r++)
        {
            start = 0;
            insideNumber = false;

            for (c = 0; c < cols; c++)
            {
                var x = input[r, c];
                var charIsNumber = char.IsNumber(x);

                if (insideNumber && !charIsNumber)      // Number ends
                {
                    yield return (r, new Range(start, c));
                    insideNumber = false;
                }
                else if (charIsNumber && !insideNumber) // Number starts
                {
                    start = c;
                    insideNumber = true;
                }
            }

            // Number ends by newline
            if (insideNumber)
                yield return (r, new Range(start, c));
        }
    }

    private static bool IsAdjacent((int row, Range columns) range, int r, int c)
    {
        if (range.row == r)
            return c == range.columns.Start.Value - 1 ||
                   c == range.columns.End.Value;

        if (range.row == r - 1 || range.row == r + 1)
            return c >= range.columns.Start.Value - 1 &&
                   c <= range.columns.End.Value;

        return false;
    }
}