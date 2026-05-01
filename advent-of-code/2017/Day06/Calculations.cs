namespace AdventOfCode._2017.Day06;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var memoryBanks = Parse(input);
        var l = memoryBanks.Length;
        var seen = new HashSet<MemoryBanksState>();
        var steps = 0;

        while (true)
        {
            // Take highest
            var max = memoryBanks.Max();
            var indexOfMax = memoryBanks.IndexOf(max);
            memoryBanks[indexOfMax] = 0;

            // smear
            int i = indexOfMax;
            while (max-- > 0)
            {
                i = (i + 1) % l;
                memoryBanks[i]++;
            }

            var state = new MemoryBanksState(memoryBanks);
            steps++;

            // Detect already seen state
            if (!seen.Add(state))
                return steps;
        }
    }

    public static int Part2(string input)
    {
        var memoryBanks = Parse(input);
        var l = memoryBanks.Length;
        var seen = new Dictionary<MemoryBanksState, int>();
        var steps = 0;

        while (true)
        {
            // Take highest
            var max = memoryBanks.Max();
            var indexOfMax = memoryBanks.IndexOf(max);
            memoryBanks[indexOfMax] = 0;

            // smear
            int i = indexOfMax;
            while (max-- > 0)
            {
                i = (i + 1) % l;
                memoryBanks[i]++;
            }

            var state = new MemoryBanksState(memoryBanks);
            steps++;

            // Detect already seen state
            if (seen.TryGetValue(state, out var since))
            {
                return steps - since;
            }
            seen.Add(state, steps);
        }
    }

    private static readonly char[] Separators = ['\t', ' '];
    private static int[] Parse(string input) => [.. input.Split(Separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)];
}
