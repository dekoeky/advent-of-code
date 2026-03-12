using System.Diagnostics;

namespace advent_of_code._Templates.Day19;

internal static class Calculations
{
    public static int DistinctMutationsCount(PuzzleInput puzzle) => DistinctMutations(puzzle.Input, puzzle.Replacements).Count();

    public static IEnumerable<string> DistinctMutations(string input, ICollection<Replacement> replacements)
    {
        var allMutations = replacements.SelectMany(r => Mutations(input, r.From, r.To));
        var distinctMutations = allMutations.Distinct();

        return distinctMutations;
    }

    private static IEnumerable<string> Mutations(string input, string from, string to)
    {
        int startIndex = 0;
        while ((startIndex = input.IndexOf(from, startIndex)) != -1)
        {
            string replaced = $"{input[..startIndex]}{to}{input[(startIndex + from.Length)..]}";

            Debug.WriteLine(replaced);

            yield return replaced;

            // avoid finding the same result again
            startIndex++;
        }
    }
    private static IEnumerable<string> MutationsReverse(string input, string from, string to)
    {
        int startIndex = 0;
        while ((startIndex = input.IndexOf(to, startIndex)) != -1)
        {
            string replaced = $"{input[..startIndex]}{from}{input[(startIndex + to.Length)..]}";

            Debug.WriteLine(replaced);

            yield return replaced;

            // avoid finding the same result again
            startIndex++;
        }
    }


    public static int MinStepsToReachTarget(ICollection<Replacement> replacements, string start, string target, int count = 0, HashSet<string>? visited = null!)
    {
        visited ??= [target];

        // Since we know that replacements never create a shorter result than an input, we can use this as the limit of our brute force
        var validReplacements = replacements.Where(r => target.Length - r.Delta >= start.Length)
            .OrderBy(r => r.Delta)  // biggest shrinkers in size first
            .ToList();
        var distinctMutations = validReplacements.SelectMany(r => MutationsReverse(target, r.From, r.To))
            .Distinct()
            .OrderBy(m => m.Length) // shortest mutations first
            .ToList();

        // the number of replacements, for each of our mutations, has now increased
        count++;

        foreach (var mutation in distinctMutations)
        {
            //// if for some reason a mutation ends up in the same mutation as we started, we ignore this mutation
            //if (mutation == start)
            //    continue;

            // Ignore already tested mutations
            if (!visited.Add(mutation))
                continue;

            // Ignore mutations that are too short
            if (mutation.Length < start.Length)
                continue;

            if (mutation == start)
            {
                return count;
            }

            // At this point we know:
            //   - The mutation did not match our target
            //   - The length is <= than our target length

            return MinStepsToReachTarget(validReplacements, start, mutation, count);
        }

        throw new InvalidOperationException();
    }
}