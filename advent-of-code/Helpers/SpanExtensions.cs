using System.Runtime.CompilerServices;

namespace advent_of_code.Helpers;

public static class SpanExtensions
{
    extension(ReadOnlySpan<char> span)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanBlockEnumerator EnumerateBlocks()
            => new(span);

        public ReadOnlySpan<char> FirstLine()
        {
            var i = span.IndexOfAny('\n', '\r');

            return i == -1 ? span : span[..i];
        }

        public ReadOnlySpan<char> Line(int n)
        {
            var i = 0;

            foreach (var line in span.EnumerateLines())
            {
                if (i == n) return line;

                if (i > n) break;

                i++;
            }

            throw new InvalidOperationException();
        }
    }
}