using advent_of_code._2016.Day21.Operations;

namespace advent_of_code._2016.Day21;

internal static partial class Parsing
{
    public static IEnumerable<Operation> ParseOperations(this string input)
    {
        foreach (var line in SplitOn.NewLines(input))
            yield return Operation.Parse(line);
    }
}
