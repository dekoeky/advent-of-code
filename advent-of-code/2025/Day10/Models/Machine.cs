namespace advent_of_code._2025.Day10.Models;

public class Machine
{
    public required string String { get; set; }
    public IndicatorLightDiagram Diagram { get; set; }
    public int[] Joltages { get; set; }

    public ButtonWiring[] Buttons { get; set; }

    public static Machine Parse(string s)
    {
        var parts = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return new Machine
        {
            String = s,

            // Assume first is always IndicatorLightDiagram
            Diagram = IndicatorLightDiagram.Parse(parts[0]),

            // Assume last is always JoltageRequirements
            Joltages = JoltageRequirements.Parse(parts[^1]),

            Buttons = parts
                .Skip(1)
                .SkipLast(1)
                .Select(ButtonWiring.Parse)
                .ToArray(),
        };
    }
}