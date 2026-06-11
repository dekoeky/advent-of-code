namespace advent_of_code._2022.Day13;

internal class CustomComparer : IComparer<ReadOnlySpan<char>>, IComparer<string>
{
    public int Compare(ReadOnlySpan<char> x, ReadOnlySpan<char> y)
    {
        if (int.TryParse(x, out var valueA) && int.TryParse(y, out var valueB))
            return valueA < valueB ? -1
                : valueA > valueB ? +1
                : 0;

        if (x.IsList()) x = x.UnpackList();
        if (y.IsList()) y = y.UnpackList();

        return CompareContents(x, y);
    }

    public int Compare(string? x, string? y) => Compare(x.AsSpan(), y.AsSpan());

    private int CompareContents(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
    {
        Span<Range> rangesA = stackalloc Range[10];
        Span<Range> rangesB = stackalloc Range[10];

        var nA = a.SplitContents(rangesA);
        var nB = b.SplitContents(rangesB);
        var i = 0;

        while (true)
        {
            // If the left list runs out of items first, the inputs are in the right order.
            if (i >= nA && i < nB) return -1;

            // If the right list runs out of items first, the inputs are not in the right order.
            if (i < nA && i >= nB) return +1;

            // This should not happen --> no solution found
            if (i >= nA && i >= nB) return 0;

            // We now have a left element and a right element
            var l = a[rangesA[i]];
            var r = b[rangesB[i]];

            var subResult = Compare(l, r);

            if (subResult != 0)
                return subResult;

            i++;
        }
    }
}
