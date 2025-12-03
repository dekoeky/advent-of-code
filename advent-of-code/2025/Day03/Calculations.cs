using System.Diagnostics;

namespace advent_of_code._2025.Day03;

public static class Calculations
{
    private static readonly char[] newlineChars = ['\r', '\n'];

    public static int CalculateJoltageSum(string input)
    {
        var lines = input.Split(newlineChars, StringSplitOptions.RemoveEmptyEntries);

        return lines.Select(FindLargestJoltage).Sum();
    }

    public static long CalculateJoltageSum2(string input, int numberOfBatteries)
    {
        var lines = input.Split(newlineChars, StringSplitOptions.RemoveEmptyEntries);

        return lines.Select(l => FindLargestJoltage2(l, numberOfBatteries)).Sum();
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


    public static long FindLargestJoltage2(string input, int numberOfBatteries)
    {
        if (input.Length < numberOfBatteries) throw new InvalidOperationException();
        if (input.Length == numberOfBatteries) return int.Parse(input);

        // 00 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19      = 20 
        var numbers = input.Select(c => c - '0').ToArray();


        var max = new int[numberOfBatteries]; // all zeros
        var maxIndex = Enumerable.Repeat(-1, numberOfBatteries).ToArray();

        // Loop each values in the input
        for (var i = 0; i < numbers.Length; i++)
        {
            var value = numbers[i];

            //Calculate how many (least-significant) digits we can still update
            var valuesRemaining = Math.Min(numberOfBatteries, numbers.Length - i);

            for (var j = max.Length - valuesRemaining; j < max.Length; j++) // Loop each digit that can still be updated (and still have enough remaining digits to fill in the less-significant digits
                if (value > max[j])
                {
                    max[j] = value;
                    maxIndex[j] = i;

                    // For now fill in zeros for all less-significant digits
                    // Next runs will fill in the correct values
                    for (var x = j + 1; x < max.Length; x++)
                        max[x] = 0;

                    break;
                }

        }



        long total = 0;
        var power = (long)Math.Pow(10, numberOfBatteries - 1);
        foreach (var value in max)
        {
            total += value * power;
            power /= 10;
        }

        Debug.WriteLine($"Input: {input}");
        Debug.WriteLine($"Max: {total}");

        return total;
    }
}