namespace advent_of_code._2018.Day10;

internal record struct Position
{
    public int X;
    public int Y;

    public static Position Parse(ReadOnlySpan<char> input)
    {
        var comma = input.IndexOf(',');

        var x = int.Parse(input[..comma]);
        var y = int.Parse(input[(comma + 1)..]);

        return new Position
        {
            X = x,
            Y = y,
        };
    }
}