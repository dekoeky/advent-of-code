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

        var cpu = new InstructionProcessor
        {
            Instructions = instructions,
            Registers = registers,
        };

        cpu.ExecuteTillFinished();

        return cpu.Registers['a'];
    }
}
