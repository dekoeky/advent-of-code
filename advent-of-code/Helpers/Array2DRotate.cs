namespace advent_of_code.Helpers;

internal static class Array2DRotate
{
    extension<T>(T[,] array)
    {
        /// <summary>
        /// Creates a 90° Clockwise rotated variant.
        /// </summary>
        public T[,] Rotated90()
        {
            var rows = array.GetLength(0);
            var cols = array.GetLength(1);

            // Rotated matrix has swapped dimensions
            var dst = new T[cols, rows];

            // Transpose + reverse rows in one pass
            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    dst[c, rows - 1 - r] = array[r, c];

            return dst;
        }

        /// <summary>
        /// Creates a 180° Clockwise rotated variant.
        /// </summary>
        public T[,] Rotated180()
        {
            var rows = array.GetLength(0);
            var cols = array.GetLength(1);

            // Rotated matrix has original dimensions
            var dst = new T[rows, cols];

            // Transpose + reverse rows in one pass
            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    dst[rows - 1 - r, cols - 1 - c] = array[r, c];

            return dst;
        }

        /// <summary>
        /// Creates a 270° Clockwise rotated variant. <br/>
        /// </summary>
        /// <remarks>
        /// This is the same as 90° Counter Clockwise.
        /// </remarks>
        public T[,] Rotated270()
        {
            var rows = array.GetLength(0);
            var cols = array.GetLength(1);

            // Rotated matrix has swapped dimensions
            var dst = new T[cols, rows];

            // Transpose + reverse rows in one pass
            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    dst[cols - 1 - c, r] = array[r, c];

            return dst;
        }

        public T[,] FlippedHorizontal()
        {
            var rows = array.GetLength(0);
            var cols = array.GetLength(1);

            // Rotated matrix has original dimensions
            var dst = new T[rows, cols];

            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    dst[r, cols - 1 - c] = array[r, c];

            return dst;
        }

        public T[,] FlippedVertical()
        {
            var rows = array.GetLength(0);
            var cols = array.GetLength(1);

            // Rotated matrix has original dimensions
            var dst = new T[rows, cols];

            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    dst[r - 1 - r, c] = array[r, c];

            return dst;
        }
    }
}