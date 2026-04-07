using advent_of_code._2016.Day12.Instructions;
using advent_of_code.Helpers;

namespace advent_of_code._2016.Day12;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var initialValues = new Dictionary<char, int>
        {
            { 'a', 0 },
            { 'b', 0 },
            { 'c', 0 },
            { 'd', 0 },
        };

        return Execute(input, initialValues);
    }
    public static int Part2(string input)
    {
        var initialValues = new Dictionary<char, int>
        {
            { 'a', 0 },
            { 'b', 0 },
            { 'c', 1 },
            { 'd', 0 },
        };

        return Execute(input, initialValues);
    }

    private static int Execute(string input, Dictionary<char, int> registers)
    {
        var instructions = SplitOn.NewLines(input)
            .Select(Instruction.Parse)
            .ToArray();

        var nextInstruction = 0;

        while (nextInstruction >= 0 && nextInstruction < instructions.Length)
        {
            var instruction = instructions[nextInstruction];

            switch (instruction)
            {
                case CopyValueInstruction cv:
                    registers[cv.TargetRegister] = cv.Value;
                    break;

                case CopyRegisterInstruction cr:
                    registers[cr.TargetRegister] = registers[cr.SourceRegister];
                    break;

                case IncreaseInstruction inc:
                    registers[inc.Register]++;
                    break;

                case DecreaseInstruction dec:
                    registers[dec.Register]--;
                    break;

                case JumpIfValueNotZeroInstruction jv:
                    if (jv.Value == 0)
                        break;

                    nextInstruction += jv.Offset;
                    continue;

                case JumpIfRegisterNotZeroInstruction jr:
                    if (registers[jr.Register] == 0)
                        break;

                    nextInstruction += jr.Offset;
                    continue;

                default: throw new NotImplementedException();
            }

            nextInstruction++;
        }

        return registers['a'];
    }
}