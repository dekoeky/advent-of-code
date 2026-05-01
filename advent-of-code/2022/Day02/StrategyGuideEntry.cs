namespace AdventOfCode._2022.Day02;

internal readonly record struct StrategyGuideEntry(Hand Opponent, Hand GivenResponse, Result GivenResult)
{
    public static StrategyGuideEntry Parse(ReadOnlySpan<char> input)
    {
        // Input is always 3 digits
        // OPPONENT SPACE RESPONSE

        var opponent = input[0] switch
        {
            'A' => Hand.Rock,
            'B' => Hand.Paper,
            'C' => Hand.Scissors,
            _ => throw new NotImplementedException(),
        };

        var givenResponse = input[2] switch
        {
            'X' => Hand.Rock,
            'Y' => Hand.Paper,
            'Z' => Hand.Scissors,
            _ => throw new NotImplementedException(),
        };
        var givenResult = input[2] switch
        {
            'X' => Result.Loss,
            'Y' => Result.Draw,
            'Z' => Result.Win,
            _ => throw new NotImplementedException(),
        };

        return new StrategyGuideEntry(opponent, givenResponse, givenResult);
    }

    public static StrategyGuideEntry[] ParseMany(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;

        var strategyGuide = new StrategyGuideEntry[n];

        var i = 0;

        foreach (var line in input.EnumerateLines())
            strategyGuide[i++] = Parse(line);

        return strategyGuide;
    }
}