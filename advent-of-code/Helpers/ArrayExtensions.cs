namespace AdventOfCode.Helpers;

/// <summary>
/// <see cref="Array"/> extensions.
/// </summary>
public static class ArrayExtensions
{
    extension(Array)
    {
        /// <summary>
        /// Assigns the given <paramref name="value"/> of type <typeparamref name="T"/> to each element of the given <paramref name="array"/>.
        /// </summary>
        /// <remarks>2D extension of <see cref="Array.Fill{T}(T[], T)"/></remarks>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The array to be filled.</param>
        /// <param name="value">The value to assign to each array element.</param>
        public static void Fill<T>(T[,] array, T value)
        {
            for (var i = 0; i < array.GetLength(0); i++)
                for (var j = 0; j < array.GetLength(1); j++)
                    array[i, j] = value;
        }
    }
}