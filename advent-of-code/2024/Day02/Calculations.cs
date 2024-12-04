namespace advent_of_code._2024.Day02;

internal static class Calculations
{
    public static bool IsSafe(Report report) => IsSafe(report.Levels);
    public static bool IsSafe(IEnumerable<int> report)
    {
        bool? direction = null;
        int? last = null;

        foreach (var level in report)
        {
            //Calculate the difference
            var diff = level - last;

            //Check difference
            if (diff > 3 || diff < -3 || diff == 0)
                return false;

            //Calculate dir
            bool? dir = diff.HasValue ? diff.Value >= 0 : null;

            if (!direction.HasValue)    //Direction was not defined yet
            {
                if (dir.HasValue)
                    direction = dir;        //Define direction
            }
            else                        //Direction was defined --> check if not changed
            {
                //The direction has changed!
                if (direction.Value != dir)
                    return false;
            }

            //Store info for next run
            last = level;
        }

        return true;
    }
}
