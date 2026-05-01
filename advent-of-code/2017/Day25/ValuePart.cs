namespace AdventOfCode._2017.Day25;

internal record ValuePart(int CurrentValue, int WriteValue, bool Left, char ContinueState)
{
    public static ValuePart Parse(string[] lines)
    {
        var ifLine = lines[0];
        var writeLine = lines[1];
        var moveLine = lines[2];
        var continueLine = lines[3];

        if (!ifLine.Contains("If the current value is")) throw new InvalidOperationException();
        if (!writeLine.Contains("Write the value")) throw new InvalidOperationException();
        if (!moveLine.Contains("Move")) throw new InvalidOperationException();
        if (!continueLine.Contains("Continue")) throw new InvalidOperationException();

        var currentValue = int.Parse(ifLine.Split(' ').Last().Replace(":", null));
        var writeValue = int.Parse(writeLine.Split(' ').Last().Replace(".", null));
        var left = moveLine.Contains("left") ? true
            : moveLine.Contains("right") ? false
            : throw new InvalidOperationException();
        var contineState = continueLine.Split(' ').Last().Replace(".", null)[0];


        return new ValuePart(currentValue, writeValue, left, contineState);
    }
}
