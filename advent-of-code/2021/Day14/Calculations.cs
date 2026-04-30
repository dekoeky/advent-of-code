namespace advent_of_code._2021.Day14;

internal static class Calculations
{
    public static long Execute(ReadOnlySpan<char> input, int steps)
    {
        var polymerTemplate = input.FirstLine();
        var rules = InsertionRules.Parse(input);
        var patternCounts = new long[26 * 26]; // Store counts of AA, AB, .., BA, BC, ..., ZZ
        var newPatternCounts = new long[26 * 26];
        var letterCounts = new long[26];

        // Count current occurences
        for (var i = 0; i < polymerTemplate.Length; i++)
        {
            var a = polymerTemplate[i];
            letterCounts[a - 'A']++;

            if (i == polymerTemplate.Length - 1) continue;
            var b = polymerTemplate[i + 1];
            var key = InsertionRules.CreateKey(a, b);
            patternCounts[key]++;
        }

        for (var step = 0; step < steps; step++)
        {
            // Process only existing rules (keys)
            foreach (var rule in rules.Keys)
            {
                var n = patternCounts[rule];

                // If the pattern does not occur, no need to process
                if (n == 0) continue;

                var letterToInsert = rules[rule];

                // The current pattern will dissapear n times (because a new letter comes in the middle of each occurrance)
                newPatternCounts[rule] -= n;

                // Get the two letters from the key
                var (a, b) = InsertionRules.Expand(rule);

                // Get the keys for the two newly created patterns
                var ac = InsertionRules.CreateKey(a, letterToInsert);
                var cb = InsertionRules.CreateKey(letterToInsert, b);

                // The letter being inserted will occur n times more
                letterCounts[letterToInsert - 'A'] += n;

                // The ac and cb pattern will occur n times more
                newPatternCounts[ac] += n;
                newPatternCounts[cb] += n;
            }

            for (var i = 0; i < patternCounts.Length; i++)
            {
                // Update the actual pattern counts (both + and -)
                patternCounts[i] += newPatternCounts[i];

                // Prevent adding again
                newPatternCounts[i] = 0;
            }
        }

        // Get the number of occurences for both the most and least occuring letter
        var max = letterCounts.Max();
        var min = letterCounts.Where(c => c > 0).Min();

        // The result is the difference
        return max - min;
    }
}