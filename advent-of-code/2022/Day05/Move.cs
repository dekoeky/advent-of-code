namespace AdventOfCode._2022.Day05;

internal readonly record struct Move(int Count, int From, int To)
{
    public static Move[] ParseMany(string input)
        => [.. SplitOn.NewLines(input).Select(Move.Parse)];

    public static Move Parse(string input)
    {
        var parts = input.Split(' ');

        return new Move(
            int.Parse(parts[1]),
            int.Parse(parts[3]),
            int.Parse(parts[5])
            );
    }
}
