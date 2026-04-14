namespace advent_of_code._2017.Day18;

internal abstract record Instruction;

internal sealed record Snd(Parameter X) : Instruction;

internal sealed record Set(char Reg, Parameter X) : Instruction;
internal sealed record Add(char Reg, Parameter X) : Instruction;

internal sealed record Mul(char Reg, Parameter X) : Instruction;

internal sealed record Mod(char Reg, Parameter X) : Instruction;

internal sealed record Rcv(char Reg) : Instruction;
internal sealed record Jgz(Parameter X, Parameter Y) : Instruction;

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
    {
        if (span.Length == 1 && span[0] is >= 'a' and <= 'z')
            return new Parameter(span[0]);

        return new Parameter(long.Parse(span));
    }

    public long Eval(Dictionary<char, long> regs)
        => IsRegister ? regs[Reg] : Value;
}