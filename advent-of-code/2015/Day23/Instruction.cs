namespace advent_of_code._Templates.Day23;

public record Instruction(Command Command, char Register, int Value)
{
    public static Instruction Parse(ReadOnlySpan<char> input)
    {
        var cmd = input[..3] switch
        {
            "hlf" => Command.Half,
            "tpl" => Command.Triple,
            "inc" => Command.Increment,
            "jmp" => Command.JumpOffset,
            "jie" => Command.JumpIfEven,
            "jio" => Command.JumpIfOne,
            _ => throw new NotImplementedException($"Invalid Command: '{input[..3]}'"),
        };

        var register = cmd switch
        {
            // this command has no register
            Command.JumpOffset => default,

            _ => input[4],
        };

        var offset = cmd switch
        {
            Command.JumpOffset => int.Parse(input[4..]),

            Command.JumpIfEven or Command.JumpIfOne => int.Parse(input[7..]),

            _ => 0,
        };

        return new Instruction(cmd, register, offset);
    }

    public static IReadOnlyCollection<Instruction> ParseMany(ReadOnlySpan<char> input)
    {
        var instructions = new List<Instruction>();

        foreach (var item in input.EnumerateLines())
            instructions.Add(Parse(item));

        return instructions;
    }
}