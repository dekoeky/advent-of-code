namespace advent_of_code._2024.Day24;

public class Gate
{
    public string ValueA { get; set; }
    public string ValueB { get; set; }
    public BitOperation Op { get; set; }
    public string Result { get; set; }

    public bool Calculate(bool a, bool b) => Op switch
    {
        BitOperation.AND => a & b,
        BitOperation.OR => a | b,
        BitOperation.XOR => a ^ b,
        _ => throw new ArgumentOutOfRangeException()
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