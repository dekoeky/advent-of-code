namespace advent_of_code._2023.Day07;

internal static class Calculations
{
    internal const string StrengthsPart1 = "23456789TJQKA";
    internal const string StrengthsPart2 = "J23456789TQKA";

    public static int Part1(ReadOnlySpan<char> input)
        => Execute(input, new ResultSorter(StrengthsPart1), new ResultEvaluator.Part1());

    public static int Part2(ReadOnlySpan<char> input)
        => Execute(input, new ResultSorter(StrengthsPart2), new ResultEvaluator.Part2());

    private static int Execute(ReadOnlySpan<char> input, ResultSorter sorter, ResultEvaluator resultFinder)
    {
        var puzzleInput = Parse(input);
        var withResults = EvaluateResults(puzzleInput, resultFinder);
        withResults.Sort(sorter);

        return Sum(withResults);
    }

    private static List<(string Cards, int Bid)> Parse(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var result = new List<(string Cards, int Bid)>(n);

        foreach (var line in input.EnumerateLines())
        {
            var space = line.IndexOf(' ');

            result.Add((line[..space].ToString(), int.Parse(line[++space..])));
        }

        return result;
    }

    private static List<(string Cards, int Bid, Result Result)> EvaluateResults(List<(string Cards, int Bid)> original, ResultEvaluator resultFinder)
    {
        var results = new List<(string Cards, int Bid, Result Result)>(original.Count);

        foreach (var (cards, bid) in original)
            results.Add((cards, bid, resultFinder.Find(cards)));

        return results;
    }


    private static int Sum(List<(string Cards, int Bid, Result Result)> withResults)
    {
        var sum = 0;

        for (var i = 0; i < withResults.Count; i++)
        {
            var rank = i + 1;
            var (cards, bid, result) = withResults[i];

            Debug.WriteLine($"{cards} => Result: {result} -> Rank: {rank} -> Bid {bid}");
            sum += rank * bid;
        }

        return sum;
    }
}
