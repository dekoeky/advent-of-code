using advent_of_code.Helpers;

namespace advent_of_code._2017.Day04;

internal static class Calculations
{
    public static int CountValid(string input, Func<string, bool> isValidPredicate)
        => SplitOn.NewLines(input).Count(isValidPredicate);

    public static bool IsValidPart1(string line)
    {
        var words = line.Split(' ');
        return words.Distinct().Count() == words.Length;
    }

    public static bool IsValidPart2(string line)
    {
        var normalized = line
            .Split(' ')
            .Select(w => string.Concat(w.OrderBy(c => c)));

        return normalized.Distinct().Count() == normalized.Count();
    }

}