namespace advent_of_code._2015.Day13;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var lines = SplitOn.NewLines(input);
        var nameToIndex = BuildNameMap(lines);
        var happiness = BuildHappinessMatrix(lines, nameToIndex);

        return MaxHappiness(happiness);
    }

    public static int Part2(string input)
    {
        var lines = SplitOn.NewLines(input);
        var nameToIndex = BuildNameMap(lines);

        // Add "you" as extra person
        int youIndex = nameToIndex.Count;
        nameToIndex["you"] = youIndex;

        var happiness = BuildHappinessMatrix(lines, nameToIndex);

        // Expand matrix with zeros for "you"
        int n = happiness.GetLength(0);
        var expanded = new int[n + 1, n + 1];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                expanded[i, j] = happiness[i, j];
            }
        // last row/col already zero

        return MaxHappiness(expanded);
    }

    private static Dictionary<string, int> BuildNameMap(string[] lines)
    {
        var map = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (var line in lines)
        {
            // Example:
            // Alice would gain 54 happiness units by sitting next to Bob.
            var parts = line.Split(' ');
            string a = parts[0];
            string b = parts[^1].TrimEnd('.');

            if (!map.ContainsKey(a))
                map[a] = map.Count;
            if (!map.ContainsKey(b))
                map[b] = map.Count;
        }
        return map;
    }

    private static int[,] BuildHappinessMatrix(string[] lines, Dictionary<string, int> nameToIndex)
    {
        int n = nameToIndex.Count;
        var matrix = new int[n, n];

        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            string aName = parts[0];
            bool gain = parts[2] == "gain";
            int value = int.Parse(parts[3]);
            string bName = parts[^1].TrimEnd('.');

            int a = nameToIndex[aName];
            int b = nameToIndex[bName];

            matrix[a, b] = gain ? value : -value;
        }

        return matrix;
    }

    private static int MaxHappiness(int[,] happiness)
    {
        int n = happiness.GetLength(0);
        if (n <= 1)
            return 0;

        // Fix person 0 to break rotational symmetry
        int[] perm = new int[n - 1];
        for (int i = 0; i < n - 1; i++)
            perm[i] = i + 1;

        int best = int.MinValue;

        do
        {
            int total = 0;

            int prev = 0;
            for (int i = 0; i < perm.Length; i++)
            {
                int curr = perm[i];
                total += happiness[prev, curr] + happiness[curr, prev];
                prev = curr;
            }

            // close the circle: last <-> 0
            total += happiness[prev, 0] + happiness[0, prev];

            if (total > best)
                best = total;

        } while (NextPermutation(perm));

        return best;
    }

    // Lexicographic next permutation on int[]
    private static bool NextPermutation(int[] a)
    {
        int n = a.Length;
        int i = n - 2;
        while (i >= 0 && a[i] >= a[i + 1]) i--;
        if (i < 0) return false;

        int j = n - 1;
        while (a[j] <= a[i]) j--;

        (a[i], a[j]) = (a[j], a[i]);

        int l = i + 1;
        int r = n - 1;
        while (l < r)
        {
            (a[l], a[r]) = (a[r], a[l]);
            l++;
            r--;
        }

        return true;
    }
}