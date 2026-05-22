using System.Text;

namespace advent_of_code._2015.Day10;

internal static class Calculations
{
    public static string Expand(string input, int n)
    {
        for (int i = 0; i < n; i++)
            input = PerformExpand(input);

        return input;
    }

    private static string PerformExpand(string input)
    {
        var sb = new StringBuilder();

        int count = 0;
        char lastC = default;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == lastC)
            {
                count++;
            }
            else
            {
                if (lastC != default)
                    sb.Append(count).Append(lastC);

                count = 1;
                lastC = input[i];
            }
        }

        if (count > 0)
            sb.Append(count).Append(lastC);

        return sb.ToString();
    }
}
