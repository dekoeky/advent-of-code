namespace advent_of_code._2017.Day19;

internal static class Extensions
{
    extension(char[,] array)
    {
        public char Get(RowCol rc) => array[rc.Row, rc.Col];
        public bool TryGet(RowCol rc, out char result)
        {
            if (rc.Row < 0 || rc.Col < 0 || rc.Row >= array.GetLength(0) || rc.Col >= array.GetLength(1))
            {
                result = default;
                return false;
            }

            result = array[rc.Row, rc.Col];
            return true;
        }
    }
}
