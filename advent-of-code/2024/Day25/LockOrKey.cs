namespace advent_of_code._2024.Day25;

internal abstract class LockOrKey(int[] values)
{
    public int[] Values { get; } = values;

    public static void ParseMany(string schematics, out Lock[] locks, out Key[] keys)
    {
        var ll = new List<Lock>();
        var kk = new List<Key>();

        foreach (var keyOrLock in ParseMany(schematics))
        {
            switch (keyOrLock)
            {
                case Key k:
                    kk.Add(k);
                    break;
                case Lock l:
                    ll.Add(l);
                    break;
            }
        }

        locks = ll.ToArray();
        keys = kk.ToArray();
    }

    public static IEnumerable<LockOrKey> ParseMany(string schematics) =>
        SplitOn.EmptyLines(schematics).Select(ParseOne);

    public static LockOrKey ParseOne(string schematic) => schematic[0] switch
    {
        '#' => Lock.Parse(schematic),
        '.' => Key.Parse(schematic),
        _ => throw new InvalidOperationException()
    };

    protected static int[] CountPerColumn(string schematic, char charToCount)
    {
        var lines = SplitOn.NewLines(schematic);
        var columns = lines[0].Length;

        var values = new int[columns];

        for (var r = 1; r < lines.Length - 1; r++) // Loop every row/line, except the first and last one
        {
            var line = lines[r];
            for (var c = 0; c < columns; c++)
            {
                if (line[c] == charToCount)
                    values[c] += 1;
            }
        }

        return values;
    }
}