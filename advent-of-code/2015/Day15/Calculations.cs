namespace advent_of_code._2015.Day15;

internal static class Calculations
{
    public static long HighestScoringRecipe(string input, int? caloryRequirement = null)
    {
        var ingredients = Ingredients.Parse(input);

        var combos = Combinations.AddingUpToTarget(ingredients.Length, 100);
        var scores = combos.Select(counts => CalculateScore(ingredients, counts, caloryRequirement));

        return scores.Max();
    }

    static readonly string[] scoringProperties = [
        "capacity",
        "durability",
        "flavor",
        "texture",
        // calories not!
        ];

    public static long CalculateScore(Ingredient[] ingredients, int[] counts, int? caloryRequirement)
    {
        if (ingredients.Length != counts.Length) throw new InvalidOperationException();

        var totals = new Dictionary<string, long>();

        for (int i = 0; i < ingredients.Length; i++)
        {
            var ingredient = ingredients[i];
            var teaSpoons = counts[i];

            foreach (var (property, impact) in ingredient.Properties)
                if (totals.ContainsKey(property))
                    totals[property] += teaSpoons * impact;
                else
                    totals.Add(property, teaSpoons * impact);
        }

        // If any properties had produced a negative total, it would have instead become zero, causing the whole score to multiply to zero.
        foreach (var property in totals.Keys)
            if (totals[property] < 0)
                totals[property] = 0;

        if (caloryRequirement is not null && totals["calories"] != caloryRequirement)
            return 0;
        else
            return scoringProperties.Product(totals.GetValueOrDefault);
    }

}
