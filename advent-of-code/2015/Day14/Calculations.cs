using advent_of_code.Helpers;

namespace advent_of_code._2015.Day14;

internal static class Calculations
{
    public static int WinnerByDistanceTraveled(string input, int raceLength)
    {
        var reindeer = SplitOn.NewLines(input).Select(ReindeerInfo.Parse).ToArray();
        Debug.WriteLine($"Reindeer"); foreach (var r in reindeer) Debug.WriteLine($"  {r.Name}: {r.Speed}km/s {r.FlyTime}s/{r.RestTime}s");

        var distancesTraveled = reindeer.ToDictionary(r => r, r => r.DistanceAfter(raceLength));
        var maxDistance = distancesTraveled.Max(d => d.Value);
        Debug.WriteLine($"Distances after {raceLength}s"); foreach (var kv in distancesTraveled) Debug.WriteLine($"  {kv.Key.Name,10}: {kv.Value}km");

        return maxDistance;
    }

    public static int WinnerByPoints(string input, int raceLength)
    {
        var reindeer = SplitOn.NewLines(input).Select(ReindeerInfo.Parse).ToArray();
        Debug.WriteLine($"Reindeer"); foreach (var r in reindeer) Debug.WriteLine($"  {r.Name}: {r.Speed}km/s {r.FlyTime}s/{r.RestTime}s");

        var points = reindeer.ToDictionary(r => r, _ => 0);

        for (int i = 1; i < raceLength; i++)
        {
            var distancesTraveled = reindeer.ToDictionary(r => r, r => r.DistanceAfter(i));
            var maxDistance = distancesTraveled.Max(d => d.Value);
            var reindeersInTheLead = distancesTraveled.Where(kv => kv.Value == maxDistance).Select(kv => kv.Key);

            Debug.WriteLine($"After {i} seconds:");
            foreach (var leader in reindeersInTheLead)
            {
                // This reindeer gets a point for being in the lead
                points[leader]++;
                Debug.WriteLine($"  {leader.Name}: +1 point = {points[leader]}");
            }
            Debug.WriteLine("");
        }

        return points.Max(kv => kv.Value);
    }
}
