namespace advent_of_code._2018.Day13;

internal readonly struct CartComparer : IComparer<Cart>
{
    public int Compare(Cart? a, Cart? b)
    {
        // Null checks only if you ever use nullable; otherwise remove.
        if (a is null) return b is null ? 0 : -1;
        if (b is null) return 1;

        int dy = a.Position.Y - b.Position.Y;
        if (dy != 0)
            return dy;

        return a.Position.X - b.Position.X;
    }
}
