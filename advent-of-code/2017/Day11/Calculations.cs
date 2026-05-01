namespace AdventOfCode._2017.Day11;

internal static class Calculations
{
    private static readonly Dictionary<string, HexGridCoordinate> Moves = new()
    {
        ["n"] = new HexGridCoordinate(0, 1, -1),
        ["ne"] = new HexGridCoordinate(1, 0, -1),
        ["se"] = new HexGridCoordinate(1, -1, 0),
        ["s"] = new HexGridCoordinate(0, -1, 1),
        ["sw"] = new HexGridCoordinate(-1, 0, 1),
        ["nw"] = new HexGridCoordinate(-1, 1, 0),
    };

    public static int Execute(string input, out int maxDistance)
    {
        HexGridCoordinate position = new();
        maxDistance = 0;

        foreach (var part in input.Split(','))
        {
            position += Moves[part];
            maxDistance = Math.Max(maxDistance, position.Distance());
        }

        return position.Distance();
    }
}
