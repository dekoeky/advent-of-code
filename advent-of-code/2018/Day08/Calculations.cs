namespace advent_of_code._2018.Day08;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var data = Parse(input);
        int index = 0;
        var (metadataSum, _) = ParseNode(data, ref index);
        return metadataSum;
    }

    public static int Part2(string input)
    {
        var data = Parse(input);
        int index = 0;
        var (_, rootValue) = ParseNode(data, ref index);
        return rootValue;
    }

    private static int[] Parse(string input)
        => [.. input.Split().Select(int.Parse)];

    private static (int metadataSum, int nodeValue) ParseNode(int[] data, ref int index)
    {
        // Header: number of children and number of metadata entries.
        var childCount = data[index++];
        var metadataCount = data[index++];

        var metadataSum = 0;
        var nodeValue = 0;

        // First parse all children and collect their values.
        int[] childValues = childCount > 0 ? new int[childCount] : [];

        for (int i = 0; i < childCount; i++)
        {
            var (childMetaSum, childVal) = ParseNode(data, ref index);
            metadataSum += childMetaSum;
            childValues[i] = childVal;
        }

        // Then read metadata entries.
        if (childCount == 0)
        {
            // Node value is the sum of its metadata.
            for (int i = 0; i < metadataCount; i++)
            {
                int m = data[index++];
                metadataSum += m;
                nodeValue += m;
            }
        }
        else
        {
            // Metadata entries are 1-based indices into child nodes.
            for (var i = 0; i < metadataCount; i++)
            {
                var m = data[index++];
                metadataSum += m;

                if (m >= 1 && m <= childCount)
                    nodeValue += childValues[m - 1];
            }
        }

        return (metadataSum, nodeValue);
    }
}