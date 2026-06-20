namespace advent_of_code._2020.Day14;

internal static class Calculations
{
    private const ulong DefaultOrMask = 0b0000000000000000000000000000000000000000000000000000000000000000uL;
    private const ulong DefaultAndMask = 0b1111111111111111111111111111111111111111111111111111111111111111uL;

    public static ulong Part1(ReadOnlySpan<char> input)
    {
        var orMask = DefaultOrMask;
        var andMask = DefaultAndMask;
        var memory = new Dictionary<ulong, ulong>();

        foreach (var line in input.EnumerateLines())
        {
            // Assume mask instruction if not memory instruction
            if (!IsMemoryInstruction(line, out var address, out var value))
            {
                ExtractMasks(line[7..], out orMask, out andMask);
                continue;
            }

            value = (value & andMask) | orMask;
            memory[address] = value;
        }

        return memory.Values.Sum();
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        Span<char> mask = stackalloc char[36];
        var memory = new Dictionary<ulong, ulong>();

        foreach (var line in input.EnumerateLines())
        {
            if (!IsMemoryInstruction(line, out var address, out var value))
            {
                // Copy mask string into span
                line[7..].CopyTo(mask);
                continue;
            }

            // Apply mask to address
            ulong baseAddress = 0;
            Span<int> floating = stackalloc int[36];
            int floatCount = 0;

            ulong bit = 1UL << 35;

            for (int i = 0; i < 36; i++)
            {
                switch (mask[i])
                {
                    case '0':
                        // unchanged
                        if ((address & bit) != 0)
                            baseAddress |= bit;
                        break;

                    case '1':
                        baseAddress |= bit;
                        break;

                    case 'X':
                        floating[floatCount++] = 35 - i; // store bit index
                        break;
                }

                bit >>= 1;
            }

            // Generate all floating combinations
            int combos = 1 << floatCount;

            for (int c = 0; c < combos; c++)
            {
                ulong addr = baseAddress;

                for (int f = 0; f < floatCount; f++)
                {
                    int bitIndex = floating[f];
                    ulong maskBit = 1UL << bitIndex;

                    if ((c & (1 << f)) != 0)
                        addr |= maskBit;
                    else
                        addr &= ~maskBit;
                }

                memory[addr] = value;
            }
        }

        long sum = 0;
        foreach (var v in memory.Values)
            sum += (long)v;

        return sum;
    }

    private static bool IsMemoryInstruction(ReadOnlySpan<char> input, out ulong address, out ulong value)
    {
        if (!input.StartsWith("mem"))
        {
            address = 0;
            value = 0;
            return false;
        }

        var b = input.IndexOf(']');
        address = ulong.Parse(input[4..b]);     // +4 to skip "mem["

        value = ulong.Parse(input[(b + 4)..]); // +4 to skip "] = " 

        return true;
    }

    private static void ExtractMasks(ReadOnlySpan<char> mask, out ulong orMask, out ulong andMask)
    {
        orMask = 0;
        andMask = ulong.MaxValue;

        ulong v = 1UL << 35;

        for (var i = 0; i < 36; i++)
        {
            switch (mask[i])
            {
                case '0':
                    andMask &= ~v;
                    break;

                case '1':
                    orMask |= v;
                    break;

                case 'X':
                    break;

                default:
                    throw new InvalidOperationException();
            }

            v >>= 1;
        }
    }

}
