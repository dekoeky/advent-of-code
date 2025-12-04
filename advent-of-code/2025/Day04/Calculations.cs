namespace advent_of_code._2025.Day04;

public static class Calculations
{
    public static int RollsAccessibleByForklift(string input)
    {
        var data = input.To2DArray();

        var count = 0;

        for (var r = 0; r < data.GetLength(0); r++)
            for (var c = 0; c < data.GetLength(1); c++)
                if (data[r, c] == '@' && data.HaxMaxNAdjacentRollsOfPaper(r, c, 4))
                {
                    count++;
                }

        return count;
    }
}