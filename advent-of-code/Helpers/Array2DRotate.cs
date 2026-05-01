namespace AdventOfCode.Helpers;

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

        public T[][,] Variants(bool includeOriginal)
        {
            var variants = new T[includeOriginal ? 8 : 7][,];
            var i = 0;

            // Original
            // A B C
            // D E F
            // G H I
            if (includeOriginal)
                variants[i++] = array;

            // Rotated  90° Right
            // G D A
            // H E B
            // I F C
            var r90 = array.Rotated90();
            variants[i++] = r90;

            // Rotated 180° Right
            // I H G
            // F E D
            // C B A
            var r180 = r90.Rotated90();
            variants[i++] = r180;

            // Rotated 270° Right (Or 90° Left)
            // C F I
            // B E H
            // A D G
            var r270 = r180.Rotated90();
            variants[i++] = r270;

            // Flipped Horizontally
            // C B A
            // F E D
            // I H G
            var f = array.FlippedHorizontal();
            variants[i++] = f;

            // Flipped Horizontally + Rotated 90° Right
            // I F C
            // H E B
            // G D A
            var f90 = f.Rotated90();
            variants[i++] = f90;

            // Flipped Horizontally + Rotated 180° Right (Or Original Flipped Vertically)
            // G H I
            // D E F
            // A B C
            var f180 = f90.Rotated90();
            variants[i++] = f180;

            // Flipped Horizontally + Rotated 270° Right
            // A D G
            // B E H
            // C F I
            var f270 = f180.Rotated90();
            variants[i++] = f270;

            return variants;
        }
    }
}