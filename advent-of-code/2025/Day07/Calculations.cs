using advent_of_code.Helpers;
using System.Diagnostics;

namespace advent_of_code._2025.Day07;

public static class Calculations
{
    private const char SplitterChar = '^';
    private const char StartChar = 'S';
    private const char BeamChar = '|';

    public static int CountBeamSplits(string input)
    {
        var characters = input.To2DArray();
        var columns = characters.GetLength(1);
        var visuals = (char[,])characters.Clone();

        if (!characters.TryFind(StartChar, out var startRow, out var startCol))
            throw new InvalidOperationException("Start position not found");

        if (startRow != 0)
            throw new InvalidOperationException("Start position not on first row");

        var splits = 0;
        List<int> beamColumns = [startCol];

        // Loop each row, starting on the second row
        for (var r = 1; r < characters.GetLength(0); r++)
        {
            var newBeams = beamColumns.ToHashSet();
            foreach (var beamColumn in beamColumns)
            {
                // We will only take action on beam splitters
                if (characters[r, beamColumn] != SplitterChar)
                    continue;


                // We hit a beam splitter
                splits++;
                newBeams.Remove(beamColumn);

                if (beamColumn > 0) newBeams.Add(beamColumn - 1);
                if (beamColumn < columns - 1) newBeams.Add(beamColumn + 1);
            }

            beamColumns = newBeams.ToList();


            // Draw the beams
            foreach (var beamColumn in beamColumns)
                visuals[r, beamColumn] = BeamChar;

            // Visualize the beams
            Debug.WriteLine(CharArray.ToString(visuals));
            Debug.WriteLine("");
        }

        return splits;
    }

    public static long CountPaths(string input)
    {
        var characters = input.To2DArray();

        // Create an equal size array, holding the accumulated amount of possibilities (when looking down from a splitter)
        var pps = characters.CreateEqualSizeArray<long>();

        var rows = characters.GetLength(0);
        var cols = characters.GetLength(1);

        // Loop rows, starting on the bottom
        for (var row = rows - 1; row >= 0; row--)
            for (var col = 0; col < cols; col++)
                switch (characters[row, col])
                {
                    // We found a splitter: This splitters amount of possibilities is the sum of the possibilities of one column left + one column right
                    case SplitterChar:
                        pps[row, col] = CountPossibilities(pps, row, col - 1) + CountPossibilities(pps, row, col + 1);
                        break;

                    case StartChar:
                        return CountPossibilities(pps, row, col);
                }

        throw new InvalidOperationException("did not find the start...");
    }

    private static long CountPossibilities(long[,] pps, int row, int col)
    {
        // In the given column, find the first row that was a splitter, and has an amount of possibilities
        for (var r = row; r < pps.GetLength(0); r++)
            if (pps[r, col] > 0)
                return pps[r, col];

        // No splitters found, we return 1 to indicate this ray is a single path that did not split
        return 1;
    }
}