using advent_of_code.Helpers;

namespace advent_of_code._2017.Day25;

internal record StatePart(char State, Dictionary<int, ValuePart> Parts)
{
    public static StatePart Parse(string block)
    {
        var lines = SplitOn.NewLines(block);

        // State is second to last letter in first line
        var state = lines[0][^2];
        var parts = ParseValueBlocks([.. lines.Skip(1)]);

        return new StatePart(state, parts);
    }

    private static Dictionary<int, ValuePart> ParseValueBlocks(string[] lines)
    {
        var n = lines.Length / 4;
        Dictionary<int, ValuePart> parts = [];

        for (var i = 0; i < n; i++)
        {
            var p = ValuePart.Parse([.. lines.Skip(i * 4).Take(4)]);
            parts.Add(p.CurrentValue, p);
        }

        return parts;
    }
}