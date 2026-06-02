namespace advent_of_code._2023.Day08;

internal record PuzzleInput(string Instructions, Dictionary<string, (string Left, string Right)> Network)
{

    public static PuzzleInput Parse(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') - 1; // +1 for all lines, -2 for instructions and empty line
        var lines = input.EnumerateLines();

        lines.MoveNext();
        var instructions = lines.Current.ToString();

        // Skip empty line
        lines.MoveNext();

        var network = new Dictionary<string, (string Left, string Right)>(n);

        foreach (var line in lines)
        {
            // Since ids are always 3 long, we can extract the ids from fixed positions
            var node = line[0..3].ToString();
            var l = line[7..10].ToString();
            var r = line[12..15].ToString();

            network.Add(node, (l, r));
        }

        return new PuzzleInput(instructions, network);
    }
}