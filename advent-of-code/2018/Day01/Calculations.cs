namespace advent_of_code._2018.Day01;

internal static class Calculations
{
    public static int ResultingFrequencyCommaSeparated(ReadOnlySpan<char> input)
    {
        var frequency = 0;

        foreach (var range in input.Split(','))
        {
            var offset = int.Parse(input[range]);
            Debug.Write($"Current frequency {frequency}, change of {offset}; ");

            frequency += offset;
            Debug.WriteLine($"resulting frequency  {frequency}.");
        }

        return frequency;
    }

    public static int ResultingFrequencyLineSeparated(ReadOnlySpan<char> input)
    {
        var frequency = 0;

        foreach (var line in input.EnumerateLines())
        {
            var offset = int.Parse(line);
            Debug.Write($"Current frequency {frequency}, change of {offset}; ");

            frequency += offset;
            Debug.WriteLine($"resulting frequency  {frequency}.");
        }

        return frequency;
    }

    public static int FirstDuplicateFrequencyCommaSeparated(ReadOnlySpan<char> input)
    {
        var frequency = 0;
        var visited = new HashSet<int>
           {
               frequency
           };

        while (true)
            foreach (var range in input.Split(','))
            {
                var offset = int.Parse(input[range]);
                Debug.Write($"Current frequency {frequency}, change of {offset}; ");

                frequency += offset;
                Debug.WriteLine($"resulting frequency  {frequency}.");

                if (!visited.Add(frequency))
                {
                    Debug.WriteLine($"Frequency {frequency} visited twice!");
                    return frequency;
                }
            }
    }

    public static int FirstDuplicateFrequencyLineSeparated(ReadOnlySpan<char> input)
    {
        var frequency = 0;
        var visited = new HashSet<int>
           {
               frequency
           };

        while (true)
            foreach (var line in input.EnumerateLines())
            {
                var offset = int.Parse(line);
                Debug.Write($"Current frequency {frequency}, change of {offset}; ");

                frequency += offset;
                Debug.WriteLine($"resulting frequency  {frequency}.");

                if (!visited.Add(frequency))
                {
                    Debug.WriteLine($"Frequency {frequency} visited twice!");
                    return frequency;
                }
            }
    }
}