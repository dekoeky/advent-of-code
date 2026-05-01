namespace AdventOfCode._2021.Day09;

internal record struct LowPoint(Point Position, int Height)
{
    public static implicit operator (int, int, int)(LowPoint value)
    {
        return (value.Position.Row, value.Position.Col, value.Height);
    }

    public static implicit operator LowPoint((int, int, int) value)
    {
        return new LowPoint(new Point(value.Item1, value.Item2), value.Item3);
    }
}