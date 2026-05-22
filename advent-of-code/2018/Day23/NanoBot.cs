using System.Runtime.CompilerServices;

namespace advent_of_code._2018.Day23;

public readonly record struct NanoBot(Position Position, int Radius)
{
    public static NanoBot[] ParseMany(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var i = 0;
        var result = new NanoBot[n];

        foreach (var line in input.EnumerateLines())
            result[i++] = Parse(line);

        return result;
    }

    public static NanoBot Parse(ReadOnlySpan<char> input)
    {
        // Find the position/radius splitter
        const string splitter = ", ";
        var split = input.IndexOf(splitter);

        // Calculate the ranges of the data parts
        var rPosition = Range.EndAt(split);
        var rRadius = Range.StartAt(split + splitter.Length);

        // Take the partial inputs
        var sPosition = input[rPosition];
        var sRadius = input[rRadius];

        // Cut off data headers
        sPosition = sPosition["pos=".Length..];
        sRadius = sRadius["r=".Length..];

        // Parse the data fields
        var position = Position.Parse(sPosition);
        var radius = int.Parse(sRadius);

        return new NanoBot(position, radius);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int ManhattanDistance(NanoBot other)
        => ManhattanDistance(other.Position);

    public readonly int ManhattanDistance(Position position)
        => Position.ManhattanDistance(Position, position);
}
