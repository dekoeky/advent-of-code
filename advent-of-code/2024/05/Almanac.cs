namespace advent_of_code._2024._05;

public class Almanac : IParsable<Almanac>
{
    public SeedCollection Seeds { get; set; }
    public MappingCollection Mapping { get; set; }

    public static Almanac Parse(string s, IFormatProvider? provider)
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

    public static Almanac FromFile(string filename) => Parse(File.ReadAllText(filename), null);
    public static bool TryParse(string? s, IFormatProvider? provider, out Almanac result)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return
            "seeds: " + string.Join(" ", Seeds);
    }

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
        var action = (NumberType input) =>
        {
            foreach (var map in path)
            {
                var dictionary = this.Mapping.Data[map];
                input = dictionary.TryGetValue(input, out var result) ? result : input;
            }

            return input;
        };
        return new Mappertje(action);
    }
}

public class Mappertje(Func<NumberType, NumberType> lookup)
{
    public Func<NumberType, NumberType> Lookup { get; } = lookup;
}
public class MappingCollection(IEnumerable<MappingData> mappings)
{
    public Dictionary<(string From, string To), Dictionary<NumberType, NumberType>> Data
        = mappings.ToDictionary(m => (m.From, m.To), m => m.MappedNumbers);
}