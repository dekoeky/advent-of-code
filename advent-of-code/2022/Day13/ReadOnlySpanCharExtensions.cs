using System.Runtime.CompilerServices;

namespace advent_of_code._2022.Day13;

internal static class ReadOnlySpanCharExtensions
{
    extension(ReadOnlySpan<char> original)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsList() => original.StartsWith('[');

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlySpan<char> UnpackList()
        => original.StartsWith('[') && original.EndsWith(']')
            ? original[1..^1]
            : throw new InvalidOperationException();


        public int SplitContents(Span<Range> ranges)
        {
            var start = 0;
            var open = 0;
            var close = 0;
            var r = 0;

            for (var i = 0; i < original.Length; i++)
            {
                if (original[i] == '[') open++;
                if (original[i] == ']') close++;

                if (original[i] == ',')
                {

                    if (open != close) continue;

                    ranges[r++] = new Range(start, i);
                    start = i + 1;
                }
            }

            if (original.Length - start > 0)
                ranges[r++] = new Range(start, original.Length);

            return r;
        }
    }
}