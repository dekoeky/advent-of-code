namespace AdventOfCode._2018.Day04;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var minutesAsleep = Analyze(input);
        var sleptMost = minutesAsleep.MaxBy(kv => kv.Value.Values.Sum());
        var guardThatSleptMost = sleptMost.Key;
        var minuteMostAsleep = sleptMost.Value.MaxBy(kv => kv.Value).Key;

        return guardThatSleptMost * minuteMostAsleep;
    }

    public static int Part2(string input)
    {
        var minutesAsleep = Analyze(input);

        var winningGuard = -1;
        var winningMinute = -1;
        var winninCount = -1;

        foreach (var (g, minutes) in minutesAsleep)
        {
            for (var m = 0; m < 60; m++)
            {
                var cnt = minutes[m];

                // Only store a new best result, if the amount of minutes slept, is more than the best
                if (cnt <= winninCount)
                    continue;

                winninCount = cnt;
                winningGuard = g;
                winningMinute = m;
            }
        }

        return winningGuard * winningMinute;
    }

    private static Dictionary<int, Dictionary<int, int>> Analyze(string input)
    {
        var events = Event.ParseMany(input);
        var t = events.First().TimeStamp;
        var guardOnDutyId = -1;
        var asleep = false;

        // Per Guard: Times asleep, per minute
        Dictionary<int, Dictionary<int, int>> minutesAsleep = [];

        // Process events chronologically
        foreach (var e in events.OrderBy(e => e.TimeStamp))
        {
            // If a guard is on duty, and he is asleep:
            // We can calculate how many more minutes he had slept up until now
            if (asleep && guardOnDutyId != -1)
            {
                var timeSinceLastEvent = e.TimeStamp - t;

                // Just to be safe...
                if (timeSinceLastEvent < TimeSpan.Zero) throw new InvalidOperationException("Events are not chronological");
                if (timeSinceLastEvent == TimeSpan.Zero) throw new InvalidOperationException("Events have colliding timestamps");

                // We assume no seconds are used, so totalminutes should always be a >0 integer value
                var minutesSinceLastEvent = (int)timeSinceLastEvent.TotalMinutes;

                // If we did not yet record any minutes asleep for this guard,
                // add a dictionary where we can store how many times this guard was asleep on each minute (0-59)
                if (!minutesAsleep.TryGetValue(guardOnDutyId, out var timesAsleepPerMinute))
                {
                    timesAsleepPerMinute = Enumerable.Range(0, 60)
                        .ToDictionary(minute => minute, _ => 0);

                    // Store for later use
                    minutesAsleep.Add(guardOnDutyId, timesAsleepPerMinute);
                }

                // If the guard is asleep for more than N hours,
                // Mark N times asleep for each minute (0-59)
                var fullHours = minutesSinceLastEvent / 60;

                // Ignoring full hours asleep, how many minutes has the guard slept
                var remainingMinutes = minutesSinceLastEvent % 60;

                // For each minute, since the start of the last event
                for (var minutesSinceStartOfSleepPeriod = 0; minutesSinceStartOfSleepPeriod < 60; minutesSinceStartOfSleepPeriod++)
                {
                    var actualMinute = (t.Minute + minutesSinceStartOfSleepPeriod) % 60;

                    // Example:
                    // minutesSinceLastEvent = 75
                    // remainingMinutes      = 15
                    // Minutes  0 trough 14 get +2 (1 from the 60 minutes, 1 from the 15)
                    // Minutes 15 trough 59 get +1 (  from the 60 minutes)
                    var minutesToAdd = minutesSinceStartOfSleepPeriod < remainingMinutes
                        ? fullHours + 1
                        : fullHours + 0;

                    // Store the added minutes marked asleep
                    timesAsleepPerMinute[actualMinute] += minutesToAdd;
                }
            }

            switch (e)
            {
                case EventBeginShift shiftBegin:
                    guardOnDutyId = shiftBegin.GuardId;
                    asleep = false;
                    break;

                case EventFallAsleep fallsAsleep:
                    asleep = true;
                    break;

                case EventWakeUp wakesUp:
                    asleep = false;
                    break;

                default:
                    throw new NotImplementedException();
            }

            t = e.TimeStamp;
        }

        return minutesAsleep;
    }
}
