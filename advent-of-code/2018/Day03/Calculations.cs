namespace AdventOfCode._2018.Day03;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var claims = Claim.ParseMany(input);
        var wholeFabric = new int[1000, 1000];

        foreach (var claim in claims)
            for (var r = 0; r < claim.Size.Height; r++)
                for (var c = 0; c < claim.Size.Width; c++)
                    wholeFabric[claim.Position.Top + r, claim.Position.Left + c]++;

        return wholeFabric.Count(c => c >= 2);
    }

    public static int Part2(string input)
    {
        var claims = Claim.ParseMany(input);
        var overlapDetected = false;

        for (var i = 0; i < claims.Length; i++)
        {
            overlapDetected = false;
            var a = claims[i];
            Debug.WriteLine($"Claim A: {a.Id}");

            for (var j = 0; j < claims.Length; j++)
            {
                if (i == j) continue;
                var b = claims[j];
                Debug.WriteLine($"Claim B: {b.Id}");

                if (claims[i].Overlaps(claims[j]))
                {
                    Debug.WriteLine($"{a.Id,3} - {b.Id,3}: Overlap detected!");
                    overlapDetected = true;

                    // Skip remaining j combinations, since i is invalidated
                    break;
                }
                else
                {
                    Debug.WriteLine($"{a.Id,3} - {b.Id,3}: No Overlap :)");
                }
            }

            if (!overlapDetected) return a.Id;
        }

        throw new InvalidOperationException("No solution found!");
    }
}