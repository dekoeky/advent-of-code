namespace advent_of_code._2023._06;

public readonly record struct Race(ulong TimeLimit, ulong RecordDistance)
{
    public static IEnumerable<Race> Combine(IEnumerable<ulong> times, IEnumerable<ulong> distances)
    {
        using var timesEnumerator = times.GetEnumerator();
        using var distancesEnumerator = distances.GetEnumerator();

        while (true)
        {
            var t = timesEnumerator.MoveNext();
            var d = distancesEnumerator.MoveNext();

            if (!t && !d) yield break;
            if (t != d) throw new InvalidOperationException();
            yield return new Race(timesEnumerator.Current, distancesEnumerator.Current);
        }
    }


    public ulong NumberOfPossibilitiesForWinning()
    {
        ulong possibilities = 0;

        for (ulong pushTime = 1; pushTime < TimeLimit; pushTime++)
        {
            var speed = pushTime;
            var driveTime = TimeLimit - pushTime;
            var distance = driveTime * speed;

            if (distance > RecordDistance) possibilities++;
        }

        return possibilities;
    }
}