using System.Drawing;

namespace advent_of_code._2024.Day04;

internal static class Directions
{
    public static readonly Size Horizontal = new(+1, 0);
    public static readonly Size HorizontalReversed = new(-1, 0);
    public static readonly Size Vertical = new(0, +1);
    public static readonly Size VerticalReversed = new(0, -1);
    public static readonly Size DiagonalDownwards = new(+1, +1);
    public static readonly Size DiagonalDownwardsReversed = new(-1, -1);
    public static readonly Size DiagonalUpwards = new(+1, -1);
    public static readonly Size DiagonalUpwardsReversed = new(-1, +1);

    public static readonly Size[] All = [
        Horizontal ,
        HorizontalReversed,
        Vertical ,
        VerticalReversed,
        DiagonalDownwards ,
        DiagonalDownwardsReversed ,
        DiagonalUpwards ,
        DiagonalUpwardsReversed,
    ];

}
