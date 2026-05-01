namespace AdventOfCode._2016.Day14;

internal static class DictionaryExtensions
{
    public static string GetOrCalculateAndInsert(this Dictionary<int, string> hashes, int key, Func<string> factory)
    {
        if (hashes.TryGetValue(key, out string? value))
            return value;

        // Calculate the missing value
        value = factory();

        // Store the calculated value
        hashes.Add(key, value);

        // Return calculated value
        return value;
    }
}