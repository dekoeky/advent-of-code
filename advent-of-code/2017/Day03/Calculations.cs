namespace advent_of_code._2017.Day03;

internal static class Calculations
{
    public static int Part1(int input)
    {
        // 17  16  15  14  13
        // 18   5   4   3  12
        // 19   6   1   2  11
        // 20   7   8   9  10
        // 21  22  23---> ...

        // up to     WxH
        // ->   1    1x1
        // ->   9    3x3
        // ->  25    5x5
        // ->  49    7x7

        // values from  1 to  1 lie on the outside ring of a 1x1 square
        // values from  2 to  9 lie on the outside ring of a 3x3 square
        // values from 10 to 25 lie on the outside ring of a 5x5 square
        // ...


        // largest number in layer n = (2n + 1)²
        // so to get the layer =>    (sqrt(input)-1)/


        var layer = GetLayer(input);

        var distance = layer + Offset(input, layer);

        return distance;
    }

    public static int GetLayer(int input) => (int)Math.Ceiling((Math.Sqrt(input) - 1) / 2);

    public static int GetMaxValueOnLayer(int layer) => (2 * layer + 1) * (2 * layer + 1);
    public static int SideLength(int layer) => 2 * layer;


    public static int Offset(int n, int layer)
    {
        // The largest value in this spiral layer.
        var max = GetMaxValueOnLayer(layer);

        // Each side of the square has length 2*layer.
        // The "midpoints" of the four sides are the positions where
        // the Manhattan distance to the center is minimal for this layer.

        // Corners are spaced 2L apart, and the midpoint is L steps before each corner.
        int m1 = max - layer;        // midpoint of side 1
        int m2 = max - 3 * layer;    // midpoint of side 2
        int m3 = max - 5 * layer;    // midpoint of side 3
        int m4 = max - 7 * layer;    // midpoint of side 4


        // The offset is the distance from n to the closest midpoint.
        // This determines how far n is horizontally/vertically
        // from the "ideal" center of its side.

        var d1 = Math.Abs(n - m1);
        var d2 = Math.Abs(n - m2);
        var d3 = Math.Abs(n - m3);
        var d4 = Math.Abs(n - m4);

        return Math.Min(
            Math.Min(d1, d2),
            Math.Min(d3, d4)
        );
    }

    private static readonly (int dx, int dy)[] Directions =
     [
        // In order of precedence

        (1, 0),  // right (starting direction)
        (0, 1),  // up
        (-1, 0), // left
        (0, -1)  // down
    ];

    private static readonly (int dx, int dy)[] Neighbors =
     [
        (-1,-1), (0,-1), (1,-1),
        (-1, 0),         (1, 0),
        (-1, 1), (0, 1), (1, 1)
    ];


    public static int Part2(int input)
    {

        // 147  142  133  122   59
        // 304    5    4    2   57
        // 330   10    1    1   54
        // 351   11   23   25   26
        // 362  747  806--->   ...

        // Move right   1
        // Move up      1
        // Move left    2
        // Move down    2
        // Move right   3
        // Move up      3
        // Move left    4
        // Move down    4
        // ...

        // So always 2 moves of an increasing step size, in a left spiraling direction


        var grid = new Dictionary<(int, int), int>
        {
            [(0, 0)] = 1
        };

        int x = 0, y = 0;
        int stepSize = 1;
        int dirIndex = 0;

        while (true)
        {
            // Repeat the current step size twice, before increasing
            for (int repeat = 0; repeat < 2; repeat++)
            {
                // Lookup current movement direction
                var (dx, dy) = Directions[dirIndex];

                // Make steps up until the step size
                for (int step = 0; step < stepSize; step++)
                {
                    x += dx;
                    y += dy;

                    // Calculate the sum of all neighbors
                    var sum = 0;
                    foreach (var (nx, ny) in Neighbors)
                        if (grid.TryGetValue((x + nx, y + ny), out int v))
                            sum += v;

                    // We reached a solution, if the value is (the first value that is) larger than the input
                    if (sum > input)
                        return sum;

                    // Store the value for later use
                    grid[(x, y)] = sum;
                }

                // Turn left
                dirIndex = (dirIndex + 1) % 4;
            }

            stepSize++;
        }
    }
}