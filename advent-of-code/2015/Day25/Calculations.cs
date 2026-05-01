namespace AdventOfCode._2015.Day25;

public static class Calculations
{
    public static long Solve(int row, int col)
    {
        long start = 20151125;
        long mul = 252533;
        long mod = 33554393;

        // Bepaal de diagonale index
        long diagonal = row + col - 1;

        // Bepaal hoeveel stappen vanaf (1,1)
        long stepsBeforeDiagonal = (diagonal - 1) * diagonal / 2;
        long index = stepsBeforeDiagonal + col - 1;

        long value = start;

        for (long i = 0; i < index; i++)
        {
            value = (value * mul) % mod;
        }

        return value;
    }
}
