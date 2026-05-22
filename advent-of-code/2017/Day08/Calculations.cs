namespace advent_of_code._2017.Day08;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var registers = Execute(input, out _);

        return registers.Values.Max();
    }

    public static int Part2(string input)
    {
        var registers = Execute(input, out var max);

        return max;
    }

    private static Dictionary<string, int> Execute(string input, out int max)
    {
        var instructions = Parse(input);
        var registers = new Dictionary<string, int>();

        max = 0;
        foreach (var instruction in instructions)
        {
            registers.TryAdd(instruction.IfRegister, 0);
            registers.TryAdd(instruction.Register, 0);
        }

        foreach (var instruction in instructions)
        {
            var ifResult = instruction.IfCheck switch
            {
                ">" => registers[instruction.IfRegister] > instruction.IfValue,
                "<" => registers[instruction.IfRegister] < instruction.IfValue,
                ">=" => registers[instruction.IfRegister] >= instruction.IfValue,
                "<=" => registers[instruction.IfRegister] <= instruction.IfValue,
                "==" => registers[instruction.IfRegister] == instruction.IfValue,
                "!=" => registers[instruction.IfRegister] != instruction.IfValue,
                _ => throw new NotImplementedException($"Unknown if check: {instruction.IfCheck}"),
            };

            if (!ifResult) continue;

            var delta = instruction.Manipulation switch
            {
                "inc" => +instruction.Delta,
                "dec" => -instruction.Delta,

                _ => throw new NotImplementedException($"Unknown Manipulation: {instruction.Manipulation}"),
            };

            var newValue = registers[instruction.Register] + delta;
            registers[instruction.Register] = newValue;

            if (delta > 0) max = Math.Max(newValue, max);
        }

        return registers;
    }

    private static List<Instruction> Parse(string input) => SplitOn.NewLines(input).Select(Instruction.Parse).ToList();
}
