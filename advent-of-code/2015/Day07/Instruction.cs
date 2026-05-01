namespace AdventOfCode._2015.Day07;

public class Instruction
{
    public static KeyValuePair<string, SimpleOperation> Parse(string input)
    {
        var parts = input.Split(" -> ");
        var id = parts[1];
        var operation = SimpleOperation.Parse(parts[0]);

        return new KeyValuePair<string, SimpleOperation>(id, operation);
    }
}
