namespace advent_of_code._2023.Day05;

internal record Mapping(long DestinationStart, long SourceStart, long Length)
{
    public long SourceEnd { get; } = SourceStart + Length - 1;
    public long DestinationEnd { get; } = DestinationStart + Length - 1;
    public long MapOffset { get; } = DestinationStart - SourceStart;

    public bool IsInSourceRange(long id) => id >= SourceStart && id <= SourceEnd;
    //public bool IsInDestinationRange(int id) => id >= DestinationStart && id <= DestinationEnd;

    public long Map(long input)
        => IsInSourceRange(input)
        ? input + MapOffset
        : throw new ArgumentException("Not in source range");

    public static Mapping Parse(string input)
    {
        var parts = input.Split(' ');

        return new Mapping(
            long.Parse(parts[0]),
            long.Parse(parts[1]),
            long.Parse(parts[2])
            );
    }
}
