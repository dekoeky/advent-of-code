namespace advent_of_code._2018.Day06;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var coordinates = Coordinate.ParseMany(input);
        var ((minX, minY), (maxX, maxY)) = Coordinate.BoundingBox(coordinates);

        var n = coordinates.Length;
        var area = new int[n];
        var isInfinite = new bool[n];

        for (var y = minY; y <= maxY; y++)
            for (var x = minX; x <= maxX; x++)
            {
                var best = -1;
                var bestDist = int.MaxValue;
                var tie = false;

                for (int i = 0; i < n; i++)
                {
                    var d = coordinates[i].ManhattanDistance(x, y);

                    if (d < bestDist)
                    {
                        bestDist = d;
                        best = i;
                        tie = false;
                    }
                    else if (d == bestDist)
                    {
                        tie = true;
                    }
                }

                if (tie) continue;

                // Assign cell to coordinate
                area[best]++;

                // If on border -> infinite
                if (x == minX || x == maxX || y == minY || y == maxY)
                    isInfinite[best] = true;
            }

        var maxArea = 0;

        for (var i = 0; i < n; i++)
            if (!isInfinite[i] && area[i] > maxArea)
                maxArea = area[i];

        return maxArea;
    }

    public static int Part2(string input, int threshold)
    {
        // Parse coordinates
        var coordinates = Coordinate.ParseMany(input);
        var ((minX, minY), (maxX, maxY)) = Coordinate.BoundingBox(coordinates);
        var n = coordinates.Length;

        // Expand bounding box by threshold
        minX -= threshold;
        maxX += threshold;
        minY -= threshold;
        maxY += threshold;

        var regionSize = 0;

        // Scan expanded bounding box
        for (var y = minY; y <= maxY; y++)
            for (var x = minX; x <= maxX; x++)
            {
                var sum = 0;

                for (int i = 0; i < n; i++)
                {
                    sum += coordinates[i].ManhattanDistance(x, y);

                    if (sum >= threshold)
                        break; // no need to continue
                }

                if (sum < threshold)
                    regionSize++;
            }

        return regionSize;
    }
}
