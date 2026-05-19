namespace advent_of_code._2025.Day12;

internal record PuzzleInput(List<ShapeDefinition> Shapes, List<Region> Regions)
{
    public static PuzzleInput Parse(ReadOnlySpan<char> input)
    {
        List<ShapeDefinition> shapes = [];
        List<Region> regions = [];

        foreach (var block in input.EnumerateBlocks())
            if (block.Contains('x'))
                regions.AddRange(Region.ParseMany(block));
            else
                shapes.Add(ShapeDefinition.Parse(block));

        return new(shapes, regions);
    }
}
