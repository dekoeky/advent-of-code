namespace advent_of_code._2018.Day08;

internal static class Calculations
{
    public static int Part1(string input)
    {
        int[] values = [.. input.Split(' ').Select(int.Parse)];

        return ReadNode(values, 1, out _);
    }

    private static int ReadNode(ReadOnlySpan<int> values, int nodes, out int length)
    {
        length = 0;

        if (values.Length == 0 || nodes == 0)
            return 0;

        // HEADER CONTENT_______________
        // AA  BB A_SUBNODES B_METADATAS

        var sum = 0;
        while (nodes-- > 0)
        {
            // Read Header
            var numberOfChildNodes = values[length++];
            var numberOfMetadataEntries = values[length++];

            // Read N subnodes first, and collect the sum of metadatas
            if (numberOfChildNodes > 0)
            {
                sum += ReadNode(values[length..], numberOfChildNodes, out var childNodesLength);
                length += childNodesLength;
            }

            for (var i = 0; i < numberOfMetadataEntries; i++)
                sum += values[length++];
        }

        return sum;
    }

    public static int Part2(string input)
    {
        throw new NotImplementedException();
    }
}
