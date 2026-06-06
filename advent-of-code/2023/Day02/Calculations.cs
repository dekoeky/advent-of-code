namespace advent_of_code._2023.Day02;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var puzzleInput = GameInfo.ParseMany(input);
        var sumOfIds = 0;

        var max = new RedGreenBlue { Red = 12, Green = 13, Blue = 14, };


        foreach (var game in puzzleInput)
        {
            var gamePossible = game.Grabs.All(grab => grab.Red <= max.Red && grab.Green <= max.Green && grab.Blue <= max.Blue);

            if (gamePossible)
                sumOfIds += game.Id;
        }

        return sumOfIds;
    }

    public static int Part2(string input)
    {
        throw new NotImplementedException();
    }
}