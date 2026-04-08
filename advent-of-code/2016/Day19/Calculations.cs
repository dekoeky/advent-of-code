namespace advent_of_code._2016.Day19;

internal static class Calculations
{
    public static int SolvePart1(int n)
    {
        int highestPower = (int)Math.Pow(2, (int)Math.Floor(Math.Log2(n)));
        return 2 * (n - highestPower) + 1;
    }
    public static int SolvePart2(int n)
    {
        int p = (int)Math.Pow(3, (int)Math.Floor(Math.Log(n, 3)));

        if (n == p)
            return n;

        if (n <= 2 * p)
            return n - p;

        return 2 * n - 3 * p;
    }
    public static int Part1(int n)
    {
        var elves = Enumerable.Range(1, n)
            .ToDictionary(e => e, e => 1);

        while (elves.Count > 1)
        {
            for (int i = 0; i < elves.Count; i++)
            {
                var elve = elves.Keys.ElementAt(i);
                var leftElve = elves.Keys.ElementAt((i + 1) % elves.Count);

                var taken = elves[leftElve];
                elves[elve] += taken;

                Debug.WriteLine($"Elf {elve} takes {taken} presents from {leftElve}");
                elves.Remove(leftElve);
                Debug.WriteLine($"Elf {leftElve} is removed from the circle, {elves.Count} remain");
            }
        }

        // Return the only remaining elf
        return elves.Keys.Single();
    }
}
