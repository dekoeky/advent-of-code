namespace advent_of_code._2018.Day09;

internal static class Calculations
{
    public static int Part1(int players, int highestMarble)
    {
        var marbles = new List<int>(highestMarble + 1);
        var scores = new int[players];

        var elf = 0;
        var m = 0;
        var index = 0;
        marbles.Insert(index, m);

        for (m = 1; m <= highestMarble; m++)
        {
            if (m % 23 == 0)
            {
                scores[elf] += m;

                var removeIndex = NormalizeMarblePosition(index - 7);
                scores[elf] += marbles[removeIndex];
                marbles.RemoveAt(removeIndex); // SLOW!

                index = NormalizeMarblePosition(removeIndex);
            }
            else
            {
                var insertIndex = NormalizeMarblePosition(index + 2);
                marbles.Insert(insertIndex, m); // SLOW!
                index = insertIndex;
            }

            elf = (elf + 1) % players;
        }

        return scores.Max();

        int NormalizeMarblePosition(int i)
        {
            while (i < 0) i += marbles.Count;
            return i % marbles.Count;
        }
    }

    public static long Part2(int players, int highestMarble)
    {
        // Doubly-linked ring stored in arrays (no allocations during play)
        var next = new int[highestMarble + 1];
        var prev = new int[highestMarble + 1];
        var scores = new long[players];

        // Initialize ring with marble 0 pointing to itself
        next[0] = 0;
        prev[0] = 0;

        int current = 0;
        int elf = 0;

        for (int marble = 1; marble <= highestMarble; marble++)
        {
            if (marble % 23 == 0)
            {
                // Add the marble itself
                scores[elf] += marble;

                // Move 7 steps counter-clockwise
                for (var i = 0; i < 7; i++)
                    current = prev[current];

                // Remove current marble
                var removed = current;
                scores[elf] += removed;

                var before = prev[removed];
                var after = next[removed];

                next[before] = after;
                prev[after] = before;

                current = after; // new current marble
            }
            else
            {
                // Insert between next[current] and next[next[current]]
                var a = next[current];
                var b = next[a];

                next[a] = marble;
                prev[marble] = a;

                next[marble] = b;
                prev[b] = marble;

                current = marble;
            }

            elf++;
            if (elf == players) elf = 0;
        }

        long max = 0;

        foreach (var s in scores)
            if (s > max) max = s;

        return max;
    }

    public static (int Players, int LastMarbleWorth) ParseInput(string input)
    {
        var parts = input.Split();

        return (int.Parse(parts[0]), int.Parse(parts[6]));
    }
}