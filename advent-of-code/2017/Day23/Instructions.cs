namespace advent_of_code._2017.Day23;

internal abstract record Instruction;

internal sealed record Set(char X, Parameter Y) : Instruction;
internal sealed record Sub(char X, Parameter Y) : Instruction;
internal sealed record Mul(char X, Parameter Y) : Instruction;
internal sealed record Jnz(Parameter X, Parameter Y) : Instruction;

internal readonly struct Parameter
{
    public bool IsRegister { get; }
    public char Reg { get; }
    public long Value { get; }

    private Parameter(char reg)
    {
        IsRegister = true;
        Reg = reg;
        Value = 0;
    }

    private Parameter(long value)
    {
        IsRegister = false;
        Reg = '\0';
        Value = value;
    }

    public static Parameter Parse(ReadOnlySpan<char> span)
        => span.Length == 1 && span[0] is >= 'a' and <= 'z'
        ? new Parameter(span[0])
        : new Parameter(long.Parse(span));

    public long Eval(Dictionary<char, long> regs)
        => IsRegister ? regs[Reg] : Value;
}