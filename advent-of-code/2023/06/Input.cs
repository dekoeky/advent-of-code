namespace advent_of_code._2023._06;

public class Input(Race[] races)
{
    public static Input Parse(string s)
    {
        var lines = s.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        lines = lines.Select(l => l.Split(':')[1]).ToArray();
        var numbers = lines.Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(ulong.Parse).ToArray()).ToArray();
        var times = numbers[0];
        var distances = numbers[1];

        return new Input(Race.Combine(times, distances).ToArray());
    }


    public ulong PossibilitiesMultiplied()
    {
        var xxx = races.Select(r => r.NumberOfPossibilitiesForWinning()).ToArray();

        return xxx.CalculateProduct();
    }
}