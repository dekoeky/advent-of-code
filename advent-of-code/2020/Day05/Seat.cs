namespace AdventOfCode._2020.Day05;

internal readonly record struct Seat(int Row, int Column)
{

    private static readonly Range SeatRowRange = ..7;
    private static readonly Range SeatColumnRange = 7..;

    public int Id { get; init; } = SeatId(Row, Column);

    public static Seat Parse(ReadOnlySpan<char> input)
    {
        var row = ParseRow(input[SeatRowRange]);
        var col = ParseColumn(input[SeatColumnRange]);

        return new Seat(row, col);
    }

    public static Seat[] ParseMany(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var i = 0;
        var result = new Seat[n];

        foreach (var line in input.EnumerateLines())
            result[i++] = Parse(line);

        return result;
    }

    public static int ParseId(ReadOnlySpan<char> input)
    {
        int row = ParseRow(input[SeatRowRange]);
        var col = ParseColumn(input[SeatColumnRange]);
        var id = SeatId(row, col);

        return id;
    }

    public static int SeatId(int row, int col) => (row * 8) + col;

    public static int ParseRow(ReadOnlySpan<char> input)
    {
        if (input.Length != 7)
            throw new InvalidOperationException($"Input not 7 characters long ({input.Length})");

        var row = 0;

        for (var i = 0; i < input.Length; i++)
        {
            row <<= 1;

            switch (input[i])
            {
                case 'F':
                    continue;

                case 'B':
                    row += 1;
                    continue;

                default: throw new InvalidOperationException();
            }
        }

        return row;
    }

    public static int ParseColumn(ReadOnlySpan<char> input)
    {
        if (input.Length != 3)
            throw new InvalidOperationException($"Input not 3 characters long ({input.Length})");

        var column = 0;

        for (var i = 0; i < input.Length; i++)
        {
            column <<= 1;

            switch (input[i])
            {
                case 'L':
                    continue;

                case 'R':
                    column += 1;
                    continue;

                default: throw new InvalidOperationException();
            }
        }

        return column;
    }
}