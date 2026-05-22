namespace advent_of_code._2022.Day18;

internal readonly record struct UnitCube(int X, int Y, int Z)
{
    public static implicit operator UnitCube((int x, int y, int z) p)
    {
        return new UnitCube(p.x, p.y, p.z);
    }

    public static UnitCube[] ParseMany(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var i = 0;

        var cubes = new UnitCube[n];

        foreach (var line in input.EnumerateLines())
            cubes[i++] = Parse(line);

        return cubes;
    }


    public static UnitCube Parse(ReadOnlySpan<char> input)
    {
        Span<Range> ranges = stackalloc Range[3];

        if (input.Split(ranges, ',') != 3)
            throw new FormatException("Invalid format");

        var x = int.Parse(input[ranges[0]]);
        var y = int.Parse(input[ranges[1]]);
        var z = int.Parse(input[ranges[2]]);

        return new(x, y, z);
    }
}
