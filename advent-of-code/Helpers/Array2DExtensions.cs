namespace AdventOfCode.Helpers;

public static class Array2DExtensions
{
    extension(Array data)
    {
        public TOut[,] CreateEqualSizeArray<TOut>()
            => new TOut[data.GetLength(0), data.GetLength(1)];

        public static void CopyRegion<T>(
           T[,] src,
           int srcRow, int srcCol,
           T[,] dst,
           int dstRow, int dstCol,
           int height, int width)
        {
            for (var r = 0; r < height; r++)
                for (var c = 0; c < width; c++)
                    dst[dstRow + r, dstCol + c] = src[srcRow + r, srcCol + c];
        }
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

        public TOut[,] Convert<TOut>(Func<T, TOut> Convert)
        {
            var rows = array.GetLength(0);
            var cols = array.GetLength(1);
            var converted = new TOut[rows, cols];

            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    converted[r, c] = Convert(array[r, c]);

            return converted;
        }
    }
}