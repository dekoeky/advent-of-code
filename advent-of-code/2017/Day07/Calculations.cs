using advent_of_code.Helpers;

namespace advent_of_code._2017.Day07;

internal static class Calculations
{
    public static string TowerBottom(IReadOnlyCollection<BlockDefinition> blocks)
    {
        var unSupported = blocks.Select(b => b.Name).ToList();

        // assume only one block that is not supported

        foreach (var block in blocks)
            foreach (var s in block.Supports)
                unSupported.Remove(s);

        return unSupported.Single();
    }

    public static int Part2(BlockDefinition[] blocks)
    {
        throw new NotImplementedException();
    }

    public static BlockDefinition[] Parse(string input)
    {
        var lines = SplitOn.NewLines(input);
        return [.. lines.Select(BlockDefinition.Parse)];
    }
}
