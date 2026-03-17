namespace advent_of_code._2016.Day06;

internal static class Calculations
{
    private static char MostOccurringCharacter(KeyValuePair<int, Dictionary<char, int>> charCounts)
        => charCounts.Value.MaxBy(count => count.Value).Key;

    private static char LeastOccurringCharacter(KeyValuePair<int, Dictionary<char, int>> charCounts)
        => charCounts.Value.MinBy(count => count.Value).Key;



    public static string ErrorCorrect1(ReadOnlySpan<char> input)
        => ErrorCorrect(input, MostOccurringCharacter);

    public static string ErrorCorrect2(ReadOnlySpan<char> input)
        => ErrorCorrect(input, LeastOccurringCharacter);



    private static string ErrorCorrect(
        ReadOnlySpan<char> input,
        Func<KeyValuePair<int, Dictionary<char, int>>, char> winningCharacter)
    {
        var counts = new Dictionary<int, Dictionary<char, int>>();

        foreach (var line in input.EnumerateLines())
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (!counts.TryGetValue(i, out var countsForThisIndex))
                {
                    countsForThisIndex = [];
                    counts.Add(i, countsForThisIndex);
                }

                var character = line[i];

                if (countsForThisIndex.TryGetValue(character, out int value))
                    countsForThisIndex[character] = ++value;
                else
                    countsForThisIndex.Add(character, 1);
            }
        }

        var resultingChars = counts.Select(winningCharacter).ToArray();

        return new string(resultingChars);
    }
}