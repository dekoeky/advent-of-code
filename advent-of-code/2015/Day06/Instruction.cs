using System.Text.RegularExpressions;

namespace AdventOfCode._2015.Day06;

internal partial class Instruction
{
    public required Command Command { get; init; }
    public required int X1 { get; init; }
    public required int Y1 { get; init; }
    public required int X2 { get; init; }
    public required int Y2 { get; init; }


    // Group 1 = command
    // Group 2 = x1
    // Group 3 = y1
    // Group 4 = x2
    // Group 5 = y2
    [GeneratedRegex(@"^(turn on|turn off|toggle)\s+(\d+),(\d+)\s+through\s+(\d+),(\d+)$")]
    public static partial Regex Pattern();

    private static readonly Regex regex = Pattern();

    public static Instruction Parse(string line)
    {
        var match = regex.Match(line);

        if (!match.Success)
            throw new InvalidOperationException($"Invalid instruction: {line}");

        var command = match.Groups[1].Value switch
        {
            "turn on" => Command.TurnOn,
            "turn off" => Command.TurnOff,
            "toggle" => Command.Toggle,
            _ => throw new NotImplementedException(),
        };
        var x1 = int.Parse(match.Groups[2].Value);
        var y1 = int.Parse(match.Groups[3].Value);
        var x2 = int.Parse(match.Groups[4].Value);
        var y2 = int.Parse(match.Groups[5].Value);

        return new Instruction
        {
            Command = command,
            X1 = x1,
            Y1 = y1,
            X2 = x2,
            Y2 = y2
        };
    }

    public override string ToString()
    {
        var cmd = Command switch
        {
            Command.Toggle => "toggle",
            Command.TurnOff => "turn off",
            Command.TurnOn => "turn on",
            _ => throw new NotImplementedException(),
        };

        return $"{cmd} {X1},{Y1} through {X2},{Y2}";
    }
}
