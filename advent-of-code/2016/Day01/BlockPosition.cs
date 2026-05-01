namespace AdventOfCode._2016.Day01;

internal record struct BlockPosition(int North, int East)
{
    public void Walk(Direction direction, int steps)
    {
        switch (direction)
        {
            case Direction.North: North += steps; break;
            case Direction.East: East += steps; break;
            case Direction.South: North -= steps; break;
            case Direction.West: East -= steps; break;
        }
    }

    public int DistanceInBlocks(BlockPosition other)
        => Math.Abs(other.North - North) + Math.Abs(other.East - East);
}