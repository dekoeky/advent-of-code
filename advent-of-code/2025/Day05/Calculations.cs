using advent_of_code.Helpers;

namespace advent_of_code._2025.Day05;

public static class Calculations
{
    public static long HowManyIngredientsAreFresh(string input)
    {
        // The database operates on ingredient IDs.
        // It consists of
        //      a list of fresh ingredient ID ranges,
        //      a blank line,
        //      and a list of available ingredient IDs.
        var parts = SplitOn.EmptyLines(input);

        var freshIngredientsIdRanges = SplitOn.NewLines(parts[0])
            .Select(IngredientIdRange.Parse)
            .ToArray();

        var availableIngredients = SplitOn.NewLines(parts[1])
            .Select(long.Parse)
            .ToArray();

        return availableIngredients.Count(id => IsFresh(id, freshIngredientsIdRanges));
    }

    private static bool IsFresh(long ingredient, IngredientIdRange[] freshRanges) => freshRanges.Any(r => r.InRange(ingredient));
}