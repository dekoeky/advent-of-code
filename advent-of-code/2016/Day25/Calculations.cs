using AdventOfCode._2016.Day12;

namespace AdventOfCode._2016.Day25;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var instructions = SplitOn.NewLines(input)
            .Select(Instruction.Parse)
            .ToArray();

        return Execute(instructions);
    }

    private static int Execute(Instruction[] instructions)
    {
        int minRepeatCount = 100;
        var cpu = new InstructionProcessor
        {
            Instructions = instructions,
        };

        var initialRegisterValues = new Dictionary<char, int>()
        {
            {'a',  0 },
            {'b',  0 },
            {'c',  0 },
            {'d',  0 },
        };
        var a = 0;

        while (true) // loop till solution
        {
            // Setup the registers
            initialRegisterValues['a'] = a;
            cpu.Reset(initialRegisterValues);

            // Execute until n output values
            cpu.ExecuteUntilNOutputSignals(minRepeatCount);

            // If the signal is valid, we found a valid starting value
            if (IsValidOutSignal(cpu.OutValues)) return a;

            // We have not yet found a valid starting value, try again with a higher a value
            a++;
        }
    }

    private static bool IsValidOutSignal(IEnumerable<int> signal)
    {
        var expected = 0;

        foreach (var value in signal)
        {
            if (value != expected) return false;

            // toggle the expected value
            expected = expected == 1 ? 0 : 1;
        }

        return true;
    }
}