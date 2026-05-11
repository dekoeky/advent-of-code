namespace advent_of_code._2018.Day16;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var puzzleInput = PuzzleInput.Parse(input);

        var count = 0;

        foreach (var sample in puzzleInput.Samples)
            if (HowManyOptions(sample) >= 3)
                count++;

        return count;
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        var puzzleInput = PuzzleInput.Parse(input);
        var opCodes = ExtractOpCodes(puzzleInput);
        int[] registers = [0, 0, 0, 0];

        foreach (var instr in puzzleInput.Instructions)
            Instruction.Execute(registers, opCodes[instr.OpCode], instr.A, instr.B, instr.C);

        return registers[0];
    }

    private static Dictionary<int, OperationNames> ExtractOpCodes(PuzzleInput puzzleInput)
    {
        var possibleLinks = Enumerable.Range(0, 16).ToDictionary(
                     op => op,
                     _ => Enum.GetValues<OperationNames>().ToList());

        foreach (var sample in puzzleInput.Samples)
            EliminateOptions(sample, possibleLinks);

        foreach (var (k, v) in possibleLinks)
        {
            Debug.WriteLine($"{k}:");
            foreach (var p in v)
                Debug.WriteLine($"    {p}");
        }

        return possibleLinks.ToDictionary(kv => kv.Key, kv => kv.Value.Single());
    }

    private static int HowManyOptions(PuzzleSample sample)
    {
        var count = 0;
        Span<int> registers = stackalloc int[4];

        foreach (var op in Enum.GetValues<OperationNames>())
        {
            // Set up the registers
            sample.Before.CopyTo(registers);

            // Execute the operation
            Instruction.Execute(registers, op, sample.Instruction.A, sample.Instruction.B, sample.Instruction.C);

            // Check if result is correct
            if (registers.SequenceEqual(sample.After))
                count++;
        }

        return count;
    }

    private static void EliminateOptions(PuzzleSample sample, Dictionary<int, List<OperationNames>> possibilities)
    {
        Span<int> registers = stackalloc int[4];

        var opCode = sample.Instruction.OpCode;
        var stillPossible = possibilities[opCode];

        foreach (var op in stillPossible.ToList())
        {
            // Set up the registers
            sample.Before.CopyTo(registers);

            // Execute the operation
            Instruction.Execute(registers, op, sample.Instruction.A, sample.Instruction.B, sample.Instruction.C);

            // If the result is not correct, remove it from the possibilities
            if (!registers.SequenceEqual(sample.After))
                stillPossible.Remove(op);
        }

        if (stillPossible.Count == 0) throw new InvalidOperationException($"Couldnt find solution for opcode {opCode}");
        if (stillPossible.Count == 1)
            RemoveFromOthers(possibilities, possibilities[opCode].Single());

    }

    private static void RemoveFromOthers(Dictionary<int, List<OperationNames>> possibilities, OperationNames toBeRemoved)
    {
        HashSet<OperationNames> afterCare = [];

        foreach (var (k, v) in possibilities)
        {
            if (!v.Contains(toBeRemoved)) continue;

            if (v.Count == 0) throw new InvalidOperationException();
            if (v.Count == 1) continue; // Let's assume this was a match
            v.Remove(toBeRemoved);

            if (v.Count == 1)
                afterCare.Add(v.Single());
        }

        foreach (var after in afterCare)
            RemoveFromOthers(possibilities, after);
    }


}
