namespace AdventOfCode._2016.Day01;

readonly record struct Instruction(Rotation Rotation, int Steps)
{
    public static Instruction Parse(string input)
    {
        var rotation = Rotation.Parse(input[0]);
        var steps = int.Parse(input[1..]);

        return new Instruction(rotation, steps);
    }

    public static IEnumerable<Instruction> EnumerateInstructions(string input)
        => input.Split(',', StringSplitOptions.TrimEntries).Select(Parse);
}
