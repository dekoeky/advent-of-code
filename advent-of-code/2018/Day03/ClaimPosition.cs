namespace AdventOfCode._2018.Day03;

internal record struct ClaimPosition(int Left, int Top)
{
    public static ClaimPosition Parse(string input)
    {
        var parts = input.Split(',');

        return new ClaimPosition(
            int.Parse(parts[0]),
            int.Parse(parts[1])
            );
    }
}