namespace advent_of_code._2018.Day16;

public record PuzzleSample(int[] Before, PuzzleInstruction Instruction, int[] After)
{
    public static PuzzleSample Parse(ReadOnlySpan<char> input)
    {
        var lines = input.EnumerateLines();

        lines.MoveNext();
        var before = ParseBrackets(lines.Current);

        lines.MoveNext();
        var instruction = PuzzleInstruction.Parse(lines.Current);

        lines.MoveNext();
        var after = ParseBrackets(lines.Current);

        return new PuzzleSample(before, instruction, after);
    }

    private static int[] ParseBrackets(ReadOnlySpan<char> input)
    {
        var start = input.IndexOf('[') + 1;
        var end = input.IndexOf(']');
        input = input[new Range(start, end)];

        Span<Range> ranges = stackalloc Range[4];
        input.Split(ranges, ',', StringSplitOptions.TrimEntries);

        var result = new int[4];

        for (var i = 0; i < 4; i++)
            result[i] = int.Parse(input[ranges[i]]);

        return result;
    }
}