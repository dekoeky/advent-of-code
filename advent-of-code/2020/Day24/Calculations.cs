namespace AdventOfCode._2020.Day24;

internal static partial class Calculations
{
    public static HashSet<HexCoordinate> Part1(ReadOnlySpan<char> input)
    {
        // All white to start
        var black = new HashSet<HexCoordinate>();

        foreach (var line in input.EnumerateLines())
        {
            var pos = HexCoordinate.Zero;
            for (var i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case 'e':
                        pos = pos.Move(HexDirection.East);
                        break;

                    case 'w':
                        pos = pos.Move(HexDirection.West);
                        break;

                    case 's' when line[i + 1] == 'e':
                        pos = pos.Move(HexDirection.SouthEast);
                        i++;
                        break;

                    case 's' when line[i + 1] == 'w':
                        pos = pos.Move(HexDirection.SouthWest);
                        i++;
                        break;

                    case 'n' when line[i + 1] == 'e':
                        pos = pos.Move(HexDirection.NorthEast);
                        i++;
                        break;

                    case 'n' when line[i + 1] == 'w':
                        pos = pos.Move(HexDirection.NorthWest);
                        i++;
                        break;

                    default:
                        throw new Exception();
                }
            }

            // Try to add to black set. If already there, remove it (flip back to white).
            if (!black.Add(pos))
                black.Remove(pos);
        }

        return black;
    }

    public static HashSet<HexCoordinate> Part2(ReadOnlySpan<char> input, int days)
    {
        var blackTiles = Part1(input);

        var flipToWhite = new HashSet<HexCoordinate>();
        var flipToBlack = new HashSet<HexCoordinate>();

        for (var day = 1; day <= days; day++)
        {
            // Any black tile with zero or more than 2 black tiles immediately adjacent to it is flipped to white.
            foreach (var blackTile in blackTiles)
                if (blackTile.EnumerateNeighbors().Count(blackTiles.Contains) is 0 or > 2)
                    flipToWhite.Add(blackTile);

            // Any white tile with exactly 2 black tiles immediately adjacent to it is flipped to black.
            var whiteTiles = blackTiles
                .SelectMany(blackTile => blackTile.EnumerateNeighbors())
                .Where(neighbor => !blackTiles.Contains(neighbor))
                .Distinct();

            foreach (var whiteTile in whiteTiles)
                if (whiteTile.EnumerateNeighbors().Count(blackTiles.Contains) == 2)
                    flipToBlack.Add(whiteTile);

            foreach (var blackTile in flipToWhite)
                blackTiles.Remove(blackTile);

            foreach (var whiteTile in flipToBlack)
                blackTiles.Add(whiteTile);

            flipToWhite.Clear();
            flipToBlack.Clear();
        }

        return blackTiles;
    }
}