using System.Diagnostics;

namespace advent_of_code._2025.Day09;

public class TileGrid(char[][] tiles, RowCol[] redTiles)
{
    const char RedTile = '#';
    const char GreenTile = 'X';
    const char EmptyTile = '.';
    const char EmptyTileVisited = 'o';

    public char[][] Tiles { get; } = tiles;
    public RowCol[] RedTiles { get; } = redTiles;
    public int Rows { get; } = tiles.Length;
    public int Columns { get; } = tiles[0].Length;

    public static TileGrid Create(RowCol[] redTilePositions)
    {
        var max = redTilePositions.MaxRowCol();
        var rows = max.Row + 2;
        var cols = max.Col + 2;

        //var tiles = new char[ROWS, COLS];
        // Using jagged array because 2D array hits limit
        var tiles = new char[rows][];
        for (int r = 0; r < rows; r++)
        {
            tiles[r] = new char[cols];
            Array.Fill(tiles[r], EmptyTile);
        }

        return new TileGrid(tiles, redTilePositions);
    }

    public void PlaceRedAndGreenTiles()
    {
        for (var i = 0; i < RedTiles.Length; i++)
        {
            var a = RedTiles[i];
            var b = RedTiles[(i + 1) % RedTiles.Length];

            foreach (var rc in a.TilesBetween(b))
            {
                var currentTile = this[rc];
                if (currentTile == RedTile) continue;

                if (rc == a || rc == b)
                    this[rc] = RedTile;
                else
                    this[rc] = GreenTile;
            }
        }
    }

    public void DetectOutsideTiles()
    {
        // Assume first row and first col is always outside
        for (var r = 0; r < Rows; r++)
            tiles[r][0] = Tiles[r][Columns - 1] = EmptyTileVisited;

        for (var c = 0; c < Columns; c++)
            tiles[0][c] = Tiles[Rows - 1][c] = EmptyTileVisited;

        foreach (var center in EveryTile())
        {
            // Only smear empty tiles
            if (this[center] != EmptyTileVisited) continue;

            // The center tile is an empty one,
            // smear it to all 9 surrounding cells
            foreach (var surrounding in SurroundingTiles(center))
                if (this[surrounding] == EmptyTile)
                    this[surrounding] = EmptyTileVisited;
        }
    }

    public void RemainingTilesAreGreen()
    {
        foreach (var tile in EveryTile())
            if (this[tile] == EmptyTile)
                this[tile] = GreenTile;
    }

    public long DetectLargestRectangle()
    {
        long largest = -1;

        for (int i = 0; i < RedTiles.Length - 1; i++)
            for (int j = 1; j < RedTiles.Length; j++)
            {
                var a = RedTiles[i];
                var b = RedTiles[j];
                var area = a.rectangleArea(b);

                // No need to check if valid, since it wont result in a new largest result anyway
                if (area <= largest) continue;

                // Only if all tiles in the reactangle are not empty, its valid...
                if (a.TilesBetween(b).All(t => this[t] != EmptyTileVisited))
                    largest = area;
            }

        return largest;
    }


    IEnumerable<RowCol> SurroundingTiles(RowCol rc)
        => rc.SurroundingCells().Where(Contains);

    private IEnumerable<RowCol> EveryTile()
    {
        for (int r = 0; r < Rows; r++)
            for (int c = 0; c < Columns; c++)
                yield return new RowCol(r, c);
    }

    public char this[int row, int col]
    {
        get => Tiles[row][col];
        set => Tiles[row][col] = value;
    }

    public char this[RowCol rc]
    {
        get => Tiles[rc.Row][rc.Col];
        set => Tiles[rc.Row][rc.Col] = value;
    }
    public bool Contains(RowCol rc)
        => rc.Row >= 0
        && rc.Col >= 0
        && rc.Row < Rows
        && rc.Col < Columns;

    [Conditional("DEBUG")]
    public void PrintDebug(string? title = null)
    {
        return;
        if (title is not null) Console.WriteLine(title);
        foreach (var line in tiles)
        {
            foreach (char c in line)
                Console.Write(c);
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}
