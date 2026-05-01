using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day11;

internal static partial class Parsing
{
    [GeneratedRegex("(?<element>[a-zA-Z]+)(?:-compatible)?\\s+(?<type>generator|microchip)")]
    private static partial Regex Regex { get; }

    public static State ParseState(this string input)
    {
        var floor = 0;
        var elements = new List<string>();
        var elevator = 0; // elevator starts on lowest floor

        // To keep track of the floor of each generator/microchip
        List<int> generators = [];
        List<int> chips = [];

        foreach (var line in input.EnumerateLines())
        {
            foreach (Match match in Regex.Matches(line.ToString()))
            {
                var element = match.Groups["element"].Value;
                var type = match.Groups["type"].Value;

                if (!elements.Contains(element))
                {
                    elements.Add(element);
                    chips.Add(-1);
                    generators.Add(-1);
                }

                var id = elements.IndexOf(element);

                switch (type)
                {
                    case "generator": generators[id] = floor; break;
                    case "microchip": chips[id] = floor; break;
                    default: throw new NotImplementedException();
                }
            }

            floor++;
        }

        return new State(elevator, [.. generators], [.. chips]);
    }
}
