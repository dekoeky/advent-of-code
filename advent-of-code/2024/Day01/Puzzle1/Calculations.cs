namespace advent_of_code._2024._01.Puzzle1;

public static class Calculations
{
    public static int CalculateTotalDistance(List<int> list1, List<int> list2)
    {
        if (list1.Count != list2.Count) throw new InvalidOperationException("Lists are not same size");

        list1 = list1.OrderBy(x => x).ToList();
        list2 = list2.OrderBy(x => x).ToList();

        int distance = 0;

        for (int i = 0; i < list1.Count; i++)
        {
            var l = list1[i];
            var r = list2[i];

            if (l == r) continue;

            distance += (l > r)
                ? (l - r)
                : (r - l);
        }

        return distance;
    }


    public static int CalculateSimilarityScore(List<int> list1, List<int> list2)
    {
        if (list1.Count != list2.Count) throw new InvalidOperationException("Lists are not same size");

        var list2Occurrences = list2.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        int similarity = 0;

        foreach (var number in list1)
        {
            if (list2Occurrences.TryGetValue(number, out var occurences))
                similarity += number * occurences;
        }

        return similarity;
    }
}