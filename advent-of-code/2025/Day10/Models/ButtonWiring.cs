namespace advent_of_code._2025.Day10.Models;

public record ButtonWiring
{
    public int Value { get; set; }
    public required string String { get; set; }

    public static ButtonWiring Parse(string s)
    {
        if (!s.StartsWith('(') || !s.EndsWith(')')) throw new InvalidOperationException();

        var parts = s.Substring(1, s.Length - 2).Split(',');


        return new ButtonWiring
        {
            Value = parts.Aggregate(0, (current, part) => current + (int)Math.Pow(2, int.Parse(part))),
            String = s,
        };
    }
}