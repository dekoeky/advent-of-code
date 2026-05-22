namespace advent_of_code._2021.Day05;

internal readonly record struct Point(int X, int Y)
{
    public static Point Parse(ReadOnlySpan<char> input)
    {
        var splitter = input.IndexOf(',');

        var x = int.Parse(input[..splitter++]);
        var y = int.Parse(input[splitter..]);

        return new Point(x, y);
    }
}
