namespace advent_of_code._2017.Day23;

internal static class Calculations
{
    public static long Part1(string input) => Run(input, true);

    private static long Run(string input, bool debug)
    {
        var instructions = Parser.Parse(input);
        var regs = "abcdefgh".ToDictionary(i => i, _ => 0L);
        var mulCount = 0;
        var ip = 0;

        regs['a'] = debug == true ? 0 : 1;

        while (ip >= 0 && ip < instructions.Length)
            switch (instructions[ip])
            {
                case Set set:
                    regs[set.X] = set.Y.Eval(regs);
                    ip++;
                    break;

                case Sub sub:
                    regs[sub.X] -= sub.Y.Eval(regs);
                    ip++;
                    break;

                case Mul mul:
                    regs[mul.X] *= mul.Y.Eval(regs);
                    ip++;
                    mulCount++;
                    break;

                case Jnz jnz:
                    if (jnz.X.Eval(regs) != 0)
                        ip += (int)jnz.Y.Eval(regs);
                    else
                        ip++;
                    break;

                default:
                    throw new NotImplementedException();
            }

        return mulCount;
    }

    public static long Part2(string input)
    {
        const int start = 109900;
        const int end = 126900;
        const int step = 17;

        var count = 0;

        for (int n = start; n <= end; n += step)
        {
            if (!IsPrime(n))
            {
                count++;
            }
        }

        return count;
    }

    private static bool IsPrime(int n)
    {
        if (n < 2)
            return false;
        if ((n & 1) == 0)
            return n == 2;

        // Only test odd divisors up to sqrt(n)
        for (int d = 3; d * d <= n; d += 2)
        {
            if (n % d == 0)
                return false;
        }

        return true;
    }
}


