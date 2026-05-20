namespace advent_of_code._2018.Day18;

internal static class Calculations
{
    // The lumber collection area is 50 acres by 50 acres;
    // each acre can be either open ground (.), trees (|), or a lumberyard (#).
    private const char AcreOpen = '.';
    private const char AcreTree = '|';
    private const char AcreLumberYard = '#';

    private static readonly (int y, int x)[] Neighbors = [
        (-1, -1), (-1, 0), (-1, +1),
        ( 0, -1),          ( 0, +1),
        (+1, -1), (+1, 0), (+1, +1),
        ];

    public static int Part1(ReadOnlySpan<char> input) => Execute(input, 10);

    public static long Part2(ReadOnlySpan<char> input) => Execute(input, 1000000000);

    private static int Execute(ReadOnlySpan<char> input, int minutes)
    {
        var map = input.To2DArray();
        var newMap = map.Copy();     // To prevent changing data before all changes are evaluated

        var skipped = false;
        Dictionary<string, int> seen = [];
        seen.Add(Hash(map), 0);
        var acresWithTrees = map.Count(AcreTree);
        var acresWithLumberyards = map.Count(AcreLumberYard);

        Print(map);
        for (var minute = 0; minute < minutes; minute++)
        {
            var rows = map.GetLength(0);
            var cols = map.GetLength(1);

            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    switch (map[r, c])
                    {
                        // An open acre will become filled with trees if three or more adjacent acres
                        // contained trees. Otherwise, nothing happens.
                        case AcreOpen:
                            if (AtLeastNNeighbors(map, r, c, 3, AcreTree))
                            {
                                newMap[r, c] = AcreTree;
                                acresWithTrees++;
                            }
                            break;

                        case AcreTree:
                            if (AtLeastNNeighbors(map, r, c, 3, AcreLumberYard))
                            {
                                newMap[r, c] = AcreLumberYard;
                                acresWithTrees--;
                                acresWithLumberyards++;
                            }
                            break;

                        case AcreLumberYard:
                            if (!NeighborsContainBoth(map, r, c, AcreLumberYard, AcreTree))
                            {
                                newMap[r, c] = AcreOpen;
                                acresWithLumberyards--;
                            }
                            break;

                        default: throw new InvalidOperationException($"Invalid Acre: {map[r, c]}");
                    }

            // Apply the changes
            Array.Copy(newMap, map);
            Print(map);

            var hash = Hash(map);

            if (!seen.TryGetValue(hash, out var when))
            {
                seen[hash] = minute;
                continue;
            }

            // Cycle Detected + fast forward
            if (skipped) continue;
            var cycleLength = minute - when;
            var remainingMinutes = minutes - minute;
            var cyclesToSkip = remainingMinutes / cycleLength;
            var minutesToSkip = cyclesToSkip * 28;
            Debug.WriteLine($"Cycle detected at minute {minute}");
            Debug.WriteLine($"Minutes remaining: {remainingMinutes}");
            Debug.WriteLine($"Cycle Length: {cycleLength}");
            Debug.WriteLine($"Skipping {minutesToSkip} minutes");
            minute += minutesToSkip;
            Debug.WriteLine($"We are now at minute {minute}");
            skipped = true;
        }

        return acresWithTrees * acresWithLumberyards;
    }

    private static bool AtLeastNNeighbors(char[,] map, int row, int col, int n, char match)
    {
        var count = 0;

        foreach (var (dy, dx) in Neighbors)
        {
            var (r, c) = (row + dy, col + dx);

            if (map.TryGetValue(r, c, out var acre) && acre == match && ++count >= n)
                return true;
        }

        return false;
    }

    private static bool NeighborsContainBoth(char[,] map, int row, int col, char a, char b)
    {
        var aPresent = false;
        var bPresent = false;

        foreach (var (dy, dx) in Neighbors)
        {
            var (r, c) = (row + dy, col + dx);

            if (!map.TryGetValue(r, c, out char acre))
                continue;

            if (acre == a)
                aPresent = true;

            if (acre == b)
                bPresent = true;

            if (aPresent && bPresent) return true;
        }

        return aPresent && bPresent;
    }

    [Conditional("DEBUG")]
    private static void Print(char[,] map)
    {
        Debug.WriteLine(CharArray.ToString(map));
        Debug.WriteLine();
        Debug.WriteLine();
    }

    private static string Hash(char[,] map) => CharArray.ToString(map);
}