namespace advent_of_code._2016.Day12;


internal record IncreaseInstruction(char Register) : Instruction;
internal record DecreaseInstruction(char Register) : Instruction;
internal record CopyValueInstruction(int Value, char TargetRegister) : Instruction;
internal record CopyRegisterInstruction(char SourceRegister, char TargetRegister) : Instruction;
internal record JumpIfValueNotZeroInstruction(int Value, int Offset) : Instruction;
internal record JumpIfRegisterNotZeroInstruction(char Register, int Offset) : Instruction;

internal abstract record Instruction
{
    public static Instruction Parse(string input)
    {
        var parts = input.Split(' ');

        switch (parts[0])
        {
            case "inc": return new IncreaseInstruction(parts[1][0]); // [0] = first character, assuming single character id
            case "dec": return new DecreaseInstruction(parts[1][0]); // [0] = first character, assuming single character id
            case "cpy":
                // Part 2 = Always a register
                var targetRegister = parts[2][0];
                return int.TryParse(parts[1], out var copyValye)
                    ? new CopyValueInstruction(copyValye, targetRegister)
                    : new CopyRegisterInstruction(parts[1][0], targetRegister);

            case "jnz":

                // Part 2 = Always an offset
                var offset = int.Parse(parts[2]);
                return int.TryParse(parts[1], out var jumpValue)
                    ? new JumpIfValueNotZeroInstruction(jumpValue, offset)
                    : new JumpIfRegisterNotZeroInstruction(parts[1][0], offset);

            default: throw new InvalidOperationException();
        }
    }
}