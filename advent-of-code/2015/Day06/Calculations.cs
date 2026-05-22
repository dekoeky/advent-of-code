namespace advent_of_code._2015.Day06;

internal static class Calculations
{
    public static int Perform(string input)
    {
        var lines = SplitOn.NewLines(input);
        var instructions = lines.Select(Instruction.Parse).ToArray();

        var lights = new bool[1000, 1000];

        foreach (var instruction in instructions)
        {
            if (instruction.X1 > instruction.X2) throw new InvalidOperationException("X1 > X2");
            if (instruction.Y1 > instruction.Y2) throw new InvalidOperationException("Y1 > Y2");

            for (var y = instruction.Y1; y <= instruction.Y2; y++)
                for (var x = instruction.X1; x <= instruction.X2; x++)
                    switch (instruction.Command)
                    {
                        case Command.TurnOn: lights[y, x] = true; break;
                        case Command.TurnOff: lights[y, x] = false; break;
                        case Command.Toggle: lights[y, x] = !lights[y, x]; break;
                        default: throw new NotImplementedException();
                    }
        }

        return lights.Count();
    }

    public static int Perform2(string input)
    {
        var lines = SplitOn.NewLines(input);
        var instructions = lines.Select(Instruction.Parse).ToArray();

        var brightnesses = new int[1000, 1000];

        foreach (var instruction in instructions)
        {
            if (instruction.X1 > instruction.X2) throw new InvalidOperationException("X1 > X2");
            if (instruction.Y1 > instruction.Y2) throw new InvalidOperationException("Y1 > Y2");

            checked
            {
                for (var y = instruction.Y1; y <= instruction.Y2; y++)
                    for (var x = instruction.X1; x <= instruction.X2; x++)
                        switch (instruction.Command)
                        {
                            case Command.TurnOn: brightnesses[y, x]++; break;
                            case Command.TurnOff: if (brightnesses[y, x] > 0) brightnesses[y, x]--; break;
                            case Command.Toggle: brightnesses[y, x] = brightnesses[y, x] += 2; break;
                            default: throw new NotImplementedException();
                        }
            }
        }

        return brightnesses.Sum(b => b);
    }
}
