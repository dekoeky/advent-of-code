namespace advent_of_code._2020.Day13;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var earliest = CutAwayEarliestPart(ref input);
        (int Id, int WaitTime) best = (-1, int.MaxValue);

        while (TryGrabId(ref input, out var id))
        {
            if (earliest % id == 0) return 0; // What a luck, we don't need to wait, we can emmediately take this bus

            var next = ((earliest / id) + 1) * id;
            var wait = next - earliest;

            if (wait >= best.WaitTime) continue;

            best = (id, wait);
        }

        return best.WaitTime * best.Id;
    }

    private static int CutAwayEarliestPart(ref ReadOnlySpan<char> input)
    {
        var lines = input.EnumerateLines();

        lines.MoveNext();
        var earliest = int.Parse(lines.Current);

        lines.MoveNext();
        input = lines.Current;

        return earliest;
    }

    private static bool TryGrabId(ref ReadOnlySpan<char> input, out int id)
    {
        while (!input.IsEmpty)
        {
            var idx = input.IndexOf(',');
            ReadOnlySpan<char> idPart;

            if (idx == -1)
            {
                idPart = input;
                input = input[input.Length..];
            }
            else
            {
                idPart = input[..idx];
                input = input[(idx + 1)..];
            }
            // Ignore x
            if (idPart.Length == 1 && idPart[0] == 'x') continue;
            id = int.Parse(idPart);
            return true;
        }

        id = 0;
        return false;


    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        // Find the newline separating earliest timestamp and bus list
        int nl = input.IndexOf('\n');
        var buses = input[(nl + 1)..];
        return Part2Internal(buses);
    }

    public static long Part2Internal(ReadOnlySpan<char> buses)
    {
        long t = 0;
        long step = 1;

        int offset = 0;
        int i = 0;

        while (i < buses.Length)
        {
            if (buses[i] == 'x')
            {
                // skip x
                i++;
            }
            else
            {
                // parse bus ID
                long id = 0;
                while (i < buses.Length && buses[i] >= '0' && buses[i] <= '9')
                {
                    id = id * 10 + (buses[i] - '0');
                    i++;
                }

                // apply constraint: (t + offset) % id == 0
                while ((t + offset) % id != 0)
                    t += step;

                step *= id;
            }

            // skip comma if present
            if (i < buses.Length && buses[i] == ',')
                i++;

            offset++;
        }

        return t;
    }

}