global using NumberType = ulong;
using System.Collections;

namespace advent_of_code._2023._05;

public class SeedCollection(List<NumberType> items) : IParsable<SeedCollection>, IEnumerable<NumberType>
{
    private const string title = "seeds: ";

    public static SeedCollection Parse(string s, IFormatProvider? provider)
    {
        if (s.StartsWith(title)) s = s[title.Length..];
        var seeds = s.Split(' ').ToList();
        var xx = seeds.Select(NumberType.Parse).ToList();
        return new SeedCollection(xx);
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out SeedCollection result)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<NumberType> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)items).GetEnumerator();
    }
}