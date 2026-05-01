namespace AdventOfCode._2017.Day22;

public static class DirectionExtensions
{
    extension(Direction dir)
    {
        public Direction RotateRight() => (Direction)(((int)dir + 1) % 4);
        public Direction Reverse() => (Direction)(((int)dir + 2) % 4);
        public Direction RotateLeft() => (Direction)(((int)dir + 3) % 4);
        public (int Rows, int Cols) GetStep() => dir switch
        {
            Direction.Up => (-1, 0),
            Direction.Right => (0, +1),
            Direction.Down => (+1, 0),
            Direction.Left => (0, -1),
            _ => throw new NotImplementedException(),
        };
    }
}