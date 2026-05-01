namespace AdventOfCode._2015.Day13;

internal static class Calculations
{
    public static int OptimalSeatingHappiness(string input, bool includeMe = false)
    {
        var rules = SplitOn.NewLines(input).Select(Rule.Parse).ToArray();
        //foreach (var rule in rules) Debug.WriteLine(rule.ToParsableString());

        var a = rules.Select(r => r.Name);
        var b = rules.Select(r => r.Neighbor);
        var people = a.Concat(b).Distinct().ToList();
        if (includeMe) people.Add("me");

        return GetCombinationHapinesses(rules, people).Max();
    }

    private static IEnumerable<int> GetCombinationHapinesses(Rule[] rules, IReadOnlyCollection<string> people)
    {
        foreach (var seatingArrangement in people.AllPermutations())
            yield return CalclateHappiness(rules, seatingArrangement);
    }

    private static int CalclateHappiness(Rule[] rules, IReadOnlyCollection<string> seatingArrangement)
    {
        var happiness = 0;

        for (int i = 0; i < seatingArrangement.Count; i++)
        {
            var personBeingChecked = seatingArrangement.ElementAt(i);
            string[] neighbors = [
                seatingArrangement.ElementAt ((seatingArrangement .Count + i + 1) % seatingArrangement.Count ),
                seatingArrangement.ElementAt ((seatingArrangement .Count + i - 1) % seatingArrangement.Count ),
                ];
            var applicableRules = rules.Where(r => r.Name == personBeingChecked && neighbors.Contains(r.Neighbor));

            foreach (var rule in applicableRules)
            {
                Debug.WriteLine(rule.GetApplicableText());
                happiness += rule.HappinessGain;
            }
        }

        return happiness;
    }
}