namespace AdventOfCode._2025.Day08;

public record struct JunctionBoxPosition(int X, int Y, int Z)
{
    public static double Distance(JunctionBoxPosition a, JunctionBoxPosition b)
    {
        checked
        {
            var x = b.X - a.X;
            var y = b.Y - a.Y;
            var z = b.Z - a.Z;

            // We need to use long in order to store the larger values that occur due to the squared values
            var sum = x * (long)x + y * (long)y + z * (long)z;

            return Math.Sqrt(sum);
        }
    }

    public static JunctionBoxPosition Parse(string input)
    {
        var parts = input.Split(',');

        return new JunctionBoxPosition
        {
            X = int.Parse(parts[0]),
            Y = int.Parse(parts[1]),
            Z = int.Parse(parts[2]),
        };
    }

    public static JunctionBoxPosition[] ParseList(string input)
        => SplitOn.NewLines(input).Select(Parse).ToArray();
}