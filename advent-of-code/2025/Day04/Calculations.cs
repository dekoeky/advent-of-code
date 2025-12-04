using System.Diagnostics;

namespace advent_of_code._2025.Day04;

public static class Calculations
{
    public static int RollsAccessibleByForklift(string input, bool remove)
    {
        var data = input.To2DArray();

        var count = 0;
        var removed = 0;

        do
        {
            removed = 0;

            for (var r = 0; r < data.GetLength(0); r++)
                for (var c = 0; c < data.GetLength(1); c++)
                    if (data[r, c] == '@' && data.HaxMaxNAdjacentRollsOfPaper(r, c, 4))
                    {
                        count++;

                        if (!remove) continue;

                        removed++;
                        data[r, c] = 'x';
                    }
                    else if (data[r, c] == 'x')
                        data[r, c] = '.';

            Print(data);
        } while (removed > 0);

        return count;
    }

    private static void Print(char[,] data)
    {
        for (var r = 0; r < data.GetLength(0); r++)
        {
            for (var c = 0; c < data.GetLength(1); c++)
                Debug.Write(data[r, c]);
            Debug.WriteLine("");
        }
        Debug.WriteLine("");
    }
}