using advent_of_code.Helpers;

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
        var offset = (Rows: rows / 2, Cols: cols / 2);

        HashSet<(int Row, int Col)> infected = [];

        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
                if (map[r, c] == Infected)
                    infected.Add((r - offset.Rows, c - offset.Cols));

        var direction = Direction.Up;
        var position = (Row: 0, Col: 0);
        var infections = 0;

        for (var b = 0; b < bursts; b++)
        {
            // Step 1.
            // If the current node is infected, it turns to its right.
            if (infected.Contains(position))
                direction = direction.RotateRight();
            // Otherwise, it turns to its left. (Turning is done in-place; the current node does not change.)
            else
                direction = direction.RotateLeft();

            // Step 2.
            // If the current node is clean, it becomes infected.
            if (!infected.Contains(position))
            {
                infected.Add(position);
                infections++;
            }
            // Otherwise, it becomes cleaned. (This is done after the node is considered for the purposes of changing direction.)
            else
            {
                infected.Remove(position);
            }

            // Step 3.
            // The virus carrier moves forward one node in the direction it is facing.
            var step = direction.GetStep();
            position = (position.Row + step.Rows, position.Col + step.Cols);
        }

        return infections;
    }


    public static int Part2(string input, int bursts)
    {
        var map = input.To2DArray();
        var rows = map.GetLength(0);
        var cols = map.GetLength(1);
        var offset = (Rows: rows / 2, Cols: cols / 2);

        Dictionary<(int Row, int Col), State> states = [];

        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
                if (map[r, c] == Infected)
                    states.Add((r - offset.Rows, c - offset.Cols), State.Infected);

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
            var step = direction.GetStep();
            pos = (pos.Row + step.Rows, pos.Col + step.Cols);
        }

        return infections;
    }
}
