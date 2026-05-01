using System.Runtime.CompilerServices;

namespace AdventOfCode._2021.Day14;

internal class InsertionRules
{
    public static Dictionary<int, char> Parse(ReadOnlySpan<char> input)
    {
        var rules = new Dictionary<int, char>();

        foreach (var line in input.EnumerateLines())
        {
            // Parse only non-empty lines containing ->
            if (line.IsEmpty || !line.Contains("->", StringComparison.InvariantCulture)) continue;

            // Convert into a key
            var key = CreateKey(line[..2]);
            var letterToInsert = line[^1];

            rules.Add(key, letterToInsert);
        }

        return rules;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CreateKey(ReadOnlySpan<char> s) => CreateKey(s[0], s[1]);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CreateKey(char a, char b) => (a - 'A') * 26 + (b - 'A');

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (char a, char b) Expand(int key)
    {
        var a = (char)((key / 26) + 'A');
        var b = (char)((key % 26) + 'A');

        return (a, b);
    }
}