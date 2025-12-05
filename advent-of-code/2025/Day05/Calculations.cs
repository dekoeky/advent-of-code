using advent_of_code.Helpers;
using System.Diagnostics;

namespace advent_of_code._2025.Day05;

public static class Calculations
{
    public static long HowManyIngredientsAreFresh(string input)
    {
        FreshIngredientsIdRanges(input, out var freshIngredientRanges, out var availableIngredients);

        return availableIngredients.Count(id => IsFresh(id, freshIngredientRanges));
    }

    private static void FreshIngredientsIdRanges(string input,
        out IngredientIdRange[] freshIngredientRanges,
        out long[] availableIngredients)
    {
        // The database operates on ingredient IDs.
        // It consists of
        //      a list of fresh ingredient ID ranges,
        //      a blank line,
        //      and a list of available ingredient IDs.
        var parts = SplitOn.EmptyLines(input);

        freshIngredientRanges = SplitOn.NewLines(parts[0])
           .Select(IngredientIdRange.Parse)
           .ToArray();

        availableIngredients = SplitOn.NewLines(parts[1])
            .Select(long.Parse)
            .ToArray();
    }

    private static bool IsFresh(long ingredient, IngredientIdRange[] freshRanges) => freshRanges.Any(r => r.ContainsIngredient(ingredient));

    public static long CountIngredientIdsInFreshRange(string input)
    {
        FreshIngredientsIdRanges(input, out var freshIngredientRanges, out _);

        var count = 0L;
        var countedUpUntil = long.MinValue;

        // We loop ranges, starting with the ones with the earliest start
        foreach (var range in freshIngredientRanges.OrderBy(r => r.Start))
        {
            // If the end of this range is past the id we counted up to,
            // this range does not have any more possible ids we can count
            if (countedUpUntil >= range.End)
            {
                Debug.WriteLine($"Skipping range {range}, because we counted up until {countedUpUntil}");
                continue;
            }

            Debug.WriteLine($"Evaluating range {range}...");

            // Indicate we don't want to add ids below range.
            // Example: If the last range added ids 10-20, 
            // and this range is 30-40,
            // We don't want to add 21-29
            countedUpUntil = Math.Max(countedUpUntil, range.Start - 1);

            // Count how many fresh ids this range gives us
            // Example:
            // Counted up until 15,
            // now processing range 10-20
            // we only need to count 16,17,18,19,20 = +5
            var freshIdsFound = range.End - countedUpUntil;
            count += freshIdsFound;
            Debug.WriteLine($"Found {freshIdsFound} more ids ({countedUpUntil + 1}-{range.End})");

            // Indicate we counted ids up until range.End
            // This ensures we don't count ids double (for overlapping ranges)
            // And we can skip processing some ranges next
            countedUpUntil = range.End;

            // Readability
            Debug.WriteLine("");
        }

        return count;
    }
}