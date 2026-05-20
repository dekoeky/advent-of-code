using System.Diagnostics.CodeAnalysis;

namespace advent_of_code.Helpers;

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

        /// <summary>
        /// Returns the value at the given <paramref name="row"/> and <paramref name="col"/>, if it is inside the bounds of the given array.
        /// </summary>
        /// <remarks>
        /// It is assumed that the structure of the array is array[ROW, COL].
        /// </remarks>
        /// <returns>True if inside the array.</returns>
        public bool TryGetValue(int row, int col, [MaybeNullWhen(false)] out T value)
        {
            if (row < 0 || col < 0 || row >= array.GetLength(0) || col >= array.GetLength(1))
            {
                value = default;
                return false;
            }

            value = array[row, col];
            return true;
        }
    }

    extension<T>(T[,] array) where T : struct
    {
        /// <summary>
        /// Creates a copy of the given array.
        /// </summary>
        public T[,] Copy()
        {
            var copy = new T[array.GetLength(0), array.GetLength(1)];

            Array.Copy(array, copy, array.Length);

            return copy;
        }
    }
}