using advent_of_code.Helpers;

// Convention 2D Array: array[row, col] = array[y, x]
using RowCol = (int Row, int Col);

namespace advent_of_code._2016.Day24;

internal static class Calculations
{
    private const char WALL = '#';
    private const char EMPTY = '.';

    private static readonly RowCol[] ValidMoves = [
        (Row: -1, Col:  0), // Up
        (Row:  0, Col: +1), // Right
        (Row: +1, Col:  0), // Down
        (Row:  0, Col: -1), // Left
        ];


    public static int Calculate(string input, bool returnToStart = false)
    {
        var map = StringToCharArray.To2DArray(input);
        var checkPoints = FindPoints(map);
        var distances = GetDistances(map, checkPoints);
        var shortestPath = GetShortestTravel(checkPoints.Keys, distances, 0, returnToStart);

        return shortestPath;
    }

    private static Dictionary<int, RowCol> FindPoints(char[,] map)
    {
        // Assuming max 10 points, each single digit (0-9)

        Dictionary<int, RowCol> points = [];

        for (var r = 0; r < map.GetLength(0); r++)
            for (var c = 0; c < map.GetLength(1); c++)
            {
                var tile = map[r, c];

                if (tile is WALL or EMPTY)
                    continue;

                if (!char.IsDigit(tile))
                    throw new InvalidOperationException($"Invalid tile {tile}");

                // Add the point
                points.Add(tile - '0', (r, c));
            }

        return points;
    }

    /// <summary>
    /// Returns an array mapping the distance from one point(index) to each other point(index).
    /// </summary>
    /// <returns>An array where the distance between point A and B can be looked up as Distances[A, B].</returns>
    private static int[,] GetDistances(char[,] map, Dictionary<int, RowCol> points)
    {
        var n = points.Count;
        var distances = new int[n, n];
        foreach (var (id1, position1) in points)
        {
            var dmap = BFS(map, position1);

            foreach (var (id2, (r2, c2)) in points)
                distances[id1, id2] = dmap[r2, c2];
        }

        return distances;
    }

    /// <summary>
    /// Creates a mapping for each cell in which distance it can be reached from <paramref name="start"/>.
    /// </summary>
    private static int[,] BFS(char[,] map, RowCol start)
    {
        int rows = map.GetLength(0);
        int cols = map.GetLength(1);
        var distances = new int[rows, cols];

        // Fill with max distance to indicate both:
        //  - Not visited yet
        //  - Not reachable in a small distance
        Array.Fill(distances, int.MaxValue);

        var q = new Queue<RowCol>();

        // Start by processing the start position
        q.Enqueue(start);

        // Indicate the start position is reached in 0 distance
        distances[start.Row, start.Col] = 0;

        while (q.Count > 0)
        {
            var (r, c) = q.Dequeue();
            var currentDistance = distances[r, c];

            foreach (var (deltaRow, deltaCol) in ValidMoves)
            {
                var newRow = r + deltaRow;
                var newCol = c + deltaCol;


                // Skip if new position is outside grid
                if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols)
                    continue;

                // Skip if new position is a wall
                if (map[newRow, newCol] == WALL)
                    continue;

                // Skip if already visited
                if (distances[newRow, newCol] <= currentDistance + 1)
                    continue;

                distances[newRow, newCol] = currentDistance + 1;
                q.Enqueue((newRow, newCol));
            }
        }

        return distances;
    }

    private static int GetShortestTravel(IReadOnlyCollection<int> checkPoints, int[,] distances, int start, bool returnToStart)
    {
        var shortestDistance = int.MaxValue;

        // The remaining checkpoints to visit, when starting at start
        int[] checkPointsToVisit = [.. checkPoints.Where(cp => cp != start)];

        foreach (var path in Permute(checkPointsToVisit))
        {
            var thisPathDistance = 0;
            var currentCheckPoint = start;

            foreach (var nextCheckPoint in path)
            {
                thisPathDistance += distances[currentCheckPoint, nextCheckPoint];
                currentCheckPoint = nextCheckPoint;
            }

            if (returnToStart)
                thisPathDistance += distances[currentCheckPoint, start];

            // Skip, if this solution is worse than the one we had
            if (thisPathDistance > shortestDistance)
                continue;

            // This is the best solution we have up until now
            shortestDistance = thisPathDistance;
        }

        return shortestDistance;
    }

    private static IEnumerable<int[]> Permute(int[] arr)
    {
        return PermuteInternal([.. arr], 0);

        static IEnumerable<int[]> PermuteInternal(int[] a, int start)
        {
            if (start == a.Length)
            {
                yield return (int[])a.Clone();
                yield break;
            }

            // Swap the current index with all remaining values
            for (int i = start; i < a.Length; i++)
            {
                // Swap
                (a[start], a[i]) = (a[i], a[start]);

                // Permute remaining indices
                foreach (var p in PermuteInternal(a, start + 1))
                    yield return p;

                // backtrack
                (a[start], a[i]) = (a[i], a[start]);
            }
        }
    }

}
