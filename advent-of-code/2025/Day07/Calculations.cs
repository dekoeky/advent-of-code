using advent_of_code.Helpers;
using System.Diagnostics;

namespace advent_of_code._2025.Day07;

public static class Calculations
{
    public static int CountBeamSplits(string input)
    {
        var characters = input.To2DArray();
        var columns = characters.GetLength(1);
        var visuals = (char[,])characters.Clone();

        if (!characters.TryFind('S', out var startRow, out var startCol))
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
                if (characters[r, beamColumn] != '^')
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
                visuals[r, beamColumn] = '|';

            // Visualize the beams
            Debug.WriteLine(CharArray.ToString(visuals));
            Debug.WriteLine("");
        }

        return splits;
    }
}