namespace AdventOfCode;

/// <summary>
/// <see cref="Debug"/> extensions.
/// </summary>
public static class DebugExtensions
{
    extension(Debug)
    {
        /// <summary>
        /// Writes an empty newline.
        /// </summary>
        public static void WriteLine() => Debug.WriteLine(null);
    }
}

