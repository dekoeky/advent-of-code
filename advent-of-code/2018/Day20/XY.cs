namespace advent_of_code._2018.Day20;

internal record struct XY(int X, int Y)
{
    public static implicit operator (int x, int y)(XY value)
        => (value.X, value.Y);

    public static implicit operator XY((int x, int y) value)
        => new(value.x, value.y);
}