using advent_of_code.Helpers;

namespace advent_of_code._2024.Day06;

public static class Calculations
{
    private const char ObstructionCharacter = '#';
    //private const char VisitedCharacter = 'X';

    private const char MoveRightChar = '>';
    private const char MoveLeftChar = '<';
    private const char MoveUpChar = '^';
    private const char MoveDownChar = 'v';

    private static readonly RowCol MoveUp = new(-1, 0);
    private static readonly RowCol MoveDown = new(+1, 0);
    private static readonly RowCol MoveLeft = new(0, -1);
    private static readonly RowCol MoveRight = new(0, +1);

    //Guard Protocol:
    //If there is something directly in front of you, turn right 90 degrees.
    //    Otherwise, take a step forward.

    public static int GetPossibleLoopObstructionPositionsCount(char[,] map)
    {
        var possibleObstructions = GetPossibleObstructionPositions(map);

        var count = 0;

        foreach (var possibleObstruction in possibleObstructions)
        {
            //(Temporarily) modify the map with our new obstruction
            var original = map[possibleObstruction.Row, possibleObstruction.Col];
            map[possibleObstruction.Row, possibleObstruction.Col] = ObstructionCharacter;

            if (GetDistinctGuardPositions(map) == -1)
                count++;

            //Restore original map

            map[possibleObstruction.Row, possibleObstruction.Col] = original;
        }

        return count;
    }

    private static IEnumerable<RowCol> GetPossibleObstructionPositions(char[,] map)
    {
        for (var r = 0; r < map.GetLength(0); r++)
            for (var c = 0; c < map.GetLength(1); c++)
            {
                var character = map[r, c];

                switch (map[r, c])
                {
                    //This position already has an obstruction
                    case ObstructionCharacter:
                        continue;

                    //This is the starting position
                    case MoveDownChar:
                    case MoveLeftChar:
                    case MoveUpChar:
                    case MoveRightChar:
                        continue;

                    default:
                        yield return new RowCol(r, c);
                        break;
                };
            }
    }

    public static int GetDistinctGuardPositions(char[,] map)
    {
        var loopCount = 0;
        var maxLoopCount = map.Length;

        var rows = map.GetLength(0);
        var columns = map.GetLength(1);
        var position = GetCurrentPosition(map, out RowCol movement);
        //HashSet<RowCol> visited = [];
        //Contains locations visited, with directions visited
        Dictionary<RowCol, HashSet<RowCol>> visited = [];

        while (true)
        {
            //Mark current position as visited
            var secondVisit = !MarkVisited();

            //loop detected
            if (secondVisit)
                return -1;

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

            if (++loopCount > maxLoopCount) throw new InvalidOperationException("Loop detected");
        }

        return visited.Count;


        bool InBounds(RowCol rc)
        {
            return rc.Row >= 0 && rc.Col >= 0 && rc.Row < rows && rc.Col < columns;
        }

        //false if already visited
        bool MarkVisited()
        {
            if (!visited.TryGetValue(position, out var directionsVisited))
            {
                visited.Add(position, [movement]);
                return true;
            }
            else
            {
                //false = already present
                return directionsVisited.Add(movement);
            }
        }
    }

    private static RowCol GetCurrentPosition(char[,] map, out char movement)
    {
        for (var r = 0; r < map.GetLength(0); r++)
            for (var c = 0; c < map.GetLength(1); c++)
                switch (map[r, c])
                {
                    case MoveDownChar:
                    case MoveLeftChar:
                    case MoveUpChar:
                    case MoveRightChar:
                        movement = map[r, c];
                        return new RowCol(r, c);
                }

        throw new InvalidOperationException("Could not detect current position");
    }
    private static RowCol GetCurrentPosition(char[,] map, out RowCol movement)
    {
        var position = GetCurrentPosition(map, out char movementChar);
        movement = GetDirectionDelta(movementChar);
        return position;
    }


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