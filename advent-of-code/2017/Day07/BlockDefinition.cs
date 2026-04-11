namespace advent_of_code._2017.Day07;

record BlockDefinition(string Name, int Weight, string[] Supports)
{
    public static BlockDefinition Parse(string input)
    {
        var parts = input.Split(" -> ");

        var supports = parts.Length < 2
            ? []
            : parts[1].Split(", ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        parts = parts[0].Split([' ', '(', ')'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var name = parts[0];
        var weight = int.Parse(parts[1]);

        return new BlockDefinition(name, weight, supports);
    }
}
