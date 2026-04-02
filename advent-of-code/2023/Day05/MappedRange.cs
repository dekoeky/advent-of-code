namespace advent_of_code._2023.Day05;

internal struct MappedRange(ulong DestinationStart, ulong SourceStart, ulong Length) : IParsable<MappedRange>
{
    public static MappedRange Parse(string s, IFormatProvider? provider)
    {
        var numbers = s.Split(' ').Select(ulong.Parse).ToArray();

        return new MappedRange(numbers[0], numbers[1], numbers[2]);
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out MappedRange result)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<KeyValuePair<ulong, ulong>> Expand()
    {
        for (ulong i = 0; i < Length; i++)
            yield return new KeyValuePair<ulong, ulong>(SourceStart + i, DestinationStart + i);
    }
}