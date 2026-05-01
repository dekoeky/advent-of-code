namespace AdventOfCode._2017.Day18;

internal static class Parser
{
    public static Instruction[] Parse(ReadOnlySpan<char> input)
    {
        int n = input.Count('\n') + 1;
        var instructions = new Instruction[n];
        int idx = 0;

        foreach (var line in input.EnumerateLines())
        {
            if (line.IsEmpty)
                continue;

            var op = line[..3];
            var rest = line.Length > 4 ? line[4..] : [];
            int space = rest.IndexOf(' ');
            var p1 = space == -1 ? rest : rest[..space];
            var p2 = space == -1 ? [] : rest[(space + 1)..];

            instructions[idx++] = op switch
            {
                "snd" => new Snd(Parameter.Parse(p1)),
                "set" => new Set(p1[0], Parameter.Parse(p2)),
                "add" => new Add(p1[0], Parameter.Parse(p2)),
                "mul" => new Mul(p1[0], Parameter.Parse(p2)),
                "mod" => new Mod(p1[0], Parameter.Parse(p2)),
                "rcv" => new Rcv(p1[0]),
                "jgz" => new Jgz(Parameter.Parse(p1), Parameter.Parse(p2)),
                _ => throw new NotImplementedException()
            };
        }

        return instructions;
    }
}


