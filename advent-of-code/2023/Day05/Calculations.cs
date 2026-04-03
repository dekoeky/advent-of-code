namespace advent_of_code._2023.Day05;

internal static class Calculations
{
    public static long Perform(string input)
    {
        var almanac = Almanac.Parse(input);

        Dictionary<long, Dictionary<string, long>> allResults = [];

        foreach (var seed in almanac.Seeds)
        {
            var from = "seed";
            var value = seed;
            Dictionary<string, long> values = [];
            values.Add(from, value);

            foreach (var mapper in almanac.MappingGroups)
            {
                // double check our assumption: "Mappings are chronological"
                if (mapper.From != values.Keys.Last()) throw new InvalidOperationException();

                var mappedValue = mapper.Map(values.Values.Last());
                values.Add(mapper.To, mappedValue);

                Debug.WriteLine($"Mapped '{from}' {value} to '{mapper.To}' {mappedValue}");

                value = mappedValue;
                from = mapper.To;
            }

            allResults.Add(seed, values);
            Debug.WriteLine();
            Debug.WriteLine();
        }

        return allResults.Values.Min(v => v["location"]);
    }
}
