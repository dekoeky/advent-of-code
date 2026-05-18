namespace advent_of_code._2019.Day05;

internal static class Calculations
{
    public static int Execute(ReadOnlySpan<char> puzzleInput, int input)
    {
        var memory = IntCodeProgram.Parse(puzzleInput);

        var ip = 0;
        var lastOutput = 0;
        while (true)
        {
            var instruction = memory[ip];
            var opcode = instruction % 100;
            var mode1 = (instruction / 100) % 10;
            var mode2 = (instruction / 1000) % 10;

            int Param(int offset, int mode)
            {
                int value = memory[ip + offset];
                return mode == 0 ? memory[value] : value;
            }

            switch (opcode)
            {
                case 1: // add
                    memory[memory[ip + 3]] = Param(1, mode1) + Param(2, mode2);
                    ip += 4;
                    break;

                case 2: // multiply
                    memory[memory[ip + 3]] = Param(1, mode1) * Param(2, mode2);
                    ip += 4;
                    break;

                case 3: // input
                    memory[memory[ip + 1]] = input;
                    ip += 2;
                    break;

                case 4: // output
                    lastOutput = Param(1, mode1);
                    ip += 2;
                    break;

                case 5: // jump-if-true
                    if (Param(1, mode1) != 0)
                        ip = Param(2, mode2);
                    else
                        ip += 3;
                    break;

                case 6: // jump-if-false
                    if (Param(1, mode1) == 0)
                        ip = Param(2, mode2);
                    else
                        ip += 3;
                    break;

                case 7: // less-than
                    memory[memory[ip + 3]] =
                        Param(1, mode1) < Param(2, mode2) ? 1 : 0;
                    ip += 4;
                    break;

                case 8: // equals
                    memory[memory[ip + 3]] =
                        Param(1, mode1) == Param(2, mode2) ? 1 : 0;
                    ip += 4;
                    break;

                case 99:
                    return lastOutput;
            }
        }

        throw new NotImplementedException();
    }
}