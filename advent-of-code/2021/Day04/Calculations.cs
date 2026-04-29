namespace advent_of_code._2021.Day04;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var (numbers, cards) = Parse(input);

        foreach (var number in numbers)
            foreach (var card in cards)
            {
                if (!card.Unmarked.Contains(number)) continue;

                // Mark it!
                card.Mark(number);

                // win! 
                if (card.Won)
                    return number * card.Unmarked.Sum();
            }

        throw new NotImplementedException();
    }

    public static int Part2(string input)
    {
        var (numbers, cards) = Parse(input);
        BingoCard lastWinner = null!;

        foreach (var number in numbers)
            foreach (var card in cards.Where(c => c.Won == false))
            {
                if (!card.Unmarked.Contains(number)) continue;

                // Mark it!
                card.Mark(number);

                // win! 
                if (card.Won)
                    lastWinner = card;
            }

        return lastWinner.LastMarked * lastWinner.Unmarked.Sum();
    }

    private static (int[] numbers, BingoCard[] cards) Parse(string input)
    {
        var blocks = SplitOn.EmptyLines(input);
        var numbers = blocks[0].Split(',').Select(int.Parse).ToArray();
        var cards = blocks.Skip(1).Select(ParseCard).Select(values => new BingoCard(values)).ToArray();

        return (numbers, [.. cards]);
    }

    public static int[,] ParseCard(string input)
    {
        // expect 5x5
        var card = new int[5, 5];

        var lines = SplitOn.NewLines(input);

        for (var r = 0; r < 5; r++)
        {
            var parts = lines[r].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (var c = 0; c < 5; c++)
                card[r, c] = int.Parse(parts[c]);
        }

        return card;
    }
}
