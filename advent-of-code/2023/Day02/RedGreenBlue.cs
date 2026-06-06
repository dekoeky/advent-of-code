namespace advent_of_code._2023.Day02;

public struct RedGreenBlue
{
    public int Red;
    public int Green;
    public int Blue;

    public readonly int GetPower() => Red * Green * Blue;

    public static readonly RedGreenBlue Zero = new()
    {
        Red = 0,
        Green = 0,
        Blue = 0,
    };

    public static RedGreenBlue Parse(ReadOnlySpan<char> input)
    {
        Span<Range> ranges = stackalloc Range[4];
        var n = input.Split(ranges, ',', StringSplitOptions.TrimEntries);

        if (n >= 4) throw new InvalidOperationException("allocated buffer too small");

        var rgb = new RedGreenBlue();

        for (var i = 0; i < n; i++)
        {
            var part = input[ranges[i]];
            var space = part.IndexOf(' ');
            var count = int.Parse(part[..space++]);

            switch (part[space])
            {
                case 'r': rgb.Red += count; break;
                case 'g': rgb.Green += count; break;
                case 'b': rgb.Blue += count; break;
            }
        }

        return rgb;
    }

    public static RedGreenBlue[] ParseMany(ReadOnlySpan<char> input)
    {
        Span<Range> ranges = stackalloc Range[10];
        var n = input.Split(ranges, ';');

        if (n >= 10) throw new InvalidOperationException("allocated buffer too small");

        var values = new RedGreenBlue[n];

        for (var i = 0; i < n; i++)
            values[i] = Parse(input[ranges[i]]);

        return values;
    }
}