using System.Diagnostics;

namespace AdventOfCode.ProgressScraper;

internal static class DebugExtensions
{
    extension(Debug)
    {
        public static void WriteLine() => Debug.WriteLine(null);
    }
}