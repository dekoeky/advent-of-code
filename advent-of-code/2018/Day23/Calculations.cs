namespace advent_of_code._2018.Day23;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var bots = NanoBot.ParseMany(input);
        var maxRadiusBot = bots.MaxBy(b => b.Radius);
        var inRange = 0;

        foreach (var bot in bots)
        {
            var distance = maxRadiusBot.ManhattanDistance(bot);
            if (distance <= maxRadiusBot.Radius)
                inRange++;
        }

        return inRange;
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        var bots = NanoBot.ParseMany(input);

        // Make it a 1D problem
        // We don't care about the point, we care about the distance
        // Each step in either direction (x+, x-, y+, y-, z+, z-) will (for each bot) either increase or decrease the distance 
        var origin = new Position(0, 0, 0);
        var intervals = new (int Start, int End)[bots.Length];
        var stops = new HashSet<int>();

        for (var i = 0; i < bots.Length; i++)
        {
            var bot = bots[i];
            var distance = bot.ManhattanDistance(origin);
            var start = distance - bot.Radius;
            var end = distance + bot.Radius;
            intervals[i] = (start, end);
            stops.Add(start);
            stops.Add(end);
        }

        var maxCount = -1;
        var bestDistance = int.MaxValue;

        foreach (var distance in stops)
        {
            var inRange = intervals.Count(i => i.Start <= distance && distance <= i.End);

            if (inRange > maxCount)
            {
                maxCount = inRange;
                bestDistance = distance;
            }
            else if (inRange == maxCount)
            {
                bestDistance = Math.Min(bestDistance, distance);
            }
        }

        return bestDistance;
    }
}

