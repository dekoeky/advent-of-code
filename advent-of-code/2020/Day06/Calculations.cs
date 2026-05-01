namespace AdventOfCode._2020.Day06;

internal static partial class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var sum = 0;
        HashSet<char> hs = [];

        foreach (var line in input.EnumerateLines())
        {
            if (line.IsEmpty)
            {
                sum += hs.Count;
                hs.Clear();
                continue;
            }

            foreach (var c in line)
                _ = hs.Add(c);
        }

        sum += hs.Count;

        return sum;
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        var peopleInGroup = 0;
        var sum = 0;

        HashSet<char> hs = [];
        Dictionary<char, int> d = [];

        foreach (var line in input.EnumerateLines())
        {
            if (line.IsEmpty)
            {
                sum += d.Count(kv => kv.Value == peopleInGroup);
                d.Clear();

                peopleInGroup = 0;
                continue;
            }

            // Find distinct letters on this line
            hs.Clear();
            foreach (var c in line)
                hs.Add(c);

            // +1 for each distinct letter
            foreach (var c in hs)
                d[c] = d.GetValueOrDefault(c) + 1;

            peopleInGroup++;
        }

        sum += d.Count(kv => kv.Value == peopleInGroup);

        return sum;
    }
}