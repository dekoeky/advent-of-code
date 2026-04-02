namespace advent_of_code._2023.Day01;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var sum = 0;

        foreach (var line in input.EnumerateLines())
        {
            var calibrationValue = 10 * GetFirstDigitV1(line) + GetLastDigitV1(line);
            sum += calibrationValue;

            Debug.WriteLine($"{calibrationValue} ({line})");
        }

        Debug.WriteLine("-------------------  +");
        Debug.WriteLine($"{sum}");
        return sum;
    }

    static int GetFirstDigitV1(ReadOnlySpan<char> line)
    {
        for (var i = 0; i < line.Length; i++)
            if (char.IsNumber(line[i]))
                return line[i] - '0';

        throw new InvalidDataException();
    }

    static int GetLastDigitV1(ReadOnlySpan<char> line)
    {
        for (var i = line.Length - 1; i >= 0; i--)
            if (char.IsNumber(line[i]))
                return line[i] - '0';

        throw new InvalidDataException();
    }

    private static readonly string[] WrittenDigits = [
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine"
        ];

    public static int Part2(ReadOnlySpan<char> input)
    {
        var sum = 0;

        foreach (var line in input.EnumerateLines())
        {
            var calibrationValue = 10 * GetFirstDigitV2(line) + GetLastDigitV2(line);
            sum += calibrationValue;

            Debug.WriteLine($"{calibrationValue} ({line})");
        }

        Debug.WriteLine("-------------------  +");
        Debug.WriteLine($"{sum}");
        return sum;
    }

    static int GetFirstDigitV2(ReadOnlySpan<char> inp)
    {
        for (var i = 0; i < inp.Length; i++)
        {
            if (char.IsNumber(inp[i]))
                return inp[i] - '0';

            var current = inp[i..];

            for (int j = 0; j < WrittenDigits.Length; j++)
                if (current.StartsWith(WrittenDigits[j]))
                    return j + 1;
        }
        throw new InvalidDataException();
    }

    static int GetLastDigitV2(ReadOnlySpan<char> inp)
    {
        for (var i = inp.Length - 1; i >= 0; i--)
        {
            if (char.IsNumber(inp[i]))
                return inp[i] - '0';

            var current = inp[..(i + 1)];

            for (int j = 0; j < WrittenDigits.Length; j++)
                if (current.EndsWith(WrittenDigits[j]))
                    return j + 1;
        }
        throw new InvalidDataException();
    }
}
