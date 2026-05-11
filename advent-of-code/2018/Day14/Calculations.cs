using System.Runtime.InteropServices;

namespace advent_of_code._2018.Day14;

internal static class Calculations
{
    public static long Part1(int input)
    {
        var indexA = 0;
        var indexB = 1;
        List<byte> recipes = [3, 7];

        while (recipes.Count < (10 + input))
        {
            var recipeA = recipes[indexA];
            var recipeB = recipes[indexB];
            var sum = (byte)(recipeA + recipeB);
            if (sum >= 10)
            {
                // Sum can only be 10-19
                recipes.Add(1);
                recipes.Add((byte)(sum - 10));
            }
            else
            {
                recipes.Add(sum);
            }

            // Tep Forward 1 + current recipe
            indexA = (indexA + 1 + recipeA) % recipes.Count;
            indexB = (indexB + 1 + recipeB) % recipes.Count;
        }

        var tenRecipes = CollectionsMarshal.AsSpan(recipes).Slice(input, 10);
        return Score(tenRecipes);
    }

    public static int Part2(string input)
    {
        var indexA = 0;
        var indexB = 1;
        var processed = 0;
        List<byte> recipes = [3, 7];
        var scoreToMatch = ToDigits(input);

        while (true)
        {
            var recipeA = recipes[indexA];
            var recipeB = recipes[indexB];
            var sum = (byte)(recipeA + recipeB);
            if (sum >= 10)
            {
                // Sum can only be 10-19
                recipes.Add(1);
                recipes.Add((byte)(sum - 10));
            }
            else
            {
                recipes.Add(sum);
            }

            // Tep Forward 1 + current recipe
            indexA = (indexA + 1 + recipeA) % recipes.Count;
            indexB = (indexB + 1 + recipeB) % recipes.Count;

            if (recipes.Count < processed + scoreToMatch.Length) continue;

            while (processed + scoreToMatch.Length <= recipes.Count)
            {
                var match = true;

                for (var i = 0; i < scoreToMatch.Length; i++)
                    if (recipes[processed + i] != scoreToMatch[i])
                    {
                        match = false;
                        break;
                    }

                if (match) return processed;

                processed++;
            }
        }
        throw new InvalidOperationException("Solution not found");
    }

    private static byte[] ToDigits(ReadOnlySpan<char> value)
    {
        var digits = new byte[value.Length];
        var i = 0;

        foreach (var c in value)
            digits[i++] = (byte)(c - '0');

        return digits;
    }

    private static long Score(ReadOnlySpan<byte> recipes)
    {
        long sum = 0;

        foreach (var recipe in recipes)
        {
            sum *= 10;
            sum += recipe;
        }

        return sum;
    }
}