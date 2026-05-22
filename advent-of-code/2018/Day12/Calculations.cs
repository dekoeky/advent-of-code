namespace advent_of_code._2018.Day12;

internal static class Calculations
{
    public static long Part1(ReadOnlySpan<char> input, int generations)
    {
        var initialState = Parse(input, out var patterns);

        int generation;
        // plants can expand 2 pots per generation;
        var maxPlants = initialState.Length + 2 * 2 * generations;
        var zeroIndex = 2 * generations;
        var firstIndex = 0 - zeroIndex;
        Span<bool> plants = maxPlants <= 100 ? stackalloc bool[maxPlants] : new bool[maxPlants];
        Span<bool> newPlants = maxPlants <= 100 ? stackalloc bool[maxPlants] : new bool[maxPlants];

        initialState.CopyTo(plants[zeroIndex..]);

        for (generation = 0; generation < generations; generation++)
        {
            Print(generation, plants);
            plants.CopyTo(newPlants);

            for (var i = 2; i < maxPlants - 2; i++)
            {
                bool matched = false;
                var five = plants[new Range(i - 2, i + 3)];
                foreach (var pattern in patterns)
                    if (five.SequenceEqual(pattern.Pattern))
                    {
                        newPlants[i] = pattern.Result;
                        matched = true;
                        break; // Assume only one pattern can match
                    }
                if (!matched)
                    newPlants[i] = false;
            }

            newPlants.CopyTo(plants);
        }

        Print(generation, plants);
        return SumOfIndices(plants, firstIndex);
    }

    public static long Part2(ReadOnlySpan<char> input, long actualGenerations)
    {
        var initialState = Parse(input, out var patterns);
        var generations = 500;
        int generation;
        // plants can expand 2 pots per generation;
        var maxPlants = initialState.Length + 2 * 2 * generations;
        var zeroIndex = 2 * generations;
        var firstIndex = 0 - zeroIndex;
        Span<bool> plants = maxPlants <= 100 ? stackalloc bool[maxPlants] : new bool[maxPlants];
        Span<bool> newPlants = maxPlants <= 100 ? stackalloc bool[maxPlants] : new bool[maxPlants];
        bool[] lastPatternStorage = new bool[maxPlants];
        Span<bool> lastPattern = [];

        initialState.CopyTo(plants[zeroIndex..]);

        for (generation = 0; generation < generations; generation++)
        {
            plants.CopyTo(newPlants);

            for (var i = 2; i < maxPlants - 2; i++)
            {
                bool matched = false;
                var five = plants[new Range(i - 2, i + 3)];
                foreach (var pattern in patterns)
                    if (five.SequenceEqual(pattern.Pattern))
                    {
                        newPlants[i] = pattern.Result;
                        matched = true;
                        break; // Assume only one pattern can match
                    }
                if (!matched)
                    newPlants[i] = false;
            }

            newPlants.CopyTo(plants);

            var newPattern = ExtractPattern(plants);

            if (lastPattern.StartsWith(newPattern))
            {
                Debug.WriteLine($"Pattern detected at generation {generation}");
                break;
            }
        }

        return SumOfIndices(plants, firstIndex + actualGenerations - generation); // TODO: Add offset
    }

    private static ReadOnlySpan<bool> ExtractPattern(ReadOnlySpan<bool> plants)
    {
        var first = plants.IndexOf(true);
        var last = plants.LastIndexOf(true);

        return plants[new Range(first, last)];
    }

    private static long SumOfIndices(ReadOnlySpan<bool> plants, long firstIndex)
    {
        var sum = 0L;

        for (var i = 0; i < plants.Length; i++)
            if (plants[i])
            {
                var index = firstIndex + i;
                sum += index;
                //Debug.WriteLine($"Pot {index} contains a plant -> {sum}");
            }

        return sum;
    }

    [Conditional("DEBUG")]
    private static void Print(int generation, ReadOnlySpan<bool> plants)
    {
        var n = 0;

        Debug.Write($"[{generation}]: ");

        foreach (var present in plants)
            if (present)
            {
                Debug.Write('#');
                n++;
            }
            else
            {
                Debug.Write('.');
            }

        Debug.WriteLine($"  {n,2}");
    }

    private static ReadOnlySpan<bool> Parse(ReadOnlySpan<char> input, out SpreadRule[] rules)
    {
        var lines = input.EnumerateLines();

        // Parse Initial State
        lines.MoveNext();
        var initialState = ExtractInitialState(lines.Current);


        // Skip Empty Line
        lines.MoveNext();

        // Parse patterns
        var i = 0;
        var n = input.Count("=>");
        rules = new SpreadRule[n];
        foreach (var line in lines) // Loop remaining lines
            rules[i++] = SpreadRule.Parse(line);

        return initialState;
    }

    private static bool[] ExtractInitialState(ReadOnlySpan<char> firstLine)
    {
        var start = firstLine.IndexOf(':') + 2;
        firstLine = firstLine[start..];

        var initialState = new bool[firstLine.Length];
        for (var i = 0; i < firstLine.Length; i++)
            initialState[i] = firstLine[i] == '#';

        return initialState;
    }
}
