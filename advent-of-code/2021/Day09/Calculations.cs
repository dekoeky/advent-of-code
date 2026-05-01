namespace AdventOfCode._2021.Day09;

internal static class Calculations
{

    public static int Part1(ReadOnlySpan<char> input)
    {
        var heights = StringToCharArray.To2DArray(input, c => c - '0');
        var lowPoints = GetLowPoints(heights);

        return lowPoints.Sum(pt => heights[pt.Position.Row, pt.Position.Col] + 1);
    }

    public static int Part2(string input)
    {
        var heights = StringToCharArray.To2DArray(input, c => c - '0');
        var lowPoints = GetLowPoints(heights);
        var basinSizes = GetBasinSizes(heights, lowPoints);

        return basinSizes.OrderDescending().Take(3).Product();
    }

    private static List<LowPoint> GetLowPoints(int[,] heights)
    {
        List<LowPoint> lowPoints = [];
        var rows = heights.GetLength(0);
        var cols = heights.GetLength(1);

        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
            {
                var h = heights[r, c];

                if (!IsHigher(heights, r + 1, c, h)) continue;
                if (!IsHigher(heights, r - 1, c, h)) continue;
                if (!IsHigher(heights, r, c + 1, h)) continue;
                if (!IsHigher(heights, r, c - 1, h)) continue;

                //Debug.WriteLine($"Low Point! {}");
                lowPoints.Add((r, c, h));
            }

        return lowPoints;
    }

    private static bool IsHigher(int[,] heights, int r, int c, int h)
        => r < 0
        || (c < 0
        || (r >= heights.GetLength(0)
        || (c >= heights.GetLength(1)
        || heights[r, c] > h)));

    private static IEnumerable<int> GetBasinSizes(int[,] heights, List<LowPoint> lowPoints)
    {
        var rows = heights.GetLength(0);
        var cols = heights.GetLength(1);
        var size = 0;
        Queue<Point> q = [];
        HashSet<Point> visited = [];

        foreach (var lowPoint in lowPoints.OrderBy(lp => lp.Height))
        {
            q.Clear();
            visited.Clear();

            visited.Add(lowPoint.Position);
            size = 1;

            foreach (var neighbour in lowPoint.Position.SurroundingPoints())
                q.Enqueue(neighbour);

            while (q.Count > 0)
            {
                var pt = q.Dequeue();

                // Skip when outside grid
                if (pt.Row < 0) continue;
                if (pt.Col < 0) continue;
                if (pt.Row >= rows) continue;
                if (pt.Col >= cols) continue;

                // Skip if already visited
                if (!visited.Add(pt)) continue;

                // Stop processing on height of 9
                if (heights[pt.Row, pt.Col] == 9) continue;

                // This tile is part of basin
                size++;

                // Check Neighbors as well
                foreach (var neighbour in pt.SurroundingPoints())
                    q.Enqueue(neighbour);
            }

            yield return size;
        }
    }
}
