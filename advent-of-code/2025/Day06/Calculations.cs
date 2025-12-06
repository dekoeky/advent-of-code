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