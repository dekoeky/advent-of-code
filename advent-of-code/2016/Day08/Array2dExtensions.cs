namespace advent_of_code._2016.Day08;

internal static class Array2dExtensions
{
    extension<T>(T[,] grid)
    {
        public int Count(Func<T, bool> predicate)
        {
            int count = 0;
            int width = grid.GetLength(0);
            int height = grid.GetLength(1);

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    if (predicate(grid[x, y]))
                        count++;

            return count;
        }
    }

    extension(bool[,] grid)
    {
        public int Count() => grid.Count(b => b);
    }
}