namespace advent_of_code._2019.Day16;

internal static class Calculations
{
    private static readonly int[] Pattern = [0, 1, 0, -1];

    public static int Part1(ReadOnlySpan<char> input, int phases = 100)
    {
        // Convert chars to values
        Span<int> values = stackalloc int[input.Length];
        for (var i = 0; i < input.Length; i++)
            values[i] = input[i] - '0';

        for (var phase = 0; phase < phases; phase++)
            FFT(values);

        return First8Digits(values);
    }

    public static int Part2(ReadOnlySpan<char> input, int phases = 100)
    {
        throw new NotImplementedException();
    }

    private static int First8Digits(Span<int> values)
    {
        var result = 0;

        for (var i = 0; i < 8; i++)
            result = result * 10 + values[i];

        return result;
    }

    private static void FFT(Span<int> values)
    {
        var n = values.Length;

        // We need each digit multiple times
        Span<int> newValues = stackalloc int[n];

        for (var digit = 0; digit < n; digit++)
        {
            var pn = digit + 1; // How many times to apply each digit of the pattern
            var value = 0;
            //var first = true;

            // We need to include each digit in the calculation of this digit
            for (var i = 0; i < n; i++)
            {
                var patternIndex = ((i + 1) / pn) % 4; // +1 to account for skipped first element
                var mul = Pattern[patternIndex];
                value += values[i] * mul;

                //if (!first) Debug.Write(" + ");
                //Debug.Write($"{values[i]}*{mul,-2}");
                //first = false;
            }

            //Debug.Write($" = {value,8}");

            // Grab ones digit
            value = value < 0
                ? -value % 10
                : +value % 10;

            //Debug.WriteLine($" => {value,-2}");

            // Store resulting digit
            newValues[digit] = value;
        }

        newValues.CopyTo(values);

        //Debug.WriteLine();
    }
}
