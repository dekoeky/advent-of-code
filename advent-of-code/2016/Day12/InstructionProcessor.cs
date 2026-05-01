namespace AdventOfCode._2016.Day12;

internal class InstructionProcessor
{
    public Dictionary<char, int> Registers { get; set; } = new() {
            { 'a', 0 },
            { 'b', 0 },
            { 'c', 0 },
            { 'd', 0 },
    };

    public Instruction[] Instructions { get; init; } = [];
    public int NextInstruction { get; private set; } = 0;

    /// <summary>
    /// Day 25 <see cref="Day25.OutInstruction"/> values.
    /// </summary>
    public List<int> OutValues { get; } = [];

    public void Reset(Dictionary<char, int> registers)
    {
        NextInstruction = 0;
        Registers.Clear();
        foreach (var (r, v) in registers) Registers.Add(r, v);
        OutValues.Clear();
    }


    private bool NextInstructionValid() => NextInstruction >= 0 && NextInstruction < Instructions.Length;
    public void ExecuteTillFinished() => ExecuteWhile(() => true);
    public void ExecuteUntilNOutputSignals(int n) => ExecuteWhile(() => OutValues.Count < n);

    private void ExecuteWhile(Func<bool> condition)
    {
        while (NextInstructionValid() && condition())
            Execute(Instructions[NextInstruction]);
    }

    private void Execute(Instruction instruction)
    {
        switch (instruction)
        {
            case CopyValueInstruction cv:
                Registers[cv.TargetRegister] = cv.Value;
                break;

            case CopyRegisterInstruction cr:
                Registers[cr.TargetRegister] = Registers[cr.SourceRegister];
                break;

            case IncreaseInstruction inc:
                Registers[inc.Register]++;
                break;

            case DecreaseInstruction dec:
                Registers[dec.Register]--;
                break;

            case JumpIfValueNotZeroInstruction jv:
                if (jv.Value == 0)
                    break;

                NextInstruction += jv.Offset;
                return;

            case JumpIfRegisterNotZeroInstruction jr:
                if (Registers[jr.Register] == 0)
                    break;

                NextInstruction += jr.Offset;
                return;

            // Day 25 Extended instruction set:
            case Day25.OutInstruction @out:
                OutValues.Add(Registers[@out.Register]);
                break;

            default: throw new NotImplementedException();
        }

        NextInstruction++;
    }
}