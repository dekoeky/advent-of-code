namespace advent_of_code._2025.Day12;

internal readonly record struct Size(int Width, int Height)
{
    public static Size Parse(ReadOnlySpan<char> input)
    {
        var x = input.IndexOf('x');

        var w = int.Parse(input[..x++]);
        var h = int.Parse(input[x..]);

        return new Size(w, h);
    }

    public readonly int Area { get; } = Width * Height;

    public override string ToString() => $"{Width}x{Height}";
}
