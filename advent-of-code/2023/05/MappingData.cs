namespace advent_of_code._2024._05;

public class MappingData : IParsable<MappingData>
{
    public string From { get; set; }
    public string To { get; set; }


    public Dictionary<NumberType, NumberType> MappedNumbers = new();
    public static MappingData Parse(string s, IFormatProvider? provider)
    {
        var lines = s.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var names = Names.Parse(lines.First());
        var specifiedMaps = lines.Skip(1).Select(l => MappedRange.Parse(l, null));
        var mapped = specifiedMaps.SelectMany(m => m.Expand());

        return new MappingData()
        {
            From = names.Source,
            To = names.Destination,
            MappedNumbers = mapped.ToDictionary(kv => kv.Key, kv => kv.Value),
        };
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out MappingData result)
    {
        throw new NotImplementedException();
    }
}