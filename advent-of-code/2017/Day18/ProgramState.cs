namespace advent_of_code._2017.Day18;

internal sealed class ProgramState
{
    public Dictionary<char, long> Regs { get; }
    public Queue<long> Q { get; } = new();
    public int Ip;
    public long SendCount;
    public bool Blocked;
    public bool Terminated;

    public ProgramState(long id)
    {
        Regs = Enumerable.Range('a', 26).ToDictionary(i => (char)i, _ => 0L);
        Regs['p'] = id;
    }
}