namespace advent_of_code._2024.Day25;

internal class Lock(int[] values) : LockOrKey(values)
{
    public static Lock Parse(string schematic) => new(CountPerColumn(schematic, '#'));

    public override string ToString() => $"lock {string.Join(',', Values)}";
}