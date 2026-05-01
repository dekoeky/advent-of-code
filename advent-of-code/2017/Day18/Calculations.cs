namespace AdventOfCode._2017.Day18;

internal static class Calculations
{
    public static long Part1(string input)
    {
        var instructions = Parser.Parse(input);
        var regs = Enumerable.Range('a', 26)
                             .ToDictionary(i => (char)i, _ => 0L);

        long lastSound = 0;
        int ip = 0;

        while (ip >= 0 && ip < instructions.Length)
        {
            switch (instructions[ip])
            {
                case Snd snd:
                    lastSound = snd.X.Eval(regs);
                    ip++;
                    break;

                case Set set:
                    regs[set.Reg] = set.X.Eval(regs);
                    ip++;
                    break;

                case Add add:
                    regs[add.Reg] += add.X.Eval(regs);
                    ip++;
                    break;

                case Mul mul:
                    regs[mul.Reg] *= mul.X.Eval(regs);
                    ip++;
                    break;

                case Mod mod:
                    regs[mod.Reg] %= mod.X.Eval(regs);
                    ip++;
                    break;

                case Rcv rcv:
                    if (regs[rcv.Reg] != 0)
                        return lastSound;
                    ip++;
                    break;

                case Jgz jgz:
                    if (jgz.X.Eval(regs) > 0)
                        ip += (int)jgz.Y.Eval(regs);
                    else
                        ip++;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        return lastSound;
    }

    public static long Part2(string input)
    {
        var instructions = Parser.Parse(input);
        var p0 = new ProgramState(0);
        var p1 = new ProgramState(1);

        while (true)
        {
            Step(instructions, p0, p1);
            Step(instructions, p1, p0);

            if ((p0.Blocked || p0.Terminated) &&
                (p1.Blocked || p1.Terminated))
                break;
        }

        return p1.SendCount;
    }

    private static void Step(Instruction[] instructions, ProgramState self, ProgramState other)
    {
        if (self.Terminated)
            return;

        if (self.Ip < 0 || self.Ip >= instructions.Length)
        {
            self.Terminated = true;
            return;
        }

        self.Blocked = false;

        switch (instructions[self.Ip])
        {
            case Snd snd:
                other.Q.Enqueue(snd.X.Eval(self.Regs));
                self.SendCount++;
                self.Ip++;
                break;

            case Set set:
                self.Regs[set.Reg] = set.X.Eval(self.Regs);
                self.Ip++;
                break;

            case Add add:
                self.Regs[add.Reg] += add.X.Eval(self.Regs);
                self.Ip++;
                break;

            case Mul mul:
                self.Regs[mul.Reg] *= mul.X.Eval(self.Regs);
                self.Ip++;
                break;

            case Mod mod:
                self.Regs[mod.Reg] %= mod.X.Eval(self.Regs);
                self.Ip++;
                break;

            case Rcv rcv:
                if (self.Q.Count == 0)
                {
                    self.Blocked = true;
                }
                else
                {
                    self.Regs[rcv.Reg] = self.Q.Dequeue();
                    self.Ip++;
                }
                break;

            case Jgz jgz:
                if (jgz.X.Eval(self.Regs) > 0)
                    self.Ip += (int)jgz.Y.Eval(self.Regs);
                else
                    self.Ip++;
                break;

            default:
                throw new NotImplementedException();
        }
    }
}


