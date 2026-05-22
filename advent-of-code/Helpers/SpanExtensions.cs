using System.Runtime.CompilerServices;

namespace advent_of_code.Helpers;

public static class SpanExtensions
{
    extension(ReadOnlySpan<char> span)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanBlockEnumerator EnumerateBlocks()
            => new(span);
    }
}