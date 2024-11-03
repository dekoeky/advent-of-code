namespace advent_of_code._2023._06;

public class InputWithBadKerning(Race[] races) : Input(races)
{
    public new static Input FromFile(string file) => Parse(File.ReadAllText(file).Replace(" ", null));
}