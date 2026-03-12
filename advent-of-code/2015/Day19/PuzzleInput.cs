using advent_of_code.Helpers;

namespace advent_of_code._Templates.Day19;

internal record PuzzleInput(Replacement[] Replacements, string Input)
{
    public static PuzzleInput Parse(string input)
    {
        var parts = SplitOn.EmptyLines(input);

        return new PuzzleInput(Replacement.ParseMany(parts[0]), parts[1]);
    }
}
