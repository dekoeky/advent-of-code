using System.Numerics;

namespace AdventOfCode.Helpers;

/// <summary>
/// Parses comma-separated numbers from strings.
/// </summary>
internal static class CommaSeparatedNumbers
{
    public static T[] Parse<T>(ReadOnlySpan<char> input) where T : struct, INumberBase<T>
    {
        var n = input.Count(',') + 1;
        var i = 0;

        T[] values = new T[n];

        foreach (var r in input.Split(','))
            values[i++] = T.Parse(input[r], null);

        return values;
    }
}