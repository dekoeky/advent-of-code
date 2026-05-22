namespace advent_of_code._2020.Day05;

internal static partial class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var max = int.MinValue;

        foreach (var line in input.EnumerateLines())
            max = Math.Max(max, Seat.ParseId(line));

        return max;
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        var seats = Seat.ParseMany(input);

        // Visualizing this map is how i found the solution
        var map = SeatMap(seats);
        PrintMap(map);

        var row = seats
            .GroupBy(s => s.Row)
            .First(g => g.Count() == 7)
            .Key;

        var col = Enumerable.Range(0, 8)
            .First(c => !seats.Any(s => s.Row == row && s.Column == c));

        return Seat.SeatId(row, col);
    }

    private static void PrintMap(char[,] map)
    {
        Debug.WriteLine("    01234567");
        for (var r = 0; r < map.GetLength(0); r++)
        {
            Debug.Write($"{r,3} ");
            for (var c = 0; c < map.GetLength(1); c++)
            {
                Debug.Write(map[r, c]);
            }
            Debug.WriteLine();
        }
    }

    private static char[,] SeatMap(Seat[] seats)
    {
        var map = new char[128, 8];
        Array.Fill(map, '.');

        foreach (var seat in seats)
            map[seat.Row, seat.Column] = '#';

        return map;
    }
}
