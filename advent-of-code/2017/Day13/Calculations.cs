namespace advent_of_code._2017.Day13;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var layers = Layer.ParseMany(input).ToArray();
        var severity = 0;

        foreach (var layer in layers)
            // If (depth % period) == 0 → caught
            if (layer.Depth % layer.Period == 0)
                severity += layer.Depth * layer.Range;

        return severity;
    }

    public static int Part2(string input)
    {
        var layers = Layer.ParseMany(input);
        var delay = 0;

        while (true)
        {
            var detected = false;

            foreach (var layer in layers)
                // If (depth + delay) % period == 0 → detected
                if (((layer.Depth + delay) % layer.Period) == 0)
                {
                    detected = true;
                    break;
                }

            if (!detected)
                return delay;

            delay++;
        }
    }
}
