using System.Text;

namespace AdventOfCode._2022.Day05;

internal static class Calculations
{
    public static string Part1(string input)
    {
        var (stacks, moves) = ParsePuzzleInput(input);

        foreach (var move in moves)
        {
            var fromStack = stacks[move.From];
            var toStack = stacks[move.To];

            for (var i = 0; i < move.Count; i++)
            {
                // Identify crate on top
                var crate = fromStack.Last();

                // Remove from FROM stack
                fromStack.RemoveLast();

                // Add to TO stack
                toStack.Add(crate);
            }
        }

        return TopCrates(stacks);
    }


    public static string Part2(string input)
    {
        var (stacks, moves) = ParsePuzzleInput(input);

        foreach (var move in moves)
        {
            var fromStack = stacks[move.From];
            var toStack = stacks[move.To];

            var crates = fromStack.Slice(fromStack.Count - move.Count, move.Count);

            // Remove from FROM stack
            fromStack.RemoveLast(move.Count);

            // Add to TO stack
            toStack.AddRange(crates);
        }

        return TopCrates(stacks);
    }
    private static string TopCrates(Dictionary<int, List<char>> stacks)
    {
        var sb = new StringBuilder(stacks.Count);

        foreach (var (index, blocks) in stacks.OrderBy(kv => kv.Key))
            sb.Append(blocks.Last());

        return sb.ToString();
    }

    public static (Dictionary<int, List<char>> Stacks, Move[] Moves) ParsePuzzleInput(string input)
    {
        var blocks = SplitOn.EmptyLines(input);
        var stacks = ParseStacks(blocks[0]);
        var moves = Move.ParseMany(blocks[1]);

        return (stacks, moves);
    }


    public static Dictionary<int, List<char>> ParseStacks(string input)
    {
        // Assumptions:
        //  - Single digit stack id
        //  - Signle char block id

        var lines = SplitOn.NewLines(input);
        var lineCount = lines.Length;
        var lastLine = lines[lineCount - 1];

        var indices = lastLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var columns = indices.Select(i => lastLine.IndexOf(i.ToString())).ToArray();
        var stackCount = indices.Length;

        Dictionary<int, List<char>> stacks = [];
        for (var i = 0; i < stackCount; i++)
        {
            var stack = new List<char>();
            var c = columns[i];

            for (var r = lineCount - 2; r >= 0; r--)
            {
                // Whitespace means no more blocks on stack
                if (char.IsWhiteSpace(lines[r][c]))
                    break;

                // add block to stack
                stack.Add(lines[r][c]);
            }

            // Add stack to collection
            stacks.Add(indices[i], stack);
        }

        return stacks;
    }
}
