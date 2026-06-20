namespace advent_of_code._2020.Day16;

internal class PuzzleInput
{
    public Dictionary<string, ValueRange[]> Ranges { get; private init; } = [];
    public int[] YourTicket { get; private init; } = [];
    public List<int[]> NearbyTickets { get; private init; } = [];

    public static PuzzleInput Parse(ReadOnlySpan<char> input)
    {
        var blocks = input.EnumerateBlocks();

        if (!blocks.MoveNext()) throw new InvalidOperationException("Contains no ranges part");
        var ranges = ParseRanges(blocks.Current);

        if (!blocks.MoveNext()) throw new InvalidOperationException("Contains no your ticket part");
        var yourTicket = ParseTicket(blocks.Current);

        if (!blocks.MoveNext()) throw new InvalidOperationException("Contains no nearby tickets part");
        var nearbyTickets = ParseNearbyTickets(blocks.Current);

        return new PuzzleInput
        {
            Ranges = ranges,
            YourTicket = yourTicket,
            NearbyTickets = nearbyTickets,
        };
    }

    private static List<int[]> ParseNearbyTickets(ReadOnlySpan<char> input)
    {
        var lines = input.EnumerateLines();

        // Skip header
        if (!lines.MoveNext()) throw new InvalidOperationException();
        if (!lines.Current.SequenceEqual("nearby tickets:")) throw new InvalidOperationException();

        var n = input.Count('\n'); // +1 for last line, -1 for ignoring the line with header
        var result = new List<int[]>(n);

        foreach (var line in lines)
            result.Add(ParseValues(line));

        return result;
    }

    private static int[] ParseTicket(ReadOnlySpan<char> input)
    {
        var lines = input.EnumerateLines();

        // Skip header
        if (!lines.MoveNext()) throw new InvalidOperationException();
        if (!lines.Current.SequenceEqual("your ticket:")) throw new InvalidOperationException();

        if (!lines.MoveNext()) throw new InvalidOperationException();
        return ParseValues(lines.Current);
    }

    private static int[] ParseValues(ReadOnlySpan<char> input)
    {
        Span<Range> r = stackalloc Range[30];
        var n = input.Split(r, ',');
        var values = new int[n];

        for (var i = 0; i < n; i++)
            values[i] = int.Parse(input[r[i]]);

        return values;
    }

    private static Dictionary<string, ValueRange[]> ParseRanges(ReadOnlySpan<char> input)
    {
        var n = input.Count(':');
        var result = new Dictionary<string, ValueRange[]>(n);

        foreach (var line in input.EnumerateLines())
        {
            ParseSingleConstraint(line, out string name, out ValueRange[] ranges);
            result.Add(name, ranges);
        }

        return result;
    }

    private static void ParseSingleConstraint(ReadOnlySpan<char> input, out string name, out ValueRange[] ranges)
    {
        Span<Range> r = stackalloc Range[10];

        var idx = input.IndexOf(':');
        name = input[..idx].ToString();
        input = input[(idx + 1)..];

        var n = input.Split(r, " or ");
        ranges = new ValueRange[n];
        for (var i = 0; i < n; i++)
            ranges[i] = ValueRange.Parse(input[r[i]]);
    }
}
