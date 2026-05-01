namespace AdventOfCode._2016.Day01;

internal static class Calculations
{
    public static int BlocksAwayAfterFollowingInstructions(string input)
    {
        var start = new BlockPosition();
        var position = start;
        var direction = Direction.North;

        foreach (var instruction in Instruction.EnumerateInstructions(input))
        {
            // Rotate to new direction
            direction = direction.Rotate(instruction.Rotation);

            // Walk in that direction
            position.Walk(direction, instruction.Steps);
        }

        return position.DistanceInBlocks(start);
    }

    public static int BlocksAwayAfterSecondVisit(string input)
    {
        var start = new BlockPosition();
        var visited = new HashSet<BlockPosition>() { start };
        var position = start;
        var direction = Direction.North;

        foreach (var instruction in Instruction.EnumerateInstructions(input))
        {
            // Rotate to new direction
            direction = direction.Rotate(instruction.Rotation);

            // Walk in that direction, step by step
            for (int step = 0; step < instruction.Steps; step++)
            {
                position.Walk(direction, 1);
                Debug.WriteLine(position);

                if (!visited.Add(position))
                    return position.DistanceInBlocks(start);
            }
        }

        throw new InvalidOperationException("No location visited twice");
    }
}
