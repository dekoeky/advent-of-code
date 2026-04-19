using advent_of_code.Helpers;

namespace advent_of_code._2018.Day03;

internal record struct Claim(int Id, ClaimPosition Position, ClaimSize Size)
{
    private static char[] Separators = ['#', '@', ':', ' '];

    public static Claim Parse(string input)
    {
        var parts = input.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

        var id = int.Parse(parts[0]);
        var pos = ClaimPosition.Parse(parts[1]);
        var size = ClaimSize.Parse(parts[2]);

        return new Claim(id, pos, size);
    }

    public static Claim[] ParseMany(string input)
        => [.. SplitOn.NewLines(input).Select(Parse)];

    public readonly bool Overlaps(in Claim other) => Overlaps(this, other);

    internal static bool Overlaps(in Claim a, in Claim b)
    {
        // Extract coordinates for readability
        int ax = a.Position.Left;
        int ay = a.Position.Top;
        int aw = a.Size.Width;
        int ah = a.Size.Height;

        int bx = b.Position.Left;
        int by = b.Position.Top;
        int bw = b.Size.Width;
        int bh = b.Size.Height;

        // Standard AABB overlap test
        return ax < bx + bw &&
               ax + aw > bx &&
               ay < by + bh &&
               ay + ah > by;
    }
}
