namespace advent_of_code._2015.Day18;

internal static class Calculations
{
    const char ON = '#';
    const char OFF = '.';

    public static int LightsOnAfterNSteps(string input, int steps, bool cornerLightsStuck)
    {
        var grid = Grid.Parse(input);

        var last = Animate(grid, steps, cornerLightsStuck).Last();
        var lightsOn = last.Count(l => l == ON);

        return lightsOn;
    }

    static IEnumerable<char[,]> Animate(char[,] grid, int steps, bool cornerLightsStuck)
    {
        if (cornerLightsStuck) grid.WriteCorners(ON);

        Debug.WriteLine("Initial state:");
        grid.PrintDebug();

        for (int i = 0; i < steps; i++)
        {
            grid = CalculateNewState(grid);
            if (cornerLightsStuck) grid.WriteCorners(ON);

            Debug.WriteLine($"After {i + 1} step{(i > 2 ? 's' : null)}:");
            grid.PrintDebug();

            yield return grid;
        }
    }

    static char[,] CalculateNewState(char[,] current)
    {
        var next = new char[current.GetLength(0), current.GetLength(1)];

        // Copy current state
        //Array.Copy(current, next, current.Length);

        for (var r = 0; r < current.GetLength(0); r++)
            for (var c = 0; c < current.GetLength(1); c++)
            {
                var value = current[r, c];

                if (value == ON)
                {
                    // check if it goes OFF
                    // A light which is on stays on when 2 or 3 neighbors are on, and turns off otherwise.
                    if (current.CountNeighbors(r, c, n => n == ON) is < 2 or > 3)
                    {
                        // light goes off
                        next[r, c] = OFF;
                    }
                    else
                    {
                        // light stays on
                        next[r, c] = ON;
                    }
                }
                else // assume OFF
                {
                    // check if goes ON
                    // A light which is off turns on if exactly 3 neighbors are on, and stays off otherwise.
                    if (current.CountNeighbors(r, c, n => n == ON) is 3)
                    {
                        // light goes ON
                        next[r, c] = ON;
                    }
                    else
                    {
                        // light stays OFF
                        next[r, c] = OFF;
                    }
                }
            }


        return next;
    }
}
