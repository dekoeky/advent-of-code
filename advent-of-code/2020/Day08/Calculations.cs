namespace advent_of_code._2020.Day08;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var i = 0;
        var instructions = Instruction.ParseMany(input);
        var accumulator = 0;
        var visited = new HashSet<int>(instructions.Length);

        while (true)
        {
            if (i >= instructions.Length) return accumulator;
            if (!visited.Add(i)) return accumulator;

            var instruction = instructions[i];

            switch (instruction.Type)
            {
                case InstructionType.Nop:
                    i++;
                    break;

                case InstructionType.Acc:
                    accumulator += instruction.Value;
                    i++;
                    break;

                case InstructionType.Jmp:
                    i += instruction.Value;
                    break;
            }
        }
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        var instructions = Instruction.ParseMany(input);
        var correctedInstructions = new Instruction[instructions.Length];

        // Attempt to switch each instruction one by one
        for (var i = 0; i < instructions.Length; i++)
        {
            if (instructions[i].Type == InstructionType.Acc) continue;

            Array.Copy(instructions, correctedInstructions, instructions.Length);

            correctedInstructions[i].Type = instructions[i].Type switch
            {
                InstructionType.Nop => InstructionType.Jmp,
                InstructionType.Jmp => InstructionType.Nop,
                _ => throw new InvalidOperationException()
            };

            if (TryRunTillEnd(correctedInstructions, out var accumulator))
                return accumulator;
        }

        throw new InvalidOperationException("No solution found");
    }

    private static bool TryRunTillEnd(Instruction[] instructions, out int accumulator)
    {
        var i = 0;
        accumulator = 0;
        var visited = new HashSet<int>(instructions.Length);

        while (true)
        {
            // We ran off the end --> Good
            if (i >= instructions.Length)
                return true;

            // We visited an instruction twice -- Bad
            if (!visited.Add(i))
                return false;

            var instruction = instructions[i];

            switch (instruction.Type)
            {
                case InstructionType.Nop:
                    i++;
                    break;

                case InstructionType.Acc:
                    accumulator += instruction.Value;
                    i++;
                    break;

                case InstructionType.Jmp:
                    i += instruction.Value;
                    break;
            }
        }
    }
}
