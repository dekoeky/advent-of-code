namespace AdventOfCode._2015.Day19;

internal record Replacement(string From, string To)
{
    /// <summary>
    /// The influence on the length of a string after replacing <see cref="From"/> by <see cref="To"/>.
    /// </summary>
    public int Delta { get; init; } = To.Length - From.Length;

    public static Replacement Parse(string input)
    {
        var parts = input.Split("=>", StringSplitOptions.TrimEntries);
        return new(parts[0], parts[1]);
    }

    public static Replacement[] ParseMany(string input) => SplitOn.NewLines(input).Select(Parse).ToArray();

    public override string ToString() => $"{From} => {To}";
}