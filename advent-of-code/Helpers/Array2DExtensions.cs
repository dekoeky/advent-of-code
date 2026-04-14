namespace advent_of_code.Helpers;

public static class Array2DExtensions
{
    extension(Array data)
    {
        public TOut[,] CreateEqualSizeArray<TOut>() =>
        new TOut[data.GetLength(0), data.GetLength(1)];
    }

    extension<T>(T[,] array)
    {
        public int Count(Func<T, bool> predicate)
        {
            var count = 0;

            for (var r = 0; r < array.GetLength(0); r++)
                for (var c = 0; c < array.GetLength(1); c++)
                    if (predicate(array[r, c])) count++;

            return count;
        }
    }
}