using System.Text.RegularExpressions;

namespace advent_of_code._2024.Day03;

internal static class Calculations
{
    public static int SumOfMultiplications(string input, bool useEnabling)
    {
        int count = 0;
        const string pattern = @"mul\((?<num1>\d{1,3}),(?<num2>\d{1,3})\)|(?<do>do)\(\)|(?<dont>don\'t)\(\)";

        var enabled = true;

        // Create a Regex object
        var regex = new Regex(pattern);
        var matches = regex.Matches(input);
        foreach (Match match in matches)
            if (match.Groups["num1"].Success && match.Groups["num2"].Success)
            {
                if (!enabled) continue;

                // Extract num1 and num2 from the named groups

                var num1 = int.Parse(match.Groups["num1"].ValueSpan);
                var num2 = int.Parse(match.Groups["num2"].ValueSpan);

                var mul = num1 * num2;

                count += mul;
            }
            // Check if it's a "do()" match
            else if (match.Groups["do"].Success)
            {
                enabled = true;
            }
            // Check if it's a "don't()" match
            else if (match.Groups["dont"].Success)
            {
                if (useEnabling) enabled = false;
            }

        return count;
    }
}
