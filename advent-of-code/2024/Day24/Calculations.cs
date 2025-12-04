using advent_of_code._2024.Day24.Models;
using advent_of_code.Helpers;
using System.Diagnostics;

namespace advent_of_code._2024.Day24;

public static class Calculations
{
    public static long CalculateBinaryZValues(string puzzleInput)
    {
        Parse(puzzleInput, out var wires, out var gates);

        //Debug.WriteLine("Wires: ");
        //foreach (var (key, value) in input.Wires)
        //    Debug.WriteLine($"    {key}: {(value ? '1' : '0')}");

        //Debug.WriteLine("Gates: ");
        //foreach (var (key, value) in input.Gates)
        //    Debug.WriteLine($"    {value.ValueA} {value.Op} {value.ValueB} -> {key}");

        // Calculate each gate
        while (gates.Count > 0)
            foreach (var key in gates.Keys)
            {
                var operation = gates[key];

                // Check if we have all wire inputs for the gate calculation
                if (!wires.TryGetValue(operation.ValueA, out var a)) continue;
                if (!wires.TryGetValue(operation.ValueB, out var b)) continue;

                // Calculate the result
                var result = operation.Calculate(a, b);

                // Store the result, for use by other operations
                wires.Add(key, result);

                // Remove the operation, since it does not need to be recalculated again
                gates.Remove(key);
            }

        // Find the bits of only z wires
        var zValues = new string(wires
            .Where(kv => kv.Key.StartsWith('z'))
            .OrderByDescending(kv => kv.Key)
            .Select(kv => kv.Value ? '1' : '0')
            .ToArray());

        var intValue = Convert.ToInt64(zValues, 2);
        //Debug.WriteLine($"{zValues} => {intValue}");

        return intValue;
    }


    public static void Parse(string input, out Dictionary<string, bool> wires, out Dictionary<string, Gate> gates)
    {
        // Split wires and gates input
        var parts = SplitOn.EmptyLines(input);
        Debug.Assert(parts.Length == 2);
        var wiresInput = parts[0];
        var gatesInput = parts[1];

        wires = SplitOn.NewLines(wiresInput)
            .Select(ParseInputValue)
            .ToDictionary(r => r.Key, r => r.Value);

        gates = SplitOn.NewLines(gatesInput)
            .Select(Gate.ParseSingle)
            .ToDictionary(g => g.Result, g => g);
    }

    public static KeyValuePair<string, bool> ParseInputValue(string input)
    {
        var parts = input.Split([':', ' '], StringSplitOptions.RemoveEmptyEntries);

        var name = parts[0];
        var value = parts[1];

        return new KeyValuePair<string, bool>(name, value switch
        {
            "0" => false,
            "1" => true,
            _ => throw new InvalidOperationException(),
        });
    }
}