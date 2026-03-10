using advent_of_code.Helpers;
using System.Diagnostics;

namespace advent_of_code._2015.Day07;

public class Circuit
{
    public static Circuit Parse(string input)
    {
        var lines = SplitOn.NewLines(input);
        var instructions = lines.Select(Instruction.Parse).ToDictionary();

        return new Circuit
        {
            Instructions = instructions
        };
    }
    public Dictionary<string, SimpleOperation> Instructions { get; set; }
    public Dictionary<string, ushort> Values { get; set; } = [];
    public ushort GetOrCalculate(string id)
    {
        if (Values.TryGetValue(id, out var value)) return value;
        if (ushort.TryParse(id, out value)) return value;

        Debug.WriteLine($"Calculating {id}");

        var operation = Instructions[id];

        var result = Execute(operation);

        // Store
        Values[id] = result;

        // Return
        return result;
    }

    private ushort Execute(SimpleOperation o)
    {
        switch (o.Op)
        {
            case Op.ASSIGN: return ushort.TryParse(o.Left, out var value) ? value : GetOrCalculate(o.Left);
            case Op.NOT: return (ushort)~GetOrCalculate(o.Right!);
            case Op.AND: return (ushort)(GetOrCalculate(o.Left) & GetOrCalculate(o.Right));
            case Op.OR: return (ushort)(GetOrCalculate(o.Left) | GetOrCalculate(o.Right));
            case Op.LSHIFT: return (ushort)(GetOrCalculate(o.Left) << int.Parse(o.Right));
            case Op.RSHIFT: return (ushort)(GetOrCalculate(o.Left) >> int.Parse(o.Right));
            default: throw new NotImplementedException();
        }
    }
}

public record SimpleOperation(Op Op, string Left, string Right)
{
    public static SimpleOperation Parse(string input)
    {
        foreach (var option in Enum.GetValues<Op>().Except([Op.ASSIGN]))
        {
            var splitter = option.ToString().ToUpper();
            if (input.Contains(splitter))
            {
                var parts = input.Split(splitter, StringSplitOptions.TrimEntries);
                return new SimpleOperation(option, parts[0], parts[1]);
            }
        }

        return new SimpleOperation(Op.ASSIGN, input, null!);
    }
}
public enum Op
{
    ASSIGN,
    LSHIFT,
    RSHIFT,
    AND,
    OR,
    NOT,
}