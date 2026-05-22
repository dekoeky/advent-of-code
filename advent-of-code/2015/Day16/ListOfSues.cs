namespace advent_of_code._2015.Day16;

internal class ListOfSues
{
    public static Dictionary<int, Dictionary<string, int>> Parse(string input)
    {
        var result = new Dictionary<int, Dictionary<string, int>>();

        foreach (var line in SplitOn.NewLines(input))
        {
            // Example:
            // Sue 18: children: 9, goldfish: 2, akitas: 10
            //      /|\   find the index of the indicated ':'
            var index = line.IndexOf(':');

            // 'Sue 18'
            var sueName = line.Substring(0, index);

            // The number part starts after the letters "Sue " including space
            var sueIndex = int.Parse(sueName.Substring("Sue ".Length));


            // +1 to start behind the ':', +2 to start behind the space
            // 'children: 9, goldfish: 2, akitas: 10'
            var sueProperties = line.Substring(index + 2);

            // [0] = 'children: 9'
            // [1] = 'goldfish: 2'
            // [2] = 'akitas: 10'
            var propertyParts = sueProperties.Split(',', StringSplitOptions.TrimEntries);

            var properties = propertyParts
                .Select(p => p.Split(':', StringSplitOptions.TrimEntries))
                .ToDictionary(p => p[0], p => int.Parse(p[1]));

            result.Add(sueIndex, properties);
        }

        return result;
    }
}