namespace advent_of_code._2018.Day12;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input, int generations)
    {
        var initialState = Parse(input, out var patterns);

        // plants can expand 2 pots per generation;
        var maxPlants = initialState.Length + 2 * 2 * generations;
        var zeroIndex = 2 * generations;
        var firstIndex = 0 - zeroIndex;
        Span<bool> plants = new bool[maxPlants];
        Span<bool> newPlants = new bool[maxPlants];

        initialState.CopyTo(plants[zeroIndex..]);

        Print(plants);
        for (var g = 0; g < generations; g++)
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
            Print(plants);
        }

        return SumOfIndices(plants, firstIndex);
    }

    public static int Part2(ReadOnlySpan<char> input, long generations)
    {
        throw new NotImplementedException();
    }

    private static int SumOfIndices(ReadOnlySpan<bool> plants, int firstIndex)
    {
        var sum = 0;

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
    private static void Print(ReadOnlySpan<bool> plants)
    {
        var n = 0;

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
