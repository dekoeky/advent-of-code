namespace advent_of_code._2018.Day16;

public record PuzzleInstruction(int OpCode, int A, int B, int C)
{
    public static PuzzleInstruction Parse(ReadOnlySpan<char> input)
    {
        Span<Range> ranges = stackalloc Range[4];
        input.Split(ranges, ' ', StringSplitOptions.RemoveEmptyEntries);

        Span<int> result = stackalloc int[4];

        for (var i = 0; i < 4; i++)
            result[i] = int.Parse(input[ranges[i]]);

        return new PuzzleInstruction(result[0], result[1], result[2], result[3]);
    }

    public static PuzzleInstruction[] ParseMany(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;

        var instructions = new PuzzleInstruction[n];
        var i = 0;

        foreach (var line in input.EnumerateLines())
            instructions[i++] = Parse(line);

        return instructions;
    }
}
