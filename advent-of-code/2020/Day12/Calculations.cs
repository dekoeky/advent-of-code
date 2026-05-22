namespace advent_of_code._2020.Day12;

internal static partial class Calculations
{
    public static long Part1(ReadOnlySpan<char> input)
    {
        var orientation = Orientation.E;
        (int x, int y) = (0, 0);

        foreach (var line in input.EnumerateLines())
        {
            var move = line[0];
            var amount = int.Parse(line[1..]);

            switch (move)
            {
                case 'L':
                    orientation = (Orientation)(((int)orientation - amount + 360) % 360);
                    break;

                case 'R':
                    orientation = (Orientation)(((int)orientation + amount) % 360);
                    break;

                case 'N':
                case 'F' when orientation == Orientation.N:
                    y -= amount; break;

                case 'E':
                case 'F' when orientation == Orientation.E:
                    x += amount; break;

                case 'S':
                case 'F' when orientation == Orientation.S:
                    y += amount; break;

                case 'W':
                case 'F' when orientation == Orientation.W:
                    x -= amount; break;

                default: break;
            }
        }

        return Math.Abs(x) + Math.Abs(y);
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        // Ship position
        (int x, int y) pos = (0, 0);

        // Waypoint relative to ship: 10 east, 1 north
        (int x, int y) wp = (10, -1);

        foreach (var line in input.EnumerateLines())
        {
            var move = line[0];
            var amount = int.Parse(line[1..]);

            switch (move)
            {
                case 'N': wp.y -= amount; break;
                case 'S': wp.y += amount; break;
                case 'E': wp.x += amount; break;
                case 'W': wp.x -= amount; break;

                case 'L':
                    Rotate(ref wp.x, ref wp.y, 360 - amount);
                    break;

                case 'R':
                    Rotate(ref wp.x, ref wp.y, amount);
                    break;

                case 'F':
                    pos.x += wp.x * amount;
                    pos.y += wp.y * amount;
                    break;

                default: break;
            }
        }

        return Math.Abs(pos.x) + Math.Abs(pos.y);
    }

    private static void Rotate(ref int x, ref int y, int deg)
    {
        deg %= 360;
        if (deg == 0) return;

        switch (deg)
        {
            case 90:
                (x, y) = (-y, x);
                break;

            case 180:
                x = -x;
                y = -y;
                break;

            case 270:
                (x, y) = (y, -x);
                break;
        }
    }
}