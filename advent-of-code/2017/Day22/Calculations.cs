namespace advent_of_code._2017.Day22;

internal static class Calculations
{
    private const char Clean = '.';
    private const char Infected = '#';

    public static int Perform(string input, int bursts)
    {
        var map = input.To2DArray();
        var rows = map.GetLength(0);
        var cols = map.GetLength(1);
        var (offsetR, offsetC) = (rows / 2, cols / 2);

        HashSet<(int Row, int Col)> infected = [];

        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
                if (map[r, c] == Infected)
                    infected.Add((r - offsetR, c - offsetC));

        var direction = Direction.Up;
        var position = (Row: 0, Col: 0);
        var infections = 0;

        for (var b = 0; b < bursts; b++)
        {
            if (infected.Contains(position))
            {
                // Step 1.
                direction = direction.RotateRight();

                // Step 2.
                infected.Remove(position);
            }
            else
            {
                // Step 1.
                direction = direction.RotateLeft();

                // Step 2.
                infected.Add(position);
                infections++;
            }


            // Step 3.
            // The virus carrier moves forward one node in the direction it is facing.
            var (stepR, stepC) = direction.GetStep();
            position = (position.Row + stepR, position.Col + stepC);
        }

        return infections;
    }


    public static int Part2(string input, int bursts)
    {
        var map = input.To2DArray();
        var rows = map.GetLength(0);
        var cols = map.GetLength(1);
        var (offsetR, offsetC) = (rows / 2, cols / 2);

        Dictionary<(int Row, int Col), State> states = [];

        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
                if (map[r, c] == Infected)
                    states.Add((r - offsetR, c - offsetC), State.Infected);

        var direction = Direction.Up;
        var pos = (Row: 0, Col: 0);
        var infections = 0;

        for (var b = 0; b < bursts; b++)
        {
            var state = states.GetValueOrDefault(pos, State.Clean);

            // Step 1.
            direction = state switch
            {
                State.Clean => direction.RotateLeft(),
                State.Weakened => direction,
                State.Infected => direction.RotateRight(),
                State.Flagged => direction.Reverse(),
                _ => throw new NotImplementedException(),
            };

            // Step 2.
            switch (state)
            {
                case State.Clean:
                    states[pos] = State.Weakened; break;
                case State.Weakened:
                    states[pos] = State.Infected;
                    infections++;
                    break;
                case State.Infected:
                    states[pos] = State.Flagged; break;
                case State.Flagged:
                    states[pos] = State.Clean; break;


            }

            // Step 3.
            // The virus carrier moves forward one node in the direction it is facing.
            var (stepR, stepC) = direction.GetStep();
            pos = (pos.Row + stepR, pos.Col + stepC);
        }

        return infections;
    }
}
