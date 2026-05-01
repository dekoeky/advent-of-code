namespace AdventOfCode._2016.Day23;

internal static class Calculations
{
    public static int Calculate(int input) => Factorial(input) + 5621;

    private static int Factorial(int n)
    {
        var result = 1;

        for (int i = 2; i <= n; i++)
            result *= i;

        return result;
    }
}