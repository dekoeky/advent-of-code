namespace advent_of_code._2024.Day08;

public static class Calculations
{
    public static RowCol[] UniqueAndValidAntiNodePositions(char[,] map, bool resonantHarmonics)
    {
        var frequencies = GetFrequencyLocations(map);

        var rows = map.GetLength(0);
        var columns = map.GetLength(1);

        var allAntiNodePositions = frequencies.SelectMany(kv => GetAntiNodePositions(kv.Value, rows, columns, resonantHarmonics));

        return allAntiNodePositions
            .Distinct()
            .ToArray();
    }

    public static IEnumerable<RowCol> GetAntiNodePositions(ICollection<RowCol> positions, int rows, int columns, bool resonantHarmonics)
    {
        var workList = positions.ToList();

        while (workList.Count >= 2)
        {
            //Grab first item from list
            var first = workList.First();
            workList.RemoveAt(0);

            //Combine it with all other positions
            var results = resonantHarmonics
                    ? workList.SelectMany(second => GetAntiNodePositionsWithResonantHarmonics(first, second, rows, columns))
                    : workList.SelectMany(second => GetAntiNodePositions(first, second, rows, columns));

            foreach (var antiNodePosition in results)
                yield return antiNodePosition;
        }
    }

    public static IEnumerable<RowCol> GetAntiNodePositions(RowCol a, RowCol b, int rows, int columns)
    {
        var diff = b - a;

        var aAntiNode = a - diff;
        var bAntiNode = b + diff;

        if (IsInRange(aAntiNode)) yield return aAntiNode;
        if (IsInRange(bAntiNode)) yield return bAntiNode;

        yield break;

        bool IsInRange(RowCol rc) => rc is { Col: >= 0, Row: >= 0 } && rc.Row < rows && rc.Col < columns;
    }

    public static IEnumerable<RowCol> GetAntiNodePositionsWithResonantHarmonics(RowCol a, RowCol b, int rows, int columns)
    {
        var diff = b - a;

        var antiNode = b;

        //yield return b;
        //while (true)
        //{
        //    antiNode += diff;

        //    if (IsInRange(antiNode))
        //        yield return antiNode;
        //    else
        //        break;
        //}







        while (IsInRange(antiNode))
        {
            yield return antiNode;

            antiNode += diff;
        }







        antiNode = a;

        //yield return a;
        //while (true)
        //{
        //    antiNode -= diff;

        //    if (IsInRange(antiNode))
        //        yield return antiNode;
        //    else break;
        //}

        while (IsInRange(antiNode))
        {
            yield return antiNode;

            antiNode -= diff;
        }

        yield break;

        bool IsInRange(RowCol rc) => rc is { Col: >= 0, Row: >= 0 } && rc.Row < rows && rc.Col < columns;
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