namespace advent_of_code._2021.Day04;

internal record BingoCard
{
    public BingoCard(int[,] values)
    {
        Values = values;

        Rows = Values.GetLength(0);
        Columns = Values.GetLength(1);
        Unmarked = ToHashSet(Values);
        MarkedPerRow = new int[Rows];
        MarkedPerColumn = new int[Columns];
    }

    public int[,] Values { get; }
    public HashSet<int> Unmarked { get; }
    public int Rows { get; }
    public int Columns { get; }
    public int[] MarkedPerRow { get; }
    public int[] MarkedPerColumn { get; }
    public bool Won { get; private set; } = false;
    public int LastMarked { get; private set; } = -1;


    private static HashSet<int> ToHashSet(int[,] values)
    {
        HashSet<int> result = [];

        for (var r = 0; r < values.GetLength(0); r++)
            for (var c = 0; c < values.GetLength(1); c++)
                result.Add(values[r, c]);

        return result;
    }

    public void Mark(int number)
    {
        Unmarked.Remove(number);

        for (var r = 0; r < Rows; r++)
            for (var c = 0; c < Columns; c++)
                if (Values[r, c] == number)
                {
                    if (++MarkedPerRow[r] >= Columns) Won = true;
                    if (++MarkedPerColumn[c] >= Rows) Won = true;
                }

        LastMarked = number;
    }
}