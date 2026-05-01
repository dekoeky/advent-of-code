using AdventOfCode._2016.Day21.Operations;

namespace AdventOfCode._2016.Day21;

internal static partial class Parsing
{
    public static IEnumerable<Operation> ParseOperations(this string input)
    {
        foreach (var line in SplitOn.NewLines(input))
            yield return Operation.Parse(line);
    }
}
