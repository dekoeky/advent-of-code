namespace advent_of_code._Templates.Day23;

internal static class Calculations
{
    public static uint Perform(string input, char r, Dictionary<char, uint>? registerSeedValues = null)
    {
        var instructions = Instruction.ParseMany(input);
        var i = 0;
        var registers = registerSeedValues is null
            ? []
            : registerSeedValues.ToDictionary(); // ToDictionary to prevent altering the original collection

        while (i < instructions.Count)
        {
            var instruction = instructions.ElementAt(i);
            checked
            {
                switch (instruction.Command)
                {
                    //hlf r sets register r to half its current value, then continues with the next instruction.
                    case Command.Half:
                        registers[instruction.Register] /= 2;
                        break;

                    //tpl r sets register r to triple its current value, then continues with the next instruction.
                    case Command.Triple:
                        registers[instruction.Register] *= 3;
                        break;

                    //inc r increments register r, adding 1 to it, then continues with the next instruction.
                    case Command.Increment:
                        registers[instruction.Register]++;
                        break;

                    //jmp offset is a jump; it continues with the instruction offset away relative to itself.
                    case Command.JumpOffset:
                        i += instruction.Value;
                        continue;

                    //jie r, offset is like jmp, but only jumps if register r is even ("jump if even").
                    case Command.JumpIfEven:
                        if (registers[instruction.Register] % 2 == 0)
                        {
                            i += instruction.Value;
                            continue;
                        }
                        break;

                    //jio r, offset is like jmp, but only jumps if register r is 1 ("jump if one", not odd).
                    case Command.JumpIfOne:
                        if (registers[instruction.Register] == 1)
                        {
                            i += instruction.Value;
                            continue;
                        }
                        break;
                }
            }

            i++;
        }

        return registers[r];
    }
}
