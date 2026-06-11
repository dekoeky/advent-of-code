namespace advent_of_code._2022.Day13;

internal static partial class Calculations
{
    private const string Div1 = "[[2]]";
    private const string Div2 = "[[6]]";
    static readonly CustomComparer Comparer = new();

    public static int Part1(ReadOnlySpan<char> input)
    {
        var sum = 0;
        var index = 0;

        foreach (var pair in input.EnumerateBlocks())
        {
            // One based indexing
            ++index;

            if (IsInCorrectOrder(pair))
                sum += index;
        }

        return sum;
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        var strings = ParseStrings(input);
        strings.Add(Div1);
        strings.Add(Div2);

        strings.Sort(Comparer);

        return (strings.IndexOf(Div1) + 1) * (strings.IndexOf(Div2) + 1);
    }

    private static List<string> ParseStrings(ReadOnlySpan<char> input)
    {
        var strings = new List<string>();

        foreach (var line in input.EnumerateLines())
            if (!line.IsEmpty)
                strings.Add(line.ToString());

        return strings;
    }

    private static bool IsInCorrectOrder(ReadOnlySpan<char> block)
    {
        var lines = block.EnumerateLines();

        if (!lines.MoveNext()) throw new InvalidOperationException("Item 1 not found");
        var a = lines.Current;

        if (!lines.MoveNext()) throw new InvalidOperationException("Item 2 not found");
        var b = lines.Current;

        return Comparer.Compare(a, b) == -1;
    }
}
