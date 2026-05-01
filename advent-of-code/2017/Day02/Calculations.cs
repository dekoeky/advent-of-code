namespace AdventOfCode._2017.Day02;

internal static class Calculations
{
    private static readonly char[] Separators = ['\t', ' '];

    public static int Checksum1(string input)
    {
        var checksum = 0;

        foreach (var line in input.EnumerateLines())
        {
            var min = int.MaxValue;
            var max = int.MinValue;

            foreach (var range in line.SplitAny(' ', '\t'))
            {
                var value = int.Parse(line[range]);

                if (value > max) max = value;
                if (value < min) min = value;
            }

            // the difference for this line
            var diff = max - min;

            // add this line difference to the checksum
            checksum += diff;
        }

        return checksum;
    }

    public static int Checksum2(string input)
    {
        var checksum = 0;
        Span<int> values = stackalloc int[20]; // Large enough for our example

        foreach (var line in input.EnumerateLines())
        {
            var i = 0;

            foreach (var range in line.SplitAny(' ', '\t'))
            {
                // Store value
                values[i] = int.Parse(line[range]);

                // Test this value against all previous ones
                var valuesToTestAgainst = values.Slice(0, i);

                // If none of the previous values is dividible by the last value (or vice versa) we keep processing values
                if (!ContainsEvenDivision(valuesToTestAgainst, values[i], out var result))
                {
                    i++;
                    continue;
                }
                // We found the solution for this line
                // Add the result (the divide result) to the checksum
                checksum += result;

                // No need to check the other values on this line, there is only one set of divisible values each row
                break;
            }
        }

        return checksum;

        static bool ContainsEvenDivision(ReadOnlySpan<int> values, int a, out int result)
        {
            foreach (var b in values)
                if (b > a && b % a == 0)
                {
                    result = b / a;
                    return true;
                }
                else if (b < a && a % b == 0)
                {
                    result = a / b;
                    return true;
                }
                else if (a == b)
                {
                    result = 1;
                    return true;
                }

            // No result found
            result = 0;
            return false;
        }
    }
}