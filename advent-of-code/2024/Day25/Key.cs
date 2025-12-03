namespace advent_of_code._2024.Day25;

internal class Key(int[] values) : LockOrKey(values)
{
    public static Key Parse(string schematic) => new(CountPerColumn(schematic, '#'));
    public override string ToString() => $"key {string.Join(',', Values)}";

    public bool HasOverlapWith(Lock @lock)
    {
        const int max = 5;

        for (var i = 0; i < Values.Length; i++)
        {
            if (Values[i] + @lock.Values[i] > max)
                return true;
        }

        return false;
    }
}