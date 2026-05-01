namespace AdventOfCode._2023.Day06;

public class InputWithBadKerning(Race[] races) : Input(races)
{
    public static new Input Parse(string input) => Input.Parse(input.Replace(" ", null));
}