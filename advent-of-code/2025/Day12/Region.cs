namespace advent_of_code._2025.Day12;

internal record Region(Size Size, int[] Quantities)
{
    private static int[] ParseQuantities(ReadOnlySpan<char> input)
    {
        Span<Range> ranges = stackalloc Range[10];
        var n = input.Split(ranges, ' ', StringSplitOptions.TrimEntries);

        if (n >= 10) throw new InvalidOperationException("Buffer too small");
        var quantities = new int[n];

        for (var i = 0; i < n; i++)
            quantities[i] = int.Parse(input[ranges[i]]);

        return quantities;
    }

    public static Region Parse(ReadOnlySpan<char> line)
    {
        var semicolon = line.IndexOf(':');

        var size = Size.Parse(line[..semicolon]);
        var quantities = ParseQuantities(line[(semicolon + 2)..]);

        return new Region(size, quantities);
    }

    public static Region[] ParseMany(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var i = 0;
        var regions = new Region[n];

        foreach (var line in input.EnumerateLines())
            regions[i++] = Parse(line);

        return regions;
    }

    public override string ToString() => $"{Size}: {string.Join(' ', Quantities)}";
}
