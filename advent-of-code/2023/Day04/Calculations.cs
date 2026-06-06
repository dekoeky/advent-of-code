namespace advent_of_code._2023.Day04;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var totalValue = 0;
        var card = 0;
        var winninNumbers = new HashSet<int>(10);
        Span<Range> ranges = stackalloc Range[30];

        foreach (var line in input.EnumerateLines())
        {
            var thisCardValue = 0;
            card++;
            winninNumbers.Clear();

            var start = line.IndexOf(':') + 2; // +2 for skipping ':' and space
            var split = line.IndexOf('|');

            var txt = line[start..(split - 1)];
            var n = txt.Split(ranges, ' ', StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < n; i++)
            {
                var winner = int.Parse(txt[ranges[i]]);
                winninNumbers.Add(winner);
            }

            txt = line[(split + 1)..];
            n = txt.Split(ranges, ' ', StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < n; i++)
            {
                var number = int.Parse(txt[ranges[i]]);

                if (!winninNumbers.Contains(number))
                    continue;

                thisCardValue = thisCardValue == 0 ? 1 : thisCardValue * 2;
                Debug.WriteLine($"Card {card,3} number {number,2} -> Winner!");
            }
            totalValue += thisCardValue;
            Debug.WriteLine();
        }

        return totalValue;
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }
}