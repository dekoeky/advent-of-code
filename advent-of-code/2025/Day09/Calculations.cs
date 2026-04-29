namespace advent_of_code._2025.Day09;

internal static class Calculations
{
    public static long Perform(string input)
    {
        var lines = SplitOn.NewLines(input);
        var redTilePositions = lines.Select(RowCol.Parse).ToArray();

        long largest = -1;

        for (var i = 0; i < redTilePositions.Length - 1; i++)
            for (var j = 1; j < redTilePositions.Length; j++)
            {
                var a = redTilePositions[i];
                var b = redTilePositions[j];

                var w = Math.Abs(b.Col - a.Col) + 1;
                var h = Math.Abs(b.Row - a.Row) + 1;

                var area = w * (long)h;
                if (area > largest) largest = area;
            }

        return largest;
    }

    public static long Perform2(string input)
    {
        var lines = SplitOn.NewLines(input);
        var redTilePositions = lines.Select(RowCol.Parse).ToArray();

        var tiles = TileGrid.Create(redTilePositions);
        tiles.PrintDebug("Initial");

        tiles.PlaceRedAndGreenTiles();
        tiles.PrintDebug("Red & Green placed");

        tiles.DetectOutsideTiles();
        tiles.PrintDebug("Outside tiles detected");

        tiles.RemainingTilesAreGreen();
        tiles.PrintDebug("Remaining are green");

        return tiles.DetectLargestRectangle();
    }

    public static long Perform3(string input)
    {
        var lines = SplitOn.NewLines(input);
        var redTilePositions = lines.Select(RowCol.Parse).ToArray();
        var pairs = redTilePositions.SequentialPairs().ToArray();
        var greenTilePositions = pairs
            .SelectMany(v => v.Item1.TilesBetween2(v.Item2))
            .Distinct()
            .ToArray();
        var coloredTilePositions = redTilePositions.Concat(greenTilePositions).ToArray();


        var xxx = coloredTilePositions.ToDictionary(t => t, t => true);

        // Order the red square combos, by largest area first
        var combos = redTilePositions.UniqueCombinations()
            .OrderByDescending(combo => combo.Item1.RectangleArea(combo.Item2))
            .ToArray();

        foreach (var (a, b) in combos)
        {
            bool stillValid = true;
            var rectanglePositions = a.TilesBetween(b).ToArray();

            //if (a.TilesBetween(b).All(rc => allTiles.Contains(rc) || allTiles.Surrounded(rc)))
            foreach (var rc in rectanglePositions)
            {
                if (!xxx.TryGetValue(rc, out var isColoredTile))
                {
                    isColoredTile = coloredTilePositions.Surrounded(rc);
                    xxx[rc] = isColoredTile;
                }

                // If not a colored tile, this rectangle is invalid
                if (isColoredTile == false)
                {
                    stillValid = false;
                    break;
                }
            }
            if (stillValid)
                return a.RectangleArea(b);
        }

        return -1;
    }
}
