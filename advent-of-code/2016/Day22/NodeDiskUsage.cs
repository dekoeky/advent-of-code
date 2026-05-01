using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day22;

internal partial record NodeDiskUsage(string Name, int X, int Y, int Size, int Used, int Avail, int Use)
{
    [GeneratedRegex("^(?<name>/dev/grid/node-x(?<x>\\d+)-y(?<y>\\d+))\\s+(?<size>\\d+)T\\s+(?<used>\\d+)T\\s+(?<avail>\\d+)T\\s+(?<use>\\d+)%$")]
    private static partial Regex Regex { get; }

    public static NodeDiskUsage Parse(string line)
    {
        var m = Regex.Match(line);
        if (!m.Success) throw new InvalidOperationException("regex failed");

        var name = m.Groups["name"].Value;
        var x = int.Parse(m.Groups["x"].Value);
        var y = int.Parse(m.Groups["y"].Value);
        var size = int.Parse(m.Groups["size"].Value);
        var used = int.Parse(m.Groups["used"].Value);
        var avail = int.Parse(m.Groups["avail"].Value);
        var use = int.Parse(m.Groups["use"].Value);

        return new NodeDiskUsage(name, x, y, size, used, avail, use);
    }
}