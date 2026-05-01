namespace AdventOfCode._2017.Day17;

internal static class Calculations
{
    public static int Part1(int steps, int n)
    {
        var values = new List<int>(capacity: n + 1)
        {
            0
        };
        var l = 1;
        var index = 0;

        for (var i = 1; i <= n; i++) // loop 1 2 ... n-1 n
        {
            // step forward 'steps' times
            index = (index + steps) % l;

            // insert value in next index
            values.Insert(++index, i);
            l++;
        }

        return values[(index + 1) % l];
    }

    public static int Part2(int steps, int n)
    {
        // Value 0 (at position 0) is never inserted or overwritten, so its always at index 0
        // Therefore we only need to track the value at index 1

        var l = 1;
        var index = 0;
        var value = 0;

        for (var i = 1; i <= n; i++) // loop 1 2 ... n-1 n
        {
            // step forward 'steps' times
            index = (index + steps) % l;

            // keep track of value, if the insert index is 1
            if (++index == 1)
                value = i;
            l++;
        }

        return value;
    }
}
