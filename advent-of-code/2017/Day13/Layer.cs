using advent_of_code.Helpers;

namespace advent_of_code._2017.Day13;

internal record struct Layer(int Depth, int Range)
{
    /*
     * Example: Depth: 3
     * T=0  Position: 0
     * T=1  Position: 1
     * T=2  Position: 2
     * T=3  Position: 1
     * T=4  Position: 0
     * Period: 4 = 2*range - 1
     */
    public readonly int Period => 2 * (Range - 1);


    public static Layer[] ParseMany(string input)
        => [.. SplitOn.NewLines(input).Select(Parse)];

    public static Layer Parse(string line)
    {
        var parts = line.Split(": ");

        var depth = int.Parse(parts[0]);
        var range = int.Parse(parts[1]);

        return new Layer(depth, range);
    }
}
