using System.Runtime.CompilerServices;

namespace advent_of_code._2022.Day13;

internal static partial class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var sum = 0;
        var index = 0;

        foreach (var pair in input.EnumerateBlocks())
        {
            // One based indexing
            ++index;

            if (IsInCorrectOrder(pair))
                sum += index;
        }

        return sum;
    }

    public static string Part2(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }

    private static bool IsInCorrectOrder(ReadOnlySpan<char> block)
    {
        var lines = block.EnumerateLines();


        if (!lines.MoveNext()) throw new InvalidOperationException("Item 1 not found");
        var a = lines.Current;

        if (!lines.MoveNext()) throw new InvalidOperationException("Item 2 not found");
        var b = lines.Current;

        return AreInCorrectOrder(a, b) == Order.Correct;
    }

    private static Order AreInCorrectOrder(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
    {
        if (int.TryParse(a, out var valueA) && int.TryParse(b, out var valueB))
            return valueA < valueB ? Order.Correct
                : valueA > valueB ? Order.Incorrect
                : Order.Unknown;

        if (IsList(a)) a = UnpackList(a);
        if (IsList(b)) b = UnpackList(b);

        return AreListContentsInCorrectOrder(a, b);
    }

    private static Order AreListContentsInCorrectOrder(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
    {
        Span<Range> rangesA = stackalloc Range[10];
        Span<Range> rangesB = stackalloc Range[10];

        var nA = SplitContents(a, rangesA);
        var nB = SplitContents(b, rangesB);
        var i = 0;

        while (true)
        {
            // If the left list runs out of items first, the inputs are in the right order.
            if (i >= nA && i < nB) return Order.Correct;

            // If the right list runs out of items first, the inputs are not in the right order.
            if (i < nA && i >= nB) return Order.Incorrect;

            // This should not happen --> no solution found
            if (i >= nA && i >= nB) return Order.Unknown;

            // We now have a left element and a right element
            var l = a[rangesA[i]];
            var r = b[rangesB[i]];

            var subResult = AreInCorrectOrder(l, r);

            if (subResult != Order.Unknown)
                return subResult;

            i++;
        }
    }

    static int SplitContents(ReadOnlySpan<char> input, Span<Range> ranges)
    {
        var start = 0;
        var open = 0;
        var close = 0;
        var r = 0;

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == '[') open++;
            if (input[i] == ']') close++;

            if (input[i] == ',')
            {

                if (open != close) continue;

                ranges[r++] = new Range(start, i);
                start = i + 1;
            }
        }

        if (input.Length - start > 0)
            ranges[r++] = new Range(start, input.Length);

        return r;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsList(ReadOnlySpan<char> a) => a.StartsWith('[');

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ReadOnlySpan<char> UnpackList(ReadOnlySpan<char> original)
        => original.StartsWith('[') && original.EndsWith(']')
            ? original[1..^1]
            : throw new InvalidOperationException();
}
