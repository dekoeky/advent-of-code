namespace advent_of_code._2023._05;

public class MappingData : IParsable<MappingData>
{
    public required string From { get; set; }
    public required string To { get; set; }


    public Dictionary<ulong, ulong> MappedNumbers = [];
    private static readonly char[] separators = ['\r', '\n'];

    public static MappingData Parse(string s, IFormatProvider? provider)
    {
        var lines = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        var (Source, Destination) = Names.Parse(lines.First());
        var specifiedMaps = lines.Skip(1).Select(l => MappedRange.Parse(l, null));
        var mapped = specifiedMaps.SelectMany(m => m.Expand());

        return new MappingData()
        {
            From = Source,
            To = Destination,
            MappedNumbers = mapped.ToDictionary(kv => kv.Key, kv => kv.Value),
        };
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out MappingData result)
    {
        throw new NotImplementedException();
    }
}