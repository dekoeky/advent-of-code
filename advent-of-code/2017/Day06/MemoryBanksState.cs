namespace AdventOfCode._2017.Day06;

public readonly struct MemoryBanksState : IEquatable<MemoryBanksState>
{
    public readonly int[] MemoryBanks;

    public MemoryBanksState(int[] memoryBanks)
    {
        MemoryBanks = new int[memoryBanks.Length];
        Array.Copy(memoryBanks, MemoryBanks, memoryBanks.Length);
    }

    public bool Equals(MemoryBanksState other)
    {
        for (int i = 0; i < MemoryBanks.Length; i++)
            if (MemoryBanks[i] != other.MemoryBanks[i]) return false;
        return true;
    }

    public override int GetHashCode()
    {
        HashCode h = new();
        for (int i = 0; i < MemoryBanks.Length; i++)
            h.Add(MemoryBanks[i]);
        return h.ToHashCode();
    }
}
