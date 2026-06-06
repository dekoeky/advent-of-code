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
        var puzzleInput = GameInfo.ParseMany(input);
        var sumOfPowers = 0;

        foreach (var game in puzzleInput)
        {
            var min = RedGreenBlue.Zero;

            foreach (var grab in game.Grabs)
            {
                min.Red = Math.Max(min.Red, grab.Red);
                min.Green = Math.Max(min.Green, grab.Green);
                min.Blue = Math.Max(min.Blue, grab.Blue);
            }

            sumOfPowers += min.GetPower();
        }

        return sumOfPowers;
    }
}