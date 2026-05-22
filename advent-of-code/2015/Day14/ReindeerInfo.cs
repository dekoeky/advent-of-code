using System.Text.RegularExpressions;

namespace advent_of_code._2015.Day14;

internal partial record ReindeerInfo(string Name, int Speed, int FlyTime, int RestTime)
{
    [GeneratedRegex("^([A-Za-z]+) can fly (\\d+) km/s for (\\d+) seconds, but then must rest for (\\d+) seconds\\.$")]
    private static partial Regex GetRegex();
    private static readonly Regex Regex = GetRegex();

    public static ReindeerInfo Parse(string input)
    {
        var m = Regex.Match(input);

        var name = m.Groups[1].Value;
        var speed = int.Parse(m.Groups[2].Value);
        var flyTime = int.Parse(m.Groups[3].Value);
        var restTime = int.Parse(m.Groups[4].Value);

        return new ReindeerInfo(name, speed, flyTime, restTime);
    }

    int CycleTime { get; } = FlyTime + RestTime;
    int DistancePerFlight { get; } = Speed * FlyTime;

    public int DistanceAfter(int time)
    {
        int timeFlown;

        // Calculate number of full cycles
        var fullCycles = time / CycleTime;
        var remainingTime = time - fullCycles * CycleTime;

        timeFlown = remainingTime >= FlyTime
            // Remaining time >FlyTime but <CycleTime:
            ? (fullCycles + 1) * FlyTime
            : fullCycles * FlyTime + remainingTime;

        return timeFlown * Speed;
    }
}