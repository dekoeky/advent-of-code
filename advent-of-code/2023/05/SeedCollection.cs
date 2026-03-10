
using System.Collections;

namespace advent_of_code._2023._05;

public class SeedCollection(List<ulong> items) : IEnumerable<ulong>
{
    private const string title = "seeds: ";

    public static SeedCollection Parse(string s, IFormatProvider? provider)
    {
        if (s.StartsWith(title)) s = s[title.Length..];
        var seeds = s.Split(' ').ToList();
        var xx = seeds.Select(ulong.Parse).ToList();
        return new SeedCollection(xx);
    }


    public IEnumerator<ulong> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)items).GetEnumerator();
    }
}