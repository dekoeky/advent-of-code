namespace advent_of_code._2018.Day10;

internal readonly record struct Velocity(int X, int Y)
{
    public static Velocity Parse(ReadOnlySpan<char> input)
    {
        var comma = input.IndexOf(',');
        
        var x = int.Parse(input[..comma]);
        var y = int.Parse(input[(comma + 1)..]);
        
        return new Velocity(x, y);
    }
}