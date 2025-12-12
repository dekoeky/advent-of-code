namespace advent_of_code._2025.Day10.Models;

public class IndicatorLightDiagram
{
    public int Value { get; set; }
    public required string String { get; set; }

    public static IndicatorLightDiagram Parse(string s)
    {
        if (!s.StartsWith('[') || !s.EndsWith(']')) throw new InvalidOperationException();

        var pow = 1;
        var value = 0;

        // Left-Most character (or character 0) is the least significant bit
        for (var i = 1; i < s.Length - 1; i++)
        {
            var character = s[i];
            if (character == '#')
                value += pow;

            pow <<= 1;
        }

        return new IndicatorLightDiagram
        {
            Value = value,
            String = s,
        };
    }
}