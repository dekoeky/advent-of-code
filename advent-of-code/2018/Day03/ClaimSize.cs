namespace AdventOfCode._2018.Day03;

internal record struct ClaimSize(int Width, int Height)
{
    public static ClaimSize Parse(string input)
    {
        var parts = input.Split('x');

        return new ClaimSize(
            int.Parse(parts[0]),
            int.Parse(parts[1])
            );
    }
}
