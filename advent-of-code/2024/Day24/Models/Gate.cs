namespace AdventOfCode._2024.Day24.Models;

public class Gate
{
    public required string ValueA { get; set; }
    public required string ValueB { get; set; }
    public BitOperation Op { get; set; }
    public required string Result { get; set; }

    public bool Calculate(bool a, bool b) => Op switch
    {
        BitOperation.AND => a & b,
        BitOperation.OR => a | b,
        BitOperation.XOR => a ^ b,
        _ => throw new NotImplementedException(),
    };

    private static readonly string[] Splitters = [" ", "->"];

    public static Gate ParseSingle(string operation)
    {
        var parts = operation.Split(Splitters, StringSplitOptions.RemoveEmptyEntries);

        return new Gate
        {
            ValueA = parts[0],
            Op = Enum.Parse<BitOperation>(parts[1]),
            ValueB = parts[2],
            Result = parts[3],
        };
    }
}