namespace AdventOfCode._2022.Day03;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var sum = 0;
        int i;
        var l = 0;

        foreach (var line in input.EnumerateLines())
        {
            var len = line.Length / 2;
            var firstCompartment = line[..len];
            var secondCompartment = line[len..];

            for (i = 0; i < len; i++)
            {
                var c = firstCompartment[i];

                if (!secondCompartment.Contains(c))
                    continue;

                var priority = Priority(c);

                sum += priority;
                Debug.WriteLine($"[{l,2}] '{c}' -> +{priority,2} = {sum,4}");
                break;
            }

            if (i == len) throw new InvalidOperationException("did not find solution");
            l++;
        }

        return sum;
    }

    public static int Part2(string input)
    {
        var sum = 0;
        var l = 0;

        ReadOnlySpan<char> a = [];
        ReadOnlySpan<char> b = [];

        foreach (var line in input.EnumerateLines())
        {
            switch (l % 3)
            {
                case 0:
                    a = line;
                    break;
                case 1:
                    b = line;
                    break;
                case 2:
                    foreach (var c in line)
                        if (a.Contains(c) && b.Contains(c))
                        {
                            sum += Priority(c);
                            break;
                        }
                    break;

                default: throw new InvalidOperationException();
            }

            l++;
        }

        return sum;
    }

    private static int Priority(char c) => c switch
    {
        >= 'a' and <= 'z' => 01 + c - 'a',
        >= 'A' and <= 'Z' => 27 + c - 'A',
        _ => throw new NotImplementedException(),
    };
}