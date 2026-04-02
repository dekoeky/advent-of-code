namespace advent_of_code._2023.Day05;

public class Almanac
{
    public required SeedCollection Seeds { get; set; }
    public required MappingCollection Mapping { get; set; }

    public static Almanac Parse(string s)
    {
        //Split on empty lines
        var parts = s.Split(Environment.NewLine + Environment.NewLine);

        //First part is always the seeds
        var seeds = SeedCollection.Parse(parts.First(), null);

        //All the other parts are
        var mappings = parts.Skip(1).Select(p => MappingData.Parse(p, null));

        return new Almanac()
        {
            Seeds = seeds,
            Mapping = new MappingCollection(mappings),
        };
    }

    public Mappertje this[string from, string to] => GetMapper(from, to);

    public override string ToString() => "seeds: " + string.Join(" ", Seeds);

    public IEnumerable<(string, string)> FindPath(string from, string to)
    {
        var last = from;
        List<(string, string)> path = [];
        for (int i = 0; i < this.Mapping.Data.Count; i++)
        {
            var found = this.Mapping.Data.Keys.First(key => key.From == last); //Assume always one mapping per object
            path.Add(found);
            last = found.To;
            if (found.To == to) return path;
        }

        throw new InvalidOperationException(); //Did not work out
    }

    public Mappertje GetMapper(string from, string to)
    {
        var path = FindPath(from, to);
        var action = (ulong input) =>
        {
            foreach (var map in path)
            {
                var dictionary = Mapping.Data[map];
                input = dictionary.TryGetValue(input, out var result) ? result : input;
            }

            return input;
        };
        return new Mappertje(action);
    }
}

public class Mappertje(Func<ulong, ulong> lookup)
{
    public Func<ulong, ulong> Lookup { get; } = lookup;
}
public class MappingCollection(IEnumerable<MappingData> mappings)
{
    public Dictionary<(string From, string To), Dictionary<ulong, ulong>> Data
        = mappings.ToDictionary(m => (m.From, m.To), m => m.MappedNumbers);
}