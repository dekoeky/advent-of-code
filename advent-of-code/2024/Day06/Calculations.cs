namespace advent_of_code._2024.Day06;

public static class Calculations
{
    private const char ObstructionCharacter = '#';
    private const char VisitedCharacter = 'X';

    private const char MoveRightChar = '>';
    private const char MoveLeftChar = '<';
    private const char MoveUpChar = '^';
    private const char MoveDownChar = 'v';

    //Guard Protocol:
    //If there is something directly in front of you, turn right 90 degrees.
    //    Otherwise, take a step forward.



    public static int GetDistinctGuardPositions(char[,] map)
    {
        var rows = map.GetLength(0);
        var columns = map.GetLength(1);
        var position = GetCurrentPosition(map, out var movement);
        HashSet<RowCol> visited = [];

        while (true)
        {
            //Mark current position as visited
            visited.Add(position);

            //Calculate new position
            var newPos = position + movement;

            //Check if we reached the border
            if (!InBounds(newPos)) break;

            if (map[newPos.Row, newPos.Col] == ObstructionCharacter)
            {
                movement = RotateRight(movement);
                continue;
            }

            position = newPos;
        }

        return visited.Count;


        bool InBounds(RowCol rc)
        {
            return rc.Row >= 0 && rc.Col >= 0 && rc.Row < rows && rc.Col < columns;
        }
    }

    private static RowCol GetCurrentPosition(char[,] map, out RowCol movement)
    {
        for (var r = 0; r < map.GetLength(0); r++)
        for (var c = 0; c < map.GetLength(1); c++)
            switch (map[r, c])
            {
                case MoveDownChar:
                case MoveLeftChar:
                case MoveUpChar:
                case MoveRightChar:
                    movement = GetDirectionDelta(map[r, c]);
                    return new RowCol(r, c);
            }

        throw new InvalidOperationException("Could not detect current position");
    }

    private static readonly RowCol MoveUp = new(-1, 0);
    private static readonly RowCol MoveDown = new(+1, 0);
    private static readonly RowCol MoveLeft = new(0, -1);
    private static readonly RowCol MoveRight = new(0, +1);

    private static RowCol GetDirectionDelta(char direction) => direction switch
    {
        MoveDownChar => MoveDown,
        MoveUpChar => MoveUp,
        MoveRightChar => MoveRight,
        MoveLeftChar => MoveLeft,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
    };

    private static RowCol RotateRight(RowCol currentMovement)
    {
        if (currentMovement == MoveUp)
            return MoveRight;

        if (currentMovement == MoveRight)
            return MoveDown;

        if (currentMovement == MoveDown)
            return MoveLeft;

        if (currentMovement == MoveLeft)
            return MoveUp;

        throw new ArgumentOutOfRangeException(nameof(currentMovement));
    }
}