namespace AdventOfCode._2017.Day19;

internal static class Calculations
{
    const char Vertical = '|';
    const char Horizontal = '-';
    const char Crossing = '+';
    const char EMPTY = ' ';

    public static string TracePacket(string input, out int steps)
    {
        var diagram = input.To2DArray();

        var (start, direction) = DetectStart(diagram);

        return Walk(diagram, start, direction, out steps);
    }

    private static string Walk(char[,] diagram, RowCol start, RowCol movementDirection, out int steps)
    {
        List<char> collectedCharacters = [];
        var position = start;
        var previous = diagram[start.Row, start.Col];
        steps = 0;

        while (true)
        {
            // Move
            position += movementDirection;
            steps++;

            var current = diagram[position.Row, position.Col];

            if (current == previous)
                continue; // Keep going!
            else if (char.IsLetter(current))
                collectedCharacters.Add(current); // Collect the letter
            else if ((previous == Vertical && current == Horizontal) || (previous == Horizontal && current == Vertical))
                continue; // JUMP!
            else if (current == Crossing)
                movementDirection = DetectCrossingDirection(diagram, position, movementDirection); // Where should we go next?
            else if (current == ' ')
                break; // Finished!
            else throw new InvalidOperationException();
        }

        return new string([.. collectedCharacters]);
    }

    private static (RowCol Start, RowCol Direction) DetectStart(char[,] diagram)
    {
        // Assuming the start is always vertical, and topside

        for (var c = 0; c < diagram.GetLength(1); c++)
            if (diagram[0, c] == Vertical)
                return (new RowCol(0, c), RowCol.Down);

        throw new InvalidOperationException();
    }

    private static RowCol DetectCrossingDirection(char[,] diagram, RowCol position, RowCol currentDirection)
    {
        RowCol[] candidates;
        if (currentDirection == RowCol.Left || currentDirection == RowCol.Right)
            candidates = [RowCol.Up, RowCol.Down];

        else if (currentDirection == RowCol.Up || currentDirection == RowCol.Down)
            candidates = [RowCol.Left, RowCol.Right];

        else throw new InvalidOperationException();

        RowCol[] newPositions = [position + candidates[0], position + candidates[1]];

        var candidate1valid = diagram.TryGet(newPositions[0], out var p1) && p1 != EMPTY;
        var candidate2valid = diagram.TryGet(newPositions[1], out var p2) && p2 != EMPTY;

        return (candidate1valid, candidate2valid) switch
        {
            (true, false) => candidates[0],
            (false, true) => candidates[1],
            _ => throw new InvalidOperationException()
        };
    }
}

internal static class Extensions
{
    extension(char[,] array)
    {
        public char Get(RowCol rc) => array[rc.Row, rc.Col];
        public bool TryGet(RowCol rc, out char result)
        {
            if (rc.Row < 0 || rc.Col < 0 || rc.Row >= array.GetLength(0) || rc.Col >= array.GetLength(1))
            {
                result = default;
                return false;
            }

            result = array[rc.Row, rc.Col];
            return true;
        }
    }
}