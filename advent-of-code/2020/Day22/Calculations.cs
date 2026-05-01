namespace AdventOfCode._2020.Day22;

internal static partial class Calculations
{
    public static int Part1(ReadOnlySpan<char> input)
    {
        var (player1Cards, player2Cards) = Parse(input);
        var round = 1;
        List<int> winner;
        List<int> loser;

        while (true)
        {
            Debug.WriteLine($"-- Round {round++} --");

            //Player 1's deck: 2, 6, 3, 1, 9, 5
            Debug.WriteLine($"Player 1's deck: {string.Join(", ", player1Cards)}");
            //Player 2's deck: 8, 4, 7, 10
            Debug.WriteLine($"Player 2's deck: {string.Join(", ", player2Cards)}");

            var c1 = player1Cards.RemoveLast();
            var c2 = player2Cards.RemoveLast();

            //Player 1 plays: 2
            Debug.WriteLine($"Player 1 plays: {c1}");
            //Player 2 plays: 8
            Debug.WriteLine($"Player 2 plays: {c2}");

            if (c1 > c2)
            {
                player1Cards.Insert(0, c1);
                player1Cards.Insert(0, c2);

                //Player 1 wins the round!
                Debug.WriteLine("Player 1 wins the round!");
                winner = player1Cards;
                loser = player2Cards;
            }
            else if (c2 > c1)
            {
                player2Cards.Insert(0, c2);
                player2Cards.Insert(0, c1);

                //Player 2 wins the round!
                Debug.WriteLine("Player 2 wins the round!");
                winner = player2Cards;
                loser = player1Cards;
            }
            else throw new Exception();

            Debug.WriteLine();
            if (loser.Count == 0) break;
        }

        return WinnerScore(winner);
    }

    public static int Part2(ReadOnlySpan<char> input)
    {
        var (p1, p2) = Parse(input);
        _ = PlayRecursiveCombat(p1, p2, out var winningDeck);
        return WinnerScore(winningDeck);
    }

    private static int PlayRecursiveCombat(List<int> p1, List<int> p2, out List<int> winningDeck)
    {
        // Track previous configurations to prevent infinite loops
        var seen = new HashSet<string>();

        while (p1.Count > 0 && p2.Count > 0)
        {
            // Detect repeated configuration -> Player 1 wins instantly
            var key = $"{string.Join(',', p1)}|{string.Join(',', p2)}";
            if (!seen.Add(key))
            {
                winningDeck = p1;
                return 1;
            }

            var c1 = p1.RemoveLast();
            var c2 = p2.RemoveLast();

            int roundWinner;

            // If both players have enough cards → recurse
            if (p1.Count >= c1 && p2.Count >= c2)
            {
                // Copy next cards for sub-game
                var sub1 = new List<int>(p1.TakeLast(c1));
                var sub2 = new List<int>(p2.TakeLast(c2));

                roundWinner = PlayRecursiveCombat(sub1, sub2, out _);
            }
            else
            {
                // Higher card wins
                roundWinner = c1 > c2 ? 1 : 2;
            }

            if (roundWinner == 1)
            {
                p1.Insert(0, c1);
                p1.Insert(0, c2);
            }
            else
            {
                p2.Insert(0, c2);
                p2.Insert(0, c1);
            }
        }

        if (p1.Count > 0)
        {
            winningDeck = p1;
            return 1;
        }
        else
        {
            winningDeck = p2;
            return 2;
        }
    }

    private static int WinnerScore(List<int> winner)
    {
        var score = 0;

        for (var i = 0; i < winner.Count; i++)
        {
            var multiplier = i + 1;
            score += winner[i] * multiplier;
        }

        return score;
    }

    private static (List<int> Player1, List<int> Player2) Parse(ReadOnlySpan<char> input)
    {
        // Assume always 2 players head to head
        var player1 = new List<int>(100);
        var player2 = new List<int>(100);
        var cards = player1;

        foreach (var line in input.EnumerateLines())
        {
            // Ignore player ids, and just take chronological ids
            if (line.StartsWith("Player"))
                continue;

            // Empty line means new player
            if (line.IsEmpty)
            {
                // Start giving player 2 cards
                cards = player2;
                continue;
            }

            cards.Add(int.Parse(line));
        }

        // Input has top card first
        // We store bottom card first
        player1.Reverse();
        player2.Reverse();

        return (player1, player2);
    }
}