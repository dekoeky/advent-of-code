namespace advent_of_code._2024._05;

internal struct MappedRange(NumberType DestinationStart, NumberType SourceStart, NumberType Length) : IParsable<MappedRange>
{
    public static MappedRange Parse(string s, IFormatProvider? provider)
    {
        var numbers = s.Split(' ').Select(NumberType.Parse).ToArray();

        return new MappedRange(numbers[0], numbers[1], numbers[2]);
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out MappedRange result)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<KeyValuePair<NumberType, NumberType>> Expand()
    {
        for (NumberType i = 0; i < Length; i++)
            yield return new KeyValuePair<NumberType, NumberType>(SourceStart + i, DestinationStart + i);
    }
}