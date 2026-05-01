using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode._2022.Day02;

internal static class Calculations
{
    public static int Part1(string input)
        => Run(input, e => e.GivenResponse);

    public static int Part2(string input)
        => Run(input, e => Choose(e.Opponent, e.GivenResult));

    private static int Run(string input, Func<StrategyGuideEntry, Hand> selectHand)
    {
        var strategyGuide = StrategyGuideEntry.ParseMany(input);
        var yourScore = 0;

        foreach (var round in strategyGuide)
        {
            var yourHand = selectHand(round);
            var result = Play(you: yourHand, opponent: round.Opponent);

            // The score for a single round is the score for the shape you selected
            // (1 for Rock, 2 for Paper, and 3 for Scissors)
            // plus the score for the outcome of the round
            // (0 if you lost, 3 if the round was a draw, and 6 if you won)
            var roundScore = HandScore(yourHand) + ResultScore(result);
            yourScore += roundScore;

            Debug.WriteLine($"O: {round.Opponent,8} vs Y: {round.GivenResponse,8} => {result,4} +{roundScore} = {yourScore}");
        }

        return yourScore;
    }

    private static Hand Choose(Hand opponent, Result givenResult)
        => givenResult switch
        {
            // To result in a draw we need the same hand as the opponent
            Result.Draw => opponent,

            Result.Win => opponent switch
            {
                Hand.Scissors => Hand.Rock,
                Hand.Rock => Hand.Paper,
                Hand.Paper => Hand.Scissors,
                _ => throw new NotImplementedException(),
            },

            Result.Loss => opponent switch
            {
                Hand.Scissors => Hand.Paper,
                Hand.Rock => Hand.Scissors,
                Hand.Paper => Hand.Rock,
                _ => throw new NotImplementedException(),
            },

            _ => throw new NotImplementedException()
        };

    [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Readability")]
    private static Result Play(Hand you, Hand opponent)
    {
        // If both players choose the same shape, the round instead ends in a draw
        if (opponent == you) return Result.Draw;

        // Rock defeats Scissors
        if (you == Hand.Rock && opponent == Hand.Scissors) return Result.Win;

        // Scissors defeats Paper
        if (you == Hand.Scissors && opponent == Hand.Paper) return Result.Win;

        // Paper defeats Rock. 
        if (you == Hand.Paper && opponent == Hand.Rock) return Result.Win;

        return Result.Loss;
    }

    private static int HandScore(Hand hand) => hand switch
    {
        Hand.Rock => 1,
        Hand.Paper => 2,
        Hand.Scissors => 3,
        _ => throw new NotImplementedException(),
    };

    private static int ResultScore(Result result) => result switch
    {
        Result.Loss => 0,
        Result.Draw => 3,
        Result.Win => 6,
        _ => throw new NotImplementedException(),
    };
}
