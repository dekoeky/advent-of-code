using advent_of_code.Helpers;

namespace advent_of_code._2021.Day03;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var rows = 0;
        var cols = 0;
        var c = 0;
        var ones = new int[100];

        foreach (var line in input.EnumerateLines())
        {
            rows++;
            cols = Math.Max(cols, line.Length);

            for (c = 0; c < line.Length; c++)
                if (line[c] == '1')
                    ones[c]++;
        }

        var gammaRate = 0;
        var epsilonRate = 0;

        for (c = 0; c < cols; c++)
        {
            gammaRate <<= 1;
            epsilonRate <<= 1;

            if (ones[c] > rows - ones[c])
                gammaRate += 1;
            else
                epsilonRate += 1;
        }

        Debug.WriteLine($"Ones: {string.Join(',', ones)}");
        Debug.WriteLine($"Gamma   Rate: {gammaRate,5} {gammaRate:b}");
        Debug.WriteLine($"Epsilon Rate: {epsilonRate,5} {epsilonRate:b}");

        return gammaRate * epsilonRate;
    }

    public static int Part2(string input)
    {
        var lines = SplitOn.NewLines(input);
        var oxygenGeneratorRating = ToInt(MostCommon([.. lines]));
        var co2ScrubberRating = ToInt(LeastCommon([.. lines]));

        return oxygenGeneratorRating * co2ScrubberRating;
    }

    private static string MostCommon(List<string> lines)
    {
        var l = lines.First().Length;

        for (var c = 0; c < l; c++)
        {
            var ones = lines.Count(line => line[c] == '1');
            var zeros = lines.Count(line => line[c] == '0');

            if (ones >= zeros)
                lines.RemoveAll(line => line[c] == '0');
            else
                lines.RemoveAll(line => line[c] == '1');

            if (lines.Count == 1) break;
        }

        return lines.Single();
    }
    private static string LeastCommon(List<string> lines)
    {
        var l = lines.First().Length;

        for (var c = 0; c < l; c++)
        {
            var ones = lines.Count(line => line[c] == '1');
            var zeros = lines.Count(line => line[c] == '0');

            if (ones >= zeros)
                lines.RemoveAll(line => line[c] == '1');
            else
                lines.RemoveAll(line => line[c] == '0');

            if (lines.Count == 1) break;
        }

        return lines.Single();
    }

    private static int ToInt(string line)
    {
        var result = 0;

        for (var c = 0; c < line.Length; c++)
        {
            result <<= 1;
            if (line[c] == '1')
                result += 1;
        }

        return result;
    }
}