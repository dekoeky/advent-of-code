namespace advent_of_code._2025.Day09;

internal static class Calculations
{
    public static long Part1(ReadOnlySpan<char> input)
    {
        var redTilePositions = Parse(input);

        long largest = -1;

        for (var i = 0; i < redTilePositions.Length - 1; i++)
            for (var j = 1; j < redTilePositions.Length; j++)
            {
                var (x1, y1) = redTilePositions[i];
                var (x2, y2) = redTilePositions[j];

                var w = Math.Abs(x2 - x1) + 1L;
                var h = Math.Abs(y2 - y1) + 1L;

                var area = w * h;

                if (area > largest)
                    largest = area;
            }

        return largest;
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        var points = Parse(input);

        // --- coordinate compression ---
        var xs = points.Select(p => p.x).Distinct().OrderBy(x => x).ToList();
        var ys = points.Select(p => p.y).Distinct().OrderBy(y => y).ToList();

        var xMap = xs.Select((v, i) => (v, i)).ToDictionary(t => t.v, t => t.i);
        var yMap = ys.Select((v, i) => (v, i)).ToDictionary(t => t.v, t => t.i);

        var w = xs.Count;
        var h = ys.Count;

        // --- inside grid ---
        var inside = new int[w, h];

        for (int i = 0; i < w; i++)
            for (int j = 0; j < h; j++)
            {
                // test actual coordinate
                if (InsideOrOn(points, xs[i], ys[j]))
                    inside[i, j] = 1;
            }

        // --- prefix sum ---
        var ps = new int[w + 1, h + 1];

        for (var i = 1; i <= w; i++)
            for (var j = 1; j <= h; j++)
            {
                ps[i, j] = inside[i - 1, j - 1]
                         + ps[i - 1, j]
                         + ps[i, j - 1]
                         - ps[i - 1, j - 1];
            }

        int RectSum(int x1, int y1, int x2, int y2)
        {
            return ps[x2 + 1, y2 + 1]
                 - ps[x1, y2 + 1]
                 - ps[x2 + 1, y1]
                 + ps[x1, y1];
        }

        // --- brute pairs ---
        var best = 0;

        for (var i = 0; i < points.Length; i++)
            for (int j = i + 1; j < points.Length; j++)
            {
                var x1 = xMap[Math.Min(points[i].x, points[j].x)];
                var y1 = yMap[Math.Min(points[i].y, points[j].y)];
                var x2 = xMap[Math.Max(points[i].x, points[j].x)];
                var y2 = yMap[Math.Max(points[i].y, points[j].y)];

                var width = xs[x2] - xs[x1] + 1;
                var height = ys[y2] - ys[y1] + 1;
                var area = width * height;

                if (area <= best) continue;

                var sum = RectSum(x1, y1, x2, y2);

                var cells = (x2 - x1 + 1) * (y2 - y1 + 1);

                if (sum == cells)
                    best = area;
            }

        return best;
    }

    private static bool InsideOrOn((int x, int y)[] poly, int px, int py)
           => PointInPolygon(poly, px, py) || OnBoundary(poly, px, py);

    private static bool PointInPolygon((int x, int y)[] poly, int px, int py)
    {
        bool inside = false;

        for (int i = 0, j = poly.Length - 1; i < poly.Length; j = i++)
        {
            var (xi, yi) = poly[i];
            var (xj, yj) = poly[j];

            if (((yi > py) != (yj > py)) &&
                (px < (long)(xj - xi) * (py - yi) / (yj - yi) + xi))
            {
                inside = !inside;
            }
        }

        return inside;
    }

    private static bool OnBoundary((int x, int y)[] poly, int px, int py)
    {
        for (int i = 0; i < poly.Length; i++)
        {
            var (x1, y1) = poly[i];
            var (x2, y2) = poly[(i + 1) % poly.Length];

            if (x1 == x2)
            {
                if (px == x1 && py >= Math.Min(y1, y2) && py <= Math.Max(y1, y2))
                    return true;
            }
            else if (y1 == y2)
            {
                if (py == y1 && px >= Math.Min(x1, x2) && px <= Math.Max(x1, x2))
                    return true;
            }
        }

        return false;
    }

    private static (int x, int y)[] Parse(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var i = 0;
        var points = new (int x, int y)[n];

        Span<Range> r = stackalloc Range[2];

        foreach (var line in input.EnumerateLines())
        {
            var idx = line.IndexOf(',');
            var y = int.Parse(line[..idx++]);
            var x = int.Parse(line[idx..]);
            points[i++] = (x, y);
        }

        return points;
    }
}
