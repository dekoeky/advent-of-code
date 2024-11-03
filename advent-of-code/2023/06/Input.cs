namespace advent_of_code._2023._06;

public class Input(Race[] races) : IParsable<Input>
{

    public static Input FromFile(string file) => Parse(File.ReadAllText(file));
    public static Input Parse(string s, IFormatProvider? provider = null)
    {
        var lines = s.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        lines = lines.Select(l => l.Split(':')[1]).ToArray();
        var numbers = lines.Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(ulong.Parse).ToArray()).ToArray();
        var times = numbers[0];
        var distances = numbers[1];

        return new Input(Race.Combine(times, distances).ToArray());
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out Input result)
    {
        throw new NotImplementedException();
    }


    public ulong PossibilitiesMultiplied()
    {
        var xxx = races.Select(r => r.NumberOfPossibilitiesForWinning()).ToArray();

        return xxx.CalculateProduct();
    }
}