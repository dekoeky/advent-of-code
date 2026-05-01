namespace AdventOfCode._2018.Day07;

internal static class Calculations
{
    public static string Part1(string input)
    {
        var blockedBy = GetBlockers(input);
        var result = new char[26];
        var l = 0;

        while (blockedBy.Count > 0)
        {
            var firstNonBlocked = blockedBy.First(kv => kv.Value.Count == 0).Key;

            result[l++] = firstNonBlocked;

            // Indicate that this letter is not a blocker anymore
            foreach (var blockList in blockedBy.Values)
                blockList.Remove(firstNonBlocked);

            blockedBy.Remove(firstNonBlocked);
        }

        return new string(result.AsSpan(0, l));
    }

    public static int Part2(string input, int workers, Func<char, int> calculateDuration)
    {
        var blockedBy = GetBlockers(input);
        var runningTasks = new Dictionary<char, int>(workers);
        var second = 0;

        while (blockedBy.Count > 0 || runningTasks.Count > 0)
        {
            // As long as there are workers that have nothing to do,
            // we can check if we can start tasks
            if (runningTasks.Count < workers)
            {
                var tasksToStart = blockedBy
                    .Where(kv => kv.Value.Count == 0)       // We can only start tasks that are not blocked
                    .OrderBy(kv => kv.Key)
                    .Take(workers - runningTasks.Count)     // We can only start tasks for workers with nothing to do
                    .Select(kv => kv.Key)
                    .ToArray();

                foreach (var taskToStart in tasksToStart)
                {
                    // Start each task, with the time needed to finish the task
                    runningTasks.Add(taskToStart, calculateDuration(taskToStart));

                    // Indicate the task is not blocked anymore
                    blockedBy.Remove(taskToStart);

                    // We don't remove it as a blocker yet
                }
            }

            // Simulate tasks running
            foreach (var t in runningTasks.Keys.ToArray())
                if (--runningTasks[t] <= 0)
                {
                    // Indicate that this letter is not a blocker anymore
                    foreach (var blockList in blockedBy.Values)
                        blockList.Remove(t);

                    runningTasks.Remove(t);
                }
            second++;
        }

        return second;
    }

    private static SortedDictionary<char, HashSet<char>> GetBlockers(string input)
    {
        // Using sorted dictionary helps processing alphabetically
        SortedDictionary<char, HashSet<char>> blockedBy = [];

        foreach (var instr in Instruction.ParseMany(input))
        {
            if (!blockedBy.TryGetValue(instr.After, out var blockers))
            {
                blockers = [];
                blockedBy.Add(instr.After, blockers);
            }

            // 'Before' blocks 'After'
            blockers.Add(instr.Before);

            // Also make sure each char is in the keys
            if (!blockedBy.ContainsKey(instr.Before))
                blockedBy.Add(instr.Before, []);
        }

        return blockedBy;
    }
}
