namespace advent_of_code._2024.Day25;

public static class Calculations
{
    public static int CountFittingCombinations(string input)
    {
        LockOrKey.ParseMany(input, out var locks, out var keys);

        //foreach (var @lock in locks) Debug.WriteLine(@lock);
        //foreach (var key in keys) Debug.WriteLine(key);

        var uniqueCombinations = locks.SelectMany(_ => keys, (@lock, key) => (@lock, key));
        return uniqueCombinations.Count(combination => !combination.key.HasOverlapWith(combination.@lock));
    }
}