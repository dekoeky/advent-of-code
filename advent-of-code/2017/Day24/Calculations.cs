namespace advent_of_code._2017.Day24;

internal static class Calculations
{
    public static (int Part1, int Part2) Solve(string input)
    {
        var lines = SplitOn.NewLines(input);

        var comps = new Component[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            var s = lines[i].Trim();
            var slash = s.IndexOf('/');
            var a = int.Parse(s.AsSpan(0, slash));
            var b = int.Parse(s.AsSpan(slash + 1));
            comps[i] = new Component(a, b);
        }

        // Precompute adjacency: port -> list of component indices
        var adj = new Dictionary<int, List<int>>();
        for (int i = 0; i < comps.Length; i++)
        {
            void Add(int p)
            {
                if (!adj.TryGetValue(p, out var list))
                {
                    list = new List<int>();
                    adj[p] = list;
                }
                list.Add(i);
            }

            Add(comps[i].A);
            Add(comps[i].B);
        }

        var used = new bool[comps.Length];

        int bestStrength = 0;                 // Part 1
        int bestLength = 0;                   // Part 2
        int bestStrengthForBestLength = 0;

        void Dfs(int port, int strength, int length)
        {
            // Update Part 1
            if (strength > bestStrength)
                bestStrength = strength;

            // Update Part 2
            if (length > bestLength)
            {
                bestLength = length;
                bestStrengthForBestLength = strength;
            }
            else if (length == bestLength && strength > bestStrengthForBestLength)
            {
                bestStrengthForBestLength = strength;
            }

            if (!adj.TryGetValue(port, out var list))
                return;

            foreach (var idx in list)
            {
                if (used[idx]) continue;

                ref readonly var c = ref comps[idx];
                if (!c.Matches(port)) continue;

                used[idx] = true;
                Dfs(c.Other(port), strength + c.Strength, length + 1);
                used[idx] = false;
            }
        }

        Dfs(0, 0, 0);

        return (bestStrength, bestStrengthForBestLength);
    }
}
