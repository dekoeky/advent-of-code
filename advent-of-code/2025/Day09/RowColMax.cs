namespace advent_of_code._2025.Day09;

public static class RowColMax
{
    extension(IEnumerable<RowCol> data)
    {
        public RowCol MaxRowCol()
        {
            var row = 0;
            var col = 0;

            foreach (var (r, c) in data)
            {
                if (r > row) row = r;
                if (c > col) col = c;
            }

            return new RowCol(row, col);
        }
    }
}