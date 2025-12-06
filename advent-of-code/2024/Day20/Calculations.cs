using advent_of_code.Helpers;
using System.Diagnostics;

namespace advent_of_code._2024.Day20;

public static class Calculations
{
    private const char StartChar = 'S';
    private const char EndChar = 'E';
    private const char EmptyChar = '.';

    public static int CountNumberOfShortcutsSavingAtLeast100PicoSeconds(string input)
    {
        var map = input.To2DArray();

        var current = FindStart(map);
        var previous = current;

        var positions = new Dictionary<int, RowCol>()
        {
            { 0, current }
        };

        // 0 -> 1 -> [2] -> 3 -> 4
        while (map[current.Row, current.Col] != EndChar)
        {
            // Find next checkpoint
            current = map.EnumerateUpRightDownLeftCells(current).First(c =>
            {
                if (c == previous) return false;

                var character = map[c.Row, c.Col];

                return character is EndChar or EmptyChar;
            });

            previous = positions.Values.Last();

            // Store the checkpoint
            positions.Add(positions.Count, current);
        }

        var cheats = ListCheats(positions, map).Order();

        //var grouped = cheats.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
        //foreach (var group in grouped)
        //{
        //    Console.WriteLine($"There are {group.Value} cheats that save {group.Key} picoseconds.");
        //}

        return cheats.Count(picoSecondsSaved => picoSecondsSaved >= 100);
    }

    private static IEnumerable<int> ListCheats(Dictionary<int, RowCol> positions, char[,] map)
    {
        // index of END = moves.count -1
        // index of END-1 = moves.count -2  --> 1 step till end --> no shortcut from there to end
        // index of END-2 = moves.count -3 --> 2 steps till end --> is either straight
        for (var startIndex = 0; startIndex < positions.Count - 1; startIndex++)
        {
            var start = positions[startIndex];
            for (var landIndex = positions.Keys.Last(); landIndex > startIndex + 2; landIndex--)
            {
                var land = positions[landIndex];

                var delta = land - start;

                // Shortcuts can only be straight (when we can only skip 2 walls
                if (delta.Row != 0 && delta.Col != 0) continue;

                bool vertical = delta.Row != 0;

                // We now know we only have a delta vertically OR horizontally
                var distance = vertical
                    ? Math.Abs(delta.Row)
                    : Math.Abs(delta.Col);



                // We can only skip 1 or 2 places
                if (distance is not (2 or 3)) continue;

                var singleStep = vertical
                    ? delta with { Row = Math.Sign(delta.Row) }
                    : delta with { Col = Math.Sign(delta.Col) };

                var allWalls = true;
                var inBetween = start;

                for (var i = 1; i < distance; i++)
                {
                    inBetween += singleStep;
                    if (map[inBetween.Row, inBetween.Col] != '#')
                        allWalls = false;
                }

                if (!allWalls) continue;

                // yay, we found a shortcut


                // 1 -> 2 -> [3] -> 4 -> 5 -> 6 -> 7 -> [8] -> 9
                // example: we skip from 3 to 8
                // we skip these moves: ->4 ->5 ->6 ->7
                var stepsSkipped = landIndex - startIndex - distance;

                Debug.WriteLine($"If we skip from [{startIndex}]{start} -> [{landIndex}]{land} we skip {stepsSkipped} picoSeconds {distance}");

                yield return stepsSkipped;
            }
        }
    }



    private static RowCol FindStart(char[,] map)
    {
        for (var r = 0; r < map.GetLength(0); r++)
            for (var c = 0; c < map.GetLength(1); c++)
                if (map[r, c] == StartChar)
                    return new RowCol(r, c);

        throw new InvalidOperationException();
    }
}
