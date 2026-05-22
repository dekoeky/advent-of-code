namespace advent_of_code._2020.Day01;

internal static class Calculations
{
    public static int Part1(int[] input, int sum)
    {
        for (int i = 0; i < input.Length - 1; i++)
            for (int j = i + 1; j < input.Length; j++)
            {
                var a = input[i];
                var b = input[j];

                if (a + b != sum) continue;

                return a * b;
            }


        return -1;
    }

    public static int Part2(int[] input, int sum)
    {
        for (int i = 0; i < input.Length - 2; i++)
            for (int j = i + 1; j < input.Length - 1; j++)
                for (int k = j + 1; k < input.Length; k++)
                {
                    var a = input[i];
                    var b = input[j];
                    var c = input[k];

                    if (a + b + c != sum) continue;

                    return a * b * c;
                }

        return -1;
    }
}