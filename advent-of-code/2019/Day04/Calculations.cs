namespace advent_of_code._2019.Day04;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var (min, max) = Parse(input);

        return Count(min, max, IsValid);
    }

    public static int Part2(string input)
    {
        var (min, max) = Parse(input);

        return Count(min, max, IsValid2);
    }

    private static (int Min, int Max) Parse(string input)
    {
        var parts = input.Split('-');

        return (int.Parse(parts[0]), int.Parse(parts[1]));
    }

    private static int Count(int min, int max, Func<int, bool> isValid)
    {
        var count = 0;

        for (var value = min; value <= max; value++)
            if (isValid(value))
                count++;

        return count;
    }

    public static bool IsValid(int value)
    {
        // 6 digits check
        if (value is < 100000 or > 999999) return false;

        var adjacentDigits = false;
        var lastDigit = int.MaxValue;

        while (value > 0)
        {
            // Grab lowest digit (least significant)
            var digit = value % 10;
            value /= 10;

            // Going from left to right, the digits should never decrease;
            if (digit > lastDigit)
                return false;

            // Two adjacent digits are the same 
            if (digit == lastDigit) adjacentDigits = true;

            lastDigit = digit;
        }

        return adjacentDigits;
    }

    public static bool IsValid2(int value)
    {
        // 6 digits check
        if (value < 100000 || value > 999999) return false;

        var lastDigit = int.MaxValue;
        var adjacentSatisfied = false;
        var adjacent = 0;

        while (value > 0)
        {
            var digit = value % 10;
            value /= 10;

            // Going from left to right, the digits should never decrease;
            if (digit > lastDigit)
                return false;

            // Only check if adjacent, if not yet satisfied
            if (!adjacentSatisfied)
                // If the digit is the same as the last one,
                // our streak of adjacent same characters goes up.
                // We can't (yet) say this satisfies our requirement, 
                // as we need to check if the next digit is a different one (or is last digit)
                if (digit == lastDigit)
                {
                    adjacent++;
                }

                // If the new digit, is different from the last
                // That means our streak of same digits has stopped
                else
                {
                    // If adjacent == 1 that means we had exactly 2 adjacent same digits
                    // Which satisfies our requirement
                    if (adjacent == 1) adjacentSatisfied = true;

                    // Also this ends our streak of adjacent same digits
                    adjacent = 0;
                }


            lastDigit = digit;
        }

        return adjacentSatisfied || adjacent == 1;
    }
}