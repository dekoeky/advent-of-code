namespace AdventOfCode._2016.Day11;

internal record State(int Elevator, int[] Generators, int[] Chips)
{
    public bool IsGoalAchieved => Generators.All(floor => floor == 3) && Chips.All(floor => floor == 3);

    public State Canonical()
    {
        var pairs = Generators.Zip(Chips, (g, c) => (g, c)).OrderBy(p => p.g).ThenBy(p => p.c).ToArray();
        return new State(Elevator, [.. pairs.Select(p => p.g)], [.. pairs.Select(p => p.c)]);
    }
}
