using advent_of_code.Helpers;

namespace advent_of_code._2015.Day15;

internal static class Ingredients
{
    public static Ingredient[] Parse(string input) => [.. SplitOn.NewLines(input).Select(Ingredient.Parse)];
}