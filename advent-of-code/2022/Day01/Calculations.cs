namespace advent_of_code._2022.Day01;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var inputPerElf = SplitOn.EmptyLines(input);
        var snacksPerElf = inputPerElf.Select(i => SplitOn.NewLines(i).Select(int.Parse).ToArray()).ToArray();

        var mostCalories = snacksPerElf.Max(snacks => snacks.Sum());

        return mostCalories;
    }

    public static int Part2(string input)
    {
        var inputPerElf = SplitOn.EmptyLines(input);
        var snacksPerElf = inputPerElf.Select(i => SplitOn.NewLines(i).Select(int.Parse).ToArray()).ToArray();

        var top3 = snacksPerElf.Select(snacks => snacks.Sum()).OrderByDescending(sum => sum).Take(3);
        return top3.Sum();
    }
}