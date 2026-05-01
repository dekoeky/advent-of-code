namespace AdventOfCode._2016.Day15;

internal static class Calculations
{
    public static int FindEarliestStartTime(IReadOnlyCollection<DiskInput> disks)
    {
        for (var t = 0; t < int.MaxValue; t++)
            for (var d = 0; d < disks.Count; d++)
            {
                var disk = disks.ElementAt(d);
                var timeAtDisk = t + 1 + d;

                if ((disk.PositionAtT0 + timeAtDisk) % disk.Positions != 0)
                    break;

                // solution found!
                if (d == disks.Count - 1)
                    return t;
            }

        throw new InvalidOperationException();
    }
}