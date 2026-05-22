namespace advent_of_code._2021.Day02;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var depth = 0;
        var position = 0;

        foreach (var line in input.EnumerateLines())
            if (line.StartsWith("forward"))
                position += int.Parse(line[8..]);
            else if (line.StartsWith("down"))
                depth += int.Parse(line[5..]);
            else if (line.StartsWith("up"))
                depth -= int.Parse(line[3..]);
            else throw new Exception();

        return depth * position;
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        var depth = 0;
        var position = 0;
        var aim = 0;

        foreach (var line in input.EnumerateLines())
            if (line.StartsWith("down"))
                aim += int.Parse(line[5..]);
            else if (line.StartsWith("up"))
                aim -= int.Parse(line[3..]);
            else if (line.StartsWith("forward"))
            {
                var x = int.Parse(line[8..]);
                position += x;
                depth += aim * x;
            }
            else throw new Exception();

        return depth * position;
    }
}