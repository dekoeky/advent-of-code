namespace advent_of_code._2025.Day03;

public static class Calculations
{
    private static readonly char[] newlineChars = ['\r', '\n'];

    public static int CalculateJoltageSum(string input)
    {
        var lines = input.Split(newlineChars);

        return lines.Select(FindLargestJoltage).Sum();
    }

    public static int FindLargestJoltage(string input)
    {
        var numbers = input.Select(c => c - '0').ToArray();

        var max = (Tens: 0, Ones: 0);

        for (var i = 0; i < numbers.Length; i++)
        {
            var lastValue = i == numbers.Length - 1;

            var value = numbers[i];
            if (value > max.Tens && !lastValue)
                max = (value, 0);
            else if (value > max.Ones)
                max.Ones = value;
        }

        return max.Tens * 10 + max.Ones;
    }
}