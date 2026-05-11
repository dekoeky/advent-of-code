namespace advent_of_code._2018.Day16;

public record PuzzleInput(PuzzleSample[] Samples, PuzzleInstruction[] Instructions)
{
    public static PuzzleInput Parse(ReadOnlySpan<char> input)
    {
        var samples = new List<PuzzleSample>();
        PuzzleInstruction[] instructions = [];

        foreach (var block in input.EnumerateBlocks())
            if (block.Contains('['))
                samples.Add(PuzzleSample.Parse(block));
            else
                instructions = PuzzleInstruction.ParseMany(block);

        return new PuzzleInput([.. samples], instructions);
    }
}
