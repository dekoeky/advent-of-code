namespace advent_of_code._2023.Day08;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var puzzleInput = PuzzleInput.Parse(input);
        var node = "AAA";
        var steps = 0;

        while (true)
            foreach (var dir in puzzleInput.Instructions)
            {
                if (node == "ZZZ") return steps;

                var (l, r) = puzzleInput.Network[node];

                node = dir switch
                {
                    'L' => l,
                    'R' => r,
                    _ => throw new InvalidOperationException()
                };

                steps++;
            }
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        var puzzleInput = PuzzleInput.Parse(input);
        var nodes = puzzleInput.Network.Keys.Where(n => n.EndsWith('A'))
            .ToArray();

        var cycleInfos = nodes.Select(n => DetectCycleLength(puzzleInput, n)).ToArray();

        return LeastCommonMultiple(cycleInfos);
    }

    private static long GreatestCommonDivisor(long a, long b)
    {
        while (b != 0)
        {
            var t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    private static long LeastCommonMultiple(long a, long b)
    {
        return a / GreatestCommonDivisor(a, b) * b;
    }

    private static long LeastCommonMultiple(params long[] values)
    {
        var result = values[0];

        for (int i = 1; i < values.Length; i++)
            result = LeastCommonMultiple(result, values[i]);

        return result;
    }

    private static long DetectCycleLength(PuzzleInput puzzleInput, string startNode)
    {
        var instructions = puzzleInput.Instructions;

        // Track visited states: (node, instructionIndex)
        var visited = new Dictionary<(string, int), long>(capacity: 4096);

        var node = startNode;
        var idx = 0;
        var steps = 0L;

        while (true)
        {
            // If we've seen this state before, cycle detected
            if (visited.TryGetValue((node, idx), out long prevStep))
                return steps - prevStep;

            visited[(node, idx)] = steps;

            var (l, r) = puzzleInput.Network[node];
            node = instructions[idx] == 'L' ? l : r;

            if (++idx == instructions.Length)
                idx = 0;

            steps++;
        }
    }
}
