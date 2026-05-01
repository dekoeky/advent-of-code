namespace AdventOfCode._2015.Day02;

internal readonly record struct Dimensions(int L, int W, int H)
{
    public int PaperNeeded()
    {
        checked
        {
            int[] surfaces =
            [
                L * W,
                W * H,
                L * H,
            ];

            var slack = surfaces.Min();

            return surfaces.Sum() * 2 + slack;
        }
    }

    public int RibbonNeeded()
    {
        checked
        {
            int[] halfPerimeters = [
                (L + W),
                (W + H),
                (L + H)
                ];
            var minPerimeter = halfPerimeters.Min() * 2;

            var bowLength = L * W * H;

            return minPerimeter + bowLength;
        }
    }

    public static Dimensions Parse(string input)
    {
        var parts = input.Split('x');

        return new Dimensions(
            int.Parse(parts[0]),
            int.Parse(parts[1]),
            int.Parse(parts[2]));
    }
    public override string ToString() => $"{L}x{W}x{H}";
}