using advent_of_code.Helpers;

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
}
