namespace advent_of_code._2025.Day02;

internal class IdRange
{
    public long First { get; init; }
    public long Last { get; init; }

    public override string ToString() => $"{First}{Constants.FirstAndLastSeparator}{Last}";

    public static IdRange Parse(string s)
    {
        var parts = s.Split(Constants.FirstAndLastSeparator);

        return new IdRange
        {
            First = long.Parse(parts[0]),
            Last = long.Parse(parts[1]),
        };
    }

    public IEnumerable<long> GetInvalidNumbers()
    {
        for (var i = First; i <= Last; i++)
            if (!Validate(i))
                yield return i;
    }

    public static bool Validate(long number)
    {
        var s = number.ToString();
        var l = s.Length;

        // Cant have ABAB when length is odd
        if (l % 2 != 0) return true;

        var halfL = l / 2;

        var firstHalf = s.AsSpan(0, halfL);
        var secondHalf = s.AsSpan(halfL, halfL);

        return !firstHalf.SequenceEqual(secondHalf);
    }
}