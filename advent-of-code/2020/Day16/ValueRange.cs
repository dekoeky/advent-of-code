namespace advent_of_code._2020.Day16;

internal readonly record struct ValueRange(int LowerInclusive, int Upperinclusive)
{

    public static ValueRange Parse(ReadOnlySpan<char> input)
    {
        var idx = input.IndexOf('-');

        var start = int.Parse(input[..idx]);
        var end = int.Parse(input[(idx + 1)..]);

        return new ValueRange(start, end); // +1 because Range has an exclusive upper range
    }
    public readonly bool ContainsId(int id) => id >= LowerInclusive && id <= Upperinclusive;
}