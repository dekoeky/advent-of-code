namespace advent_of_code._2019.Day02;

internal static class Calculations
{
    public static int Part1(int[] values)
    {
        var i = 0;
        int a, b, c, indexA, indexB, indexC;
        while (true)
            switch (values[i])
            {
                case 99:
                    //Debug.WriteLine(string.Join(',', values));
                    return values[0];

                case 1:
                    indexA = values[i + 1];
                    indexB = values[i + 2];
                    indexC = values[i + 3];
                    a = values[indexA];
                    b = values[indexB];
                    c = a + b;
                    values[indexC] = c;
                    i += 4;
                    break;

                case 2:
                    indexA = values[i + 1];
                    indexB = values[i + 2];
                    indexC = values[i + 3];
                    a = values[indexA];
                    b = values[indexB];
                    c = a * b;
                    values[indexC] = c;
                    i += 4;
                    break;
            }

        throw new NotImplementedException();
    }

    public static int Part1(int[] program, int noun, int verb)
    {
        program[1] = noun;
        program[2] = verb;

        return Part1(program);
    }

    public static int Part2(int[] program, int target)
    {
        int[] memory = new int[program.Length];


        for (var noun = 1; noun < 100; noun++)
            for (var verb = 1; verb < 100; verb++)
            {
                program.CopyTo(memory);

                if (Part1(memory, noun, verb) == target)
                    return 100 * noun + verb;
            }

        throw new NotImplementedException();
    }

    public static int[] Parse(string input)
    {
        return [.. input.Split(',').Select(int.Parse)];
    }
}