namespace advent_of_code._2023._06;

public class InputWithBadKerning(Race[] races) : Input(races)
{
    public static new Input Parse(string input) => Input.Parse(input.Replace(" ", null));
}