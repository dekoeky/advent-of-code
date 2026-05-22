namespace advent_of_code._2015.Day20;

internal static class Calculations
{
    public static int Part1(int target, int visits)
    {
        int upperBound = target / visits;
        var houses = new int[upperBound + 1];

        for (int elf = 1; elf <= upperBound; elf++)
            for (int house = elf; house <= upperBound; house += elf)
                houses[house] += elf * visits;

        for (int i = 1; i <= upperBound; i++)
            if (houses[i] >= target)
                return i;

        return -1;
    }

    public static int Part2(int target, int visits, int limit)
    {
        int upperBound = target / visits;
        var houses = new int[upperBound + 1];

        for (int elf = 1; elf <= upperBound; elf++)
        {
            int maxHouse = Math.Min(upperBound, elf * limit);

            for (int house = elf; house <= maxHouse; house += elf)
                houses[house] += elf * visits;
        }

        for (int i = 1; i <= upperBound; i++)
            if (houses[i] >= target)
                return i;

        return -1;
    }
}