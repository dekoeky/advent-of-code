using advent_of_code.Helpers;

namespace advent_of_code._2025.Day06;

public static class Calculations
{
    public static long SumOfOperations(string input)
    {
        var lines = SplitOn.NewLines(input);

        var operations = ParseLine(lines.Last(), ToOperator);
        var values = ParseLine(lines.First(), long.Parse);

        for (var i = 1; i < lines.Length - 1; i++)
        {
            var vv = ParseLine(lines[i], long.Parse);
            for (var j = 0; j < vv.Length; j++)
            {
                var operation = operations[j];
                values[j] = operation(values[j], vv[j]);
            }
        }

        return values.Sum();
    }


    public static long SumOfOperations2(string input)
    {
        var lines = SplitOn.NewLines(input);

        var h = lines.First().Length;
        var w = lines.Length - 1;

        var operations = ParseLine(lines.Last(), ToOperator);

        var characters = new char[h, w];

        for (var r = 0; r < h; r++)
            for (var c = 0; c < w; c++)
                characters[r, c] = lines[c][r];

        var flipped = CharArray.ToString(characters)
            .Replace(" ", "");

        var groups = SplitOn.EmptyLines(flipped);
        var valuesPerGroup = groups.Select(v => SplitOn.NewLines(v).Select(long.Parse).ToArray()).ToArray();

        var groupResults = new long[groups.Length];

        for (var groupId = 0; groupId < groups.Length; groupId++)
        {
            var operation = operations[groupId];
            var groupValues = valuesPerGroup[groupId];

            groupResults[groupId] = groupValues[0];

            for (var i = 1; i < groupValues.Length; i++)
                groupResults[groupId] = operation(groupResults[groupId], groupValues[i]);
        }

        return groupResults.Sum();
    }

    private static T[] ParseLine<T>(string line, Func<string, T> x) =>
        line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(x)
            .ToArray();

    private static Func<long, long, long> ToOperator(string input) => input switch
    {
        "+" => (a, b) => a + b,
        "*" => (a, b) => a * b,
        _ => throw new InvalidOperationException()
    };
}
