namespace advent_of_code._2017.Day01;

internal static class Calculations
{
    public static long Perform(ReadOnlySpan<char> input, int offset)
    {
        int sum = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var j = (i + offset) % input.Length;

            if (input[i] != input[j]) continue;

            sum += input[i] - '0';
        }

        return sum;
    }
}