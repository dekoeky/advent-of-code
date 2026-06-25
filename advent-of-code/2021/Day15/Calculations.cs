using Pos = (int X, int Y);

namespace advent_of_code._2021.Day15;

internal static class Calculations
{
    private static readonly Pos[] Moves = [

        (-1, 0),
        (0, -1),

        (+1, 0),
        (0, +1),
        ];

    public static int Part1(ReadOnlySpan<char> input)
        => Execute(input);

    public static int Part2(ReadOnlySpan<char> input)
        => Execute(input, 5);

    private static int[,] ParseMap(ReadOnlySpan<char> input, int scale, out int rows, out int cols)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(scale, 1);

        var map = input.To2DArray(p => p - '0', out rows, out cols);

        return scale == 1
            ? map
            : Scale(map, scale, out rows, out cols);
    }

    private static int[,] Scale(int[,] original, int scale, out int rows, out int cols)
    {
        var oRows = original.GetLength(0);
        var oCols = original.GetLength(1);

        rows = oRows * scale;
        cols = oCols * scale;

        var scaled = new int[rows, cols];

        // Copy Top Left 10x10 tile
        for (var r = 0; r < oRows; r++)
            for (var c = 0; c < oCols; c++)
                scaled[r, c] = original[r, c];

        // Smear to other 10x10 tiles
        for (var r = 0; r < scale; r++)
            for (var c = 0; c < scale; c++)
                if (r != 0 || c != 0)
                    Smear(r, c);

        return scaled;

        void Smear(int sR, int sC)
        {
            var s = sR + sC;
            var dR = sR * oRows;
            var dC = sC * oCols;

            // Copy each element in the original map
            for (var r = 0; r < oRows; r++)
                for (var c = 0; c < oCols; c++)
                    scaled[r + dR, c + dC] = OffsetRisk(original[r, c], s);

            return;

            static int OffsetRisk(int original, int s)
            {
                return ((original + s - 1) % 9) + 1;
            }
        }
    }


    private static int Execute(ReadOnlySpan<char> input, int expand = 1)
    {
        var map = ParseMap(input, expand, out var rows, out var cols);
        var start = new Pos(0, 0);
        var target = new Pos(cols - 1, rows - 1);
        var best = new int[rows, cols];
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                best[r, c] = int.MaxValue;

        var pq = new PriorityQueue<Pos, int>();
        pq.Enqueue(start, 0);

        while (pq.TryDequeue(out var pos, out var risk))
        {
            if (pos == target)
                return risk;

            if (risk >= best[pos.Y, pos.X])
                continue;

            best[pos.Y, pos.X] = risk;

            foreach (var (dx, dy) in Moves)
            {
                var nx = pos.X + dx;
                var ny = pos.Y + dy;

                if (nx < 0 || ny < 0 || nx >= cols || ny >= rows)
                    continue;

                var newRisk = risk + map[ny, nx];

                if (newRisk < best[ny, nx])
                    pq.Enqueue((nx, ny), newRisk);
            }
        }

        return -1;
    }
}