namespace AdventOfCode._2017.Day05;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var jumps = Parse(input);

        int steps = 0;
        int nextInstruction = 0;

        while (nextInstruction >= 0 && nextInstruction < jumps.Count)
        {
            // Lookup Jump instruction
            var jump = jumps[nextInstruction];

            // Increase current instruction
            jumps[nextInstruction]++;

            // Perform jump instruction
            nextInstruction += jump;
            steps++;
        }

        return steps;
    }

    public static int Part2(string input)
    {
        var jumps = Parse(input);

        int steps = 0;
        int nextInstruction = 0;

        while (nextInstruction >= 0 && nextInstruction < jumps.Count)
        {
            // Lookup Jump instruction
            var jump = jumps[nextInstruction];

            // Calculate the increment
            var increment = jump >= 3
                ? -1
                : +1;

            // Increase current instruction
            jumps[nextInstruction] += increment;

            // Perform jump instruction
            nextInstruction += jump;
            steps++;
        }

        return steps;
    }

    private static List<int> Parse(string input) => [.. SplitOn.NewLines(input).Select(int.Parse)];
}