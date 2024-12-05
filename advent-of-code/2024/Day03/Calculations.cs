using System.Text.RegularExpressions;

namespace advent_of_code._2024.Day03;

internal static class Calculations
{
    public static int SumOfMultiplications(string input)
    {
        int count = 0;
        const string pattern = @"mul\((?<num1>\d{1,3}),(?<num2>\d{1,3})\)";

        // Create a Regex object
        var regex = new Regex(pattern);

        foreach (Match match in regex.Matches(input))
        {
            var num1 = int.Parse(match.Groups["num1"].ValueSpan);
            var num2 = int.Parse(match.Groups["num2"].ValueSpan);

            var mul = num1 * num2;

            count += mul;
        }

        return count;
    }
}
