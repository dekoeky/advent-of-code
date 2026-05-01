namespace AdventOfCode._2016.Day01;

internal static class DirectionExtensions
{

    extension(Direction direction)
    {
        public static Direction Parse(char s) => s switch
        {
            'N' => Direction.North,
            'E' => Direction.East,
            'S' => Direction.South,
            'W' => Direction.West,
            _ => throw new NotImplementedException(),
        };
        public Direction Rotate(Rotation rotation) => rotation switch
        {
            Rotation.Left => (Direction)(((int)direction + 3) % 4),
            Rotation.Right => (Direction)(((int)direction + 1) % 4),
            _ => throw new NotImplementedException(),
        };
    }
}