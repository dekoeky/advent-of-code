namespace advent_of_code._2020.Day08;

internal record struct Instruction(InstructionType Type, int Value)
{
    public static Instruction[] ParseMany(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var i = 0;
        var result = new Instruction[n];

        foreach (var line in input.EnumerateLines())
            result[i++] = Parse(line);

        return result;
    }

    public static Instruction Parse(ReadOnlySpan<char> input)
    {
        var type = input[..3] switch
        {
            "nop" => InstructionType.Nop,
            "acc" => InstructionType.Acc,
            "jmp" => InstructionType.Jmp,
            _ => throw new NotImplementedException(),
        };

        var value = int.Parse(input[4..]);

        return new Instruction(type, value);
    }
}