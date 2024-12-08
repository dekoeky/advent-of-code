namespace advent_of_code._2024.Day08;

public static class Calculations
{
    public static RowCol[] UniqueAndValidAntiNodePositions(char[,] map)
    {
        var frequencies = GetFrequencyLocations(map);
        return frequencies.SelectMany(kv => GetAntiNodePositions(kv.Value))
            .Distinct()
            .Where(rc => rc.Row >= 0 && rc.Row < map.GetLength(0) && rc.Col >= 0 && rc.Col < map.GetLength(1))
            .ToArray();
    }

    public static IEnumerable<RowCol> GetAntiNodePositions(ICollection<RowCol> positions)
    {
        var workList = positions.ToList();

        while (workList.Count >= 2)
        {
            var first = workList.First();
            workList.RemoveAt(0);

            foreach (var antiNodePosition in workList.SelectMany(second => GetAntiNodePositions(first, second)))
                yield return antiNodePosition;
        }
    }

    public static IEnumerable<RowCol> GetAntiNodePositions(RowCol a, RowCol b)
    {
        var diff = b - a;

        yield return b + diff;
        yield return a - diff;
    }

    public static Dictionary<char, List<RowCol>> GetFrequencyLocations(char[,] input)
    {
        var locations = new Dictionary<char, List<RowCol>>();

        for (var r = 0; r < input.GetLength(0); r++)
        for (var c = 0; c < input.GetLength(1); c++)
        {
            var f = input[r, c];
            if (!IsFrequency(f)) continue;

            if (locations.TryGetValue(f, out var thisFrequencyLocations))
                thisFrequencyLocations.Add(new RowCol(r, c));
            else
                locations.Add(f, [new RowCol(r, c)]);
        }

        return locations;
    }

    private static bool IsFrequency(char c) => char.IsLetterOrDigit(c);
}