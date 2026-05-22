
// Swap below for extra debug prints. Only suitable for the examples
//#define PRINT
#undef PRINT

using Point = (int x, int y);

namespace advent_of_code._2022.Day09;

internal static partial class Calculations
{
    internal static readonly Point Start = (0, 0);

    public static long Part1(ReadOnlySpan<char> input)
        => Execute(input, 2);

    public static long Part2(ReadOnlySpan<char> input)
        => Execute(input, 10);

    private static int Execute(ReadOnlySpan<char> input, int n)
    {
        var knots = new Point[n];
        Array.Fill(knots, Start); // All knots start at starting position
        HashSet<Point> tailVisited = [Start];

        PrintHeadAndTailLocation(knots);
        PrintState(knots);

        foreach (var line in input.EnumerateLines())
        {
            var move = line[0];
            var steps = int.Parse(line[2..]);
            PrintMove(move, steps);

            // Step By Step
            for (var step = 0; step < steps; step++)
            {
                // Move Head 1 step
                Move(move, 1, ref knots[0]);

                for (var k = 1; k < n; k++)
                    // knot k follows knot k-1
                    Follow(ref knots[k - 1], ref knots[k]);

                // due to the order of the loop above, moved states if the tail has moved
                //if (moved)
                tailVisited.Add(knots[^1]);
            }

            PrintHeadAndTailLocation(knots);
            PrintState(knots);
        }

        PrintSnailTrail(tailVisited);

        return tailVisited.Count;
    }

    private static void Move(char move, int steps, ref Point pt)
    {
        switch (move)
        {
            case 'U':
                pt.y -= steps;
                break;
            case 'D':
                pt.y += steps;
                break;
            case 'L':
                pt.x -= steps;
                break;
            case 'R':
                pt.x += steps;
                break;
            default: throw new InvalidOperationException($"Invalid move: '{move}'");
        }
    }

    private static void Follow(ref readonly Point head, ref Point tail)
    {
        var deltaX = head.x - tail.x;
        var deltaY = head.y - tail.y;
        var deltaXAbs = Math.Abs(deltaX);
        var deltaYAbs = Math.Abs(deltaY);

        if (deltaXAbs > 2 || deltaYAbs > 2)
            throw new InvalidOperationException();

        // Overlap, or touching -> No tail movement
        if (deltaXAbs <= 1 && deltaYAbs <= 1)
            return;


        if (deltaX != 0)
        {
            // Lets say head.x = 1 and tail.x = 3
            // --> tail needs to move left 1 (so -1)
            // DeltaX = 1 - 3 = -2
            // We need to step -1

            tail.x += Math.Sign(deltaX);
        }
        if (deltaY != 0)
        {

            tail.y += Math.Sign(deltaY);
        }
    }

    [Conditional("PRINT")]
    private static void PrintMove(char move, int steps)
        => Debug.WriteLine($"Move: {move}, steps: {steps}");

    [Conditional("PRINT")]
    private static void PrintHeadAndTailLocation(Point[] knots)
        => Debug.WriteLine($"Head: {knots[0]}, Tail: {knots[^1]}");

    [Conditional("PRINT")]
    private static void PrintState(Point[] knots)
    {
        var n = knots.Length;
        var min = new Point(-11, -15);
        var max = new Point(15, 6);

        var current = new Point();
        for (current.y = min.y; current.y < max.y; current.y++)
        {
            for (current.x = min.x; current.x < max.x; current.x++)
            {
                var symbol = '.';

                for (var k = 0; k < n; k++)
                {
                    if (current != knots[k])
                        continue;

                    symbol = k == 0 ? 'H'
                       : k == n - 1 ? 'T'
                       : (char)(k + '0');
                    break;
                }

                Debug.Write(symbol);
            }

            Debug.WriteLine();
        }
        Debug.WriteLine();
        Debug.WriteLine();
    }

    private static void PrintSnailTrail(HashSet<Point> visited)
    {
        var minX = int.MaxValue;
        var minY = int.MaxValue;
        var maxX = int.MinValue;
        var maxY = int.MinValue;

        foreach (var (x, y) in visited)
        {
            minX = Math.Min(minX, x);
            minY = Math.Min(minY, y);
            maxX = Math.Max(maxX, x);
            maxY = Math.Max(maxY, y);
        }
        Debug.WriteLine("Snail Trail:");
        var current = new Point();
        for (current.y = minY; current.y <= maxY; current.y++)
        {
            for (current.x = minX; current.x <= maxX; current.x++)
            {
                if (current == Start)
                    Debug.Write('s');
                else if (visited.Contains(current))
                    Debug.Write('#');
                else
                    Debug.Write('.');
            }

            Debug.WriteLine();
        }
        Debug.WriteLine();
        Debug.WriteLine();
    }
}