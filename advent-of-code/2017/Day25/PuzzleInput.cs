using advent_of_code.Helpers;

namespace advent_of_code._2017.Day25;

internal record PuzzleInput(char BeginState, int DiagnosticStep, Dictionary<char, StatePart> States)
{
    public static PuzzleInput Parse(string input)
    {
        var textBlocks = SplitOn.EmptyLines(input);

        var blockOneLines = SplitOn.NewLines(textBlocks[0]);
        var beginState = ParseBeginState(blockOneLines[0]);
        var diagnosticStep = ParseDiagnosticStep(blockOneLines[1]);

        var blocks = ParseBlocks([.. textBlocks.Skip(1)]);

        return new PuzzleInput(beginState, diagnosticStep, blocks);
    }

    private static char ParseBeginState(string input)
    {
        var parts = input.Split(' ');

        return parts.Last()[0];
    }

    private static int ParseDiagnosticStep(string input)
    {
        var parts = input.Split(' ');

        return int.Parse(parts[^2]);
    }

    private static Dictionary<char, StatePart> ParseBlocks(string[] blocks)
        => blocks.Select(StatePart.Parse).ToDictionary(p => p.State, p => p);
}
