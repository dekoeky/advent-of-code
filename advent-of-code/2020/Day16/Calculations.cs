namespace advent_of_code._2020.Day16;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var puzzleInput = PuzzleInput.Parse(input);

        var sum = 0;

        //Start by determining which tickets are completely invalid; these are tickets that contain values which aren't valid for any field.
        //Ignore your ticket for now.
        foreach (var ticket in puzzleInput.NearbyTickets)
            if (!IsValidTicket(puzzleInput, ticket, out var sumOfInvalidValues))
                sum += sumOfInvalidValues;

        return sum;
    }

    private static bool IsValidTicket(PuzzleInput puzzleInput, int[] ticket, out int invalidValuesSum)
    {
        invalidValuesSum = 0;
        bool valid = true;
        foreach (var value in ticket)
            if (!puzzleInput.Ranges.Values.ContainsId(value))
            {
                invalidValuesSum += value;
                valid = false;
            }

        return valid;
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        var puzzleInput = PuzzleInput.Parse(input);

        // Remove invalid tickets
        for (var i = puzzleInput.NearbyTickets.Count - 1; i >= 0; i--)
            if (!IsValidTicket(puzzleInput, puzzleInput.NearbyTickets[i], out _))
                puzzleInput.NearbyTickets.RemoveAt(i);

        // Find mapping
        var mapping = FindMapping(puzzleInput);

        return DepartureProduct(mapping, puzzleInput.YourTicket);
    }

    private static long DepartureProduct(Dictionary<string, int> mapping, int[] yourTicket)
    {
        var product = 1L;

        foreach (var (key, value) in mapping)
            if (key.StartsWith("departure"))
                product *= yourTicket[value];

        return product;
    }

    private static Dictionary<string, int> FindMapping(PuzzleInput puzzleInput)
    {
        var n = puzzleInput.Ranges.Count;

        // Build initial possibilities
        var possibilities = new Dictionary<string, HashSet<int>>(n);

        foreach (var (name, ranges) in puzzleInput.Ranges)
        {
            var set = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                if (puzzleInput.NearbyTickets.All(t => ranges.ContainsId(t[i])))
                    set.Add(i);
            }

            possibilities[name] = set;
        }

        // Resolve using constraint propagation
        var resolved = new Dictionary<string, int>(n);

        while (resolved.Count < n)
        {
            var determined = possibilities
                .Where(kvp => kvp.Value.Count == 1)
                .ToList();

            foreach (var (name, set) in determined)
            {
                var index = set.First();
                resolved[name] = index;

                // Remove this index from all other fields
                foreach (var other in possibilities.Values)
                    other.Remove(index);

                possibilities.Remove(name);
            }
        }

        return resolved;
    }
}
