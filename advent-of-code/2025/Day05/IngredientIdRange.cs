using System.Collections;

namespace advent_of_code._2025.Day05;

internal readonly struct IngredientIdRange(long start, long end) : IEnumerable<long>
{
    public long Start { get; } = start;
    public long End { get; } = end;

    public static IngredientIdRange Parse(string input) => Parse((ReadOnlySpan<char>)input);
    public static IngredientIdRange Parse(ReadOnlySpan<char> input)
    {
        var i = input.LastIndexOf('-');

        var start = long.Parse(input[..i]);
        var end = long.Parse(input[(i + 1)..]);

        return new IngredientIdRange(start, end);
    }

    // The fresh ID ranges are inclusive: the range 3-5 means that ingredient IDs 3, 4, and 5 are all fresh.
    // The ranges can also overlap;
    // an ingredient ID is fresh if it is in any range.
    public bool ContainsIngredient(long ingredientId) => Start <= ingredientId && ingredientId <= End;

    /// <summary>
    /// Returns true if the <paramref name="other"/> is fully included in this range.
    /// </summary>
    public bool Contains(IngredientIdRange other) => Start <= other.Start && other.End <= End;

    public IEnumerator<long> GetEnumerator()
    {
        for (var id = start; id <= end; id++)
            yield return id;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public override string ToString() => $"{Start}-{End}";
}