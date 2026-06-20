namespace advent_of_code._2020.Day11;

internal static class Calculations
{
    private const char OccupiedSeat = '#';
    private const char EmptySeat = 'L';
    private const char NoSeat = '.';
    private static readonly (int Rows, int Cols)[] Neighbors = [
        (-1, -1),
        (-1,  0),
        (-1, +1),

        ( 0, -1),
        ( 0, +1),

        (+1, -1),
        (+1,  0),
        (+1, +1),
        ];

    public static long Part1(ReadOnlySpan<char> input)
    {
        var layout = input.To2DArray();
        var newLayout = layout.Copy();
        var rows = layout.GetLength(0);
        var cols = layout.GetLength(1);
        var rc = rows * cols;
        bool changes;
        var seatsOccupied = layout.Count(OccupiedSeat);
        var rounds = 0;

        while (true)
        {
            changes = false;

            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    switch (layout[r, c])
                    {
                        // If a seat is empty (L)
                        // and there are no occupied seats adjacent to it,
                        // the seat becomes occupied.
                        case EmptySeat:
                            if (NoOccupiedAdjacentSeats(r, c))
                            {
                                changes = true;
                                seatsOccupied++;
                                newLayout[r, c] = OccupiedSeat;
                            }
                            break;

                        // If a seat is occupied (#)
                        // and four or more seats adjacent to it are also occupied,
                        // the seat becomes empty.
                        case OccupiedSeat:
                            if (NOrMoreAdjacentSeatsOccupied(r, c))
                            {
                                changes = true;
                                seatsOccupied--;
                                newLayout[r, c] = EmptySeat;
                            }
                            break;

                        // Otherwise,
                        // the seat's state does not change.
                        default:
                            continue;
                    }

            if (!changes) break;
            if (++rounds > 10000) throw new InvalidOperationException("Loop does not seem to end");

            Array.Copy(newLayout, layout, rc);
        }

        return seatsOccupied;

        bool NoOccupiedAdjacentSeats(int r, int c)
        {
            foreach (var delta in Neighbors)
            {
                var rr = r + delta.Rows;
                var cc = c + delta.Cols;

                // Out of bounds gets skipped
                if (rr < 0 || cc < 0) continue;
                if (rr >= rows || cc >= cols) continue;

                if (layout[rr, cc] == OccupiedSeat) return false;
            }

            return true;
        }

        bool NOrMoreAdjacentSeatsOccupied(int r, int c, int n = 4)
        {
            foreach (var delta in Neighbors)
            {
                var rr = r + delta.Rows;
                var cc = c + delta.Cols;

                // Out of bounds gets skipped
                if (rr < 0 || cc < 0) continue;
                if (rr >= rows || cc >= cols) continue;

                if (layout[rr, cc] != OccupiedSeat)
                    continue;

                if (--n <= 0) return true;
            }

            return false;
        }
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        var layout = input.To2DArray();
        var newLayout = layout.Copy();
        var rows = layout.GetLength(0);
        var cols = layout.GetLength(1);
        var rc = rows * cols;
        bool changes;
        var seatsOccupied = layout.Count(OccupiedSeat);
        var rounds = 0;

        while (true)
        {
            changes = false;

            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    switch (layout[r, c])
                    {
                        // If a seat is empty (L)
                        // and there are no occupied seats adjacent to it,
                        // the seat becomes occupied.
                        case EmptySeat:
                            if (NoOccupiedAdjacentSeats(r, c))
                            {
                                changes = true;
                                seatsOccupied++;
                                newLayout[r, c] = OccupiedSeat;
                            }
                            break;

                        // If a seat is occupied (#)
                        // and four or more seats adjacent to it are also occupied,
                        // the seat becomes empty.
                        case OccupiedSeat:
                            if (NOrMoreAdjacentSeatsOccupied(r, c))
                            {
                                changes = true;
                                seatsOccupied--;
                                newLayout[r, c] = EmptySeat;
                            }
                            break;

                        // Otherwise,
                        // the seat's state does not change.
                        default:
                            continue;
                    }

            if (!changes) break;
            if (++rounds > 10000) throw new InvalidOperationException("Loop does not seem to end");

            Array.Copy(newLayout, layout, rc);
        }

        return seatsOccupied;

        bool NoOccupiedAdjacentSeats(int r, int c)
        {
            foreach (var direction in Neighbors)
            {
                var rr = r;
                var cc = c;

                while (true)
                {
                    rr += direction.Rows;
                    cc += direction.Cols;

                    // Out of bounds gets skipped
                    if (rr < 0 || cc < 0) break;
                    if (rr >= rows || cc >= cols) break;

                    if (layout[rr, cc] == OccupiedSeat) return false;

                    // If we see an empty seat --> this direction is ok
                    if (layout[rr, cc] == EmptySeat) break;
                }
            }

            return true;
        }

        bool NOrMoreAdjacentSeatsOccupied(int r, int c, int n = 5)
        {
            foreach (var direction in Neighbors)
            {
                var rr = r;
                var cc = c;

                while (true)
                {
                    rr += direction.Rows;
                    cc += direction.Cols;

                    if (rr < 0 || cc < 0) break;
                    if (rr >= rows || cc >= cols) break;

                    if (layout[rr, cc] == NoSeat)
                        continue;

                    if (layout[rr, cc] == OccupiedSeat)
                    {
                        if (--n <= 0) return true;
                        break;
                    }

                    // Empty seat blocks line of sight
                    break;
                }
            }

            return false;
        }
    }
}
