using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode._2016.Day17;

internal static class Calculations
{
    public static string ShortestPath(string passCode)
    {
        var shortest = "NO RESULT";
        var shortestLength = int.MaxValue;
        var target = (x: 3, y: 3);
        var start = (x: 0, y: 0);


        var queue = new Queue<Data>();

        queue.Enqueue(new Data("", start));

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            // If this path can not result in a shorter route, we skip it
            if (current.Path.Length + 1 >= shortestLength) continue;

            // Target reached!
            if (current.Position == target)
            {
                if (current.Path.Length < shortestLength)
                {
                    shortest = current.Path;
                    shortestLength = current.Path.Length;
                }
                // stop processing this branch, regardless of the fact that this is the new shortest path or not
                continue;
            }

            // Unfortunately we did not reach our target yet, keep processing

            // Calculate the new hash
            var passAndPath = $"{passCode}{current.Path}";
            var asciiBytes = Encoding.ASCII.GetBytes(passAndPath);
            var hashBytes = MD5.HashData(asciiBytes);
            var hash = Convert.ToHexStringLower(hashBytes);

            // Process the first four digits, each with their move
            for (var i = 0; i < Moves.Length; i++)
            {
                // Skip processing, if a door is locked
                if (!IsOpen(hash[i]))
                    continue;

                var (dx, dy, dir) = Moves[i];
                var newPosition = (x: current.Position.x + dx, y: current.Position.y + dy);

                // Check bounds
                if (newPosition.x < 0 || newPosition.y < 0 || newPosition.x > 3 || newPosition.y > 3)
                    continue;

                queue.Enqueue(new Data(current.Path + dir, newPosition));
            }
        }

        return shortest;
    }

    public static string LongestPath(string passCode)
    {
        var longest = "NO RESULT";
        int longestLength = int.MinValue;
        var target = (x: 3, y: 3);
        var start = (x: 0, y: 0);


        var queue = new Queue<Data>();

        queue.Enqueue(new Data("", start));

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            // Target reached!
            if (current.Position == target)
            {
                if (current.Path.Length > longestLength)
                {
                    longest = current.Path;
                    longestLength = current.Path.Length;
                }
                // stop processing this branch, regardless of the fact that this is the new shortest path or not
                continue;
            }

            // Unfortunately we did not reach our target yet, keep processing

            // Calculate the new hash
            var passAndPath = $"{passCode}{current.Path}";
            var asciiBytes = Encoding.ASCII.GetBytes(passAndPath);
            var hashBytes = MD5.HashData(asciiBytes);
            var hash = Convert.ToHexStringLower(hashBytes);

            // Process the first four digits, each with their move
            for (var i = 0; i < Moves.Length; i++)
            {
                // Skip processing, if a door is locked
                if (!IsOpen(hash[i]))
                    continue;

                var (dx, dy, dir) = Moves[i];
                var newPosition = (x: current.Position.x + dx, y: current.Position.y + dy);

                // Check bounds
                if (newPosition.x < 0 || newPosition.y < 0 || newPosition.x > 3 || newPosition.y > 3)
                    continue;

                queue.Enqueue(new Data(current.Path + dir, newPosition));
            }
        }

        return longest;
    }

    static readonly (int dx, int dy, char dir)[] Moves =
    [
        // they represent, respectively, the doors up, down, left, and right from your current position
        (0, -1, 'U'),
        (0,  1, 'D'),
        (-1, 0, 'L'),
        (1,  0, 'R'),
    ];

    private static bool IsOpen(char c) => char.IsBetween(c, 'b', 'f');
}
