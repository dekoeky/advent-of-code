namespace advent_of_code._2025.Day12;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var puzzleInput = PuzzleInput.Parse(input);

        RemoveMathemathicallyImpossibleRegions(puzzleInput);

        foreach (var region in puzzleInput.Regions)
            Console.WriteLine(region);

        return -1;
    }

    private static void RemoveMathemathicallyImpossibleRegions(PuzzleInput puzzleInput)
    {
        var originalCount = puzzleInput.Regions.Count;

        for (var r = originalCount - 1; r >= 0; r--)
        {
            var region = puzzleInput.Regions[r];
            var availableArea = region.Size.Area;
            var neededArea = 0;

            for (var s = 0; s < puzzleInput.Shapes.Count; s++)
            {
                var shapeSize = puzzleInput.Shapes[s].Count;
                var n = region.Quantities[s];

                neededArea += n * shapeSize;
            }

            if (availableArea >= neededArea)
            {
                //Debug.WriteLine($"{region} => Fits");
                continue;
            }

            //Debug.WriteLine($"{region} => Can't fit");
            puzzleInput.Regions.RemoveAt(r);
        }
        var removed = originalCount - puzzleInput.Regions.Count;
        Debug.WriteLine($"Removed {removed} mathematically impossible regions");
    }

    public static int Part2(string input)
    {
        Assert.Inconclusive();
        throw new NotImplementedException();
    }
}