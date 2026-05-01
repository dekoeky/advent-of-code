namespace AdventOfCode._2015.Day24;

public static class Calculations
{
    public static long Solve(int[] packages, int groups)
    {
        // If all groups need to weigh the same, we should be able to get a target weight for each group
        int total = packages.Sum();
        int target = total / groups;

        // Sort heavy to light, to find a solution faster
        var sorted = packages.OrderByDescending(x => x).ToArray();

        // Try small group 1 first, 
        for (int size = 1; size <= sorted.Length; size++)
        {
            var validGroups =
                Combinations(sorted, size)
                .Where(c => c.Sum() == target)
                .ToList();

            if (validGroups.Count == 0)
                continue;

            return validGroups.Min(c => c.Aggregate(1L, (acc, v) => acc * v));
        }

        throw new Exception("No valid group found.");
    }

    private static IEnumerable<List<int>> Combinations(int[] arr, int size)
    {
        int n = arr.Length;
        int[] idx = [.. Enumerable.Range(0, size)];

        while (true)
        {
            var combo = new List<int>(size);
            for (int i = 0; i < size; i++)
                combo.Add(arr[idx[i]]);
            yield return combo;

            int k;
            for (k = size - 1; k >= 0; k--)
                if (idx[k] != k + n - size)
                    break;

            if (k < 0)
                yield break;

            idx[k]++;
            for (int j = k + 1; j < size; j++)
                idx[j] = idx[j - 1] + 1;
        }
    }
}