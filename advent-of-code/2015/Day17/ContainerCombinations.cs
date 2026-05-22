internal static class ContainerCombinations
{
    public static IReadOnlyList<int[]> FindAll(int target, int[] sizes)
    {
        var used = new int[sizes.Length];
        var results = new List<int[]>();

        void Search(int index, int remaining)
        {
            if (remaining == 0)
            {
                // Clear the tail so no stale 1s remain from previous paths
                for (int i = index; i < used.Length; i++)
                    used[i] = 0;

                results.Add((int[])used.Clone());
                return;
            }

            if (index == sizes.Length)
                return;

            // Option 1: skip this container
            used[index] = 0;
            Search(index + 1, remaining);

            // Option 2: use this container (if it fits)
            if (sizes[index] <= remaining)
            {
                used[index] = 1;
                Search(index + 1, remaining - sizes[index]);
                used[index] = 0; // reset for other branches (not strictly required with tail clear, but clean)
            }
        }

        Search(0, target);
        return results;
    }

    public static int SolvePart1(int target, int[] sizes)
    {
        return FindAll(target, sizes).Count;
    }

    public static int SolvePart2(int target, int[] sizes)
    {
        var all = FindAll(target, sizes);

        var counts = all.Select(arr => arr.Sum()).ToList();
        int min = counts.Min();
        return counts.Count(c => c == min);
    }
}