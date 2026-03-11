namespace advent_of_code._2015.Day15;

internal record Ingredient(string Name, Dictionary<string, int> Properties)
{
    public static Ingredient Parse(string input)
    {
        var parts = input.Split(':', StringSplitOptions.TrimEntries);

        var name = parts[0];
        parts = parts[1].Split(',', StringSplitOptions.TrimEntries);
        var properties = parts.Select(p => p.Split(' ')).ToDictionary(p => p[0], p => int.Parse(p[1]));

        return new Ingredient(name, properties);
    }
}
