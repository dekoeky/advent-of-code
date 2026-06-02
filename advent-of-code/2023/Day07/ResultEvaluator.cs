namespace advent_of_code._2023.Day07;

internal abstract class ResultEvaluator
{
    private const int N = 'Z' - '0';

    public abstract Result Find(ReadOnlySpan<char> cards);

    public class Part1 : ResultEvaluator
    {
        public override Result Find(ReadOnlySpan<char> cards)
        {
            Span<byte> counts = stackalloc byte[N];

            for (var i = 0; i < 5; i++)
            {
                var index = cards[i] - '0';
                counts[index]++;
            }

            var atLeastTwo = 0;
            var atLeastThree = 0;

            foreach (var count in counts)
                switch (count)
                {
                    case >= 5: return Result.FiveOfAKind;
                    case 4: return Result.FourOfAKind;
                    case 3:
                        atLeastThree++;
                        atLeastTwo++;
                        break;
                    case 2:
                        atLeastTwo++;
                        break;
                }

            if (atLeastThree > 0 && atLeastTwo > 1)
                return Result.FullHouse;

            if (atLeastThree > 0)
                return Result.ThreeOfAKind;

            if (atLeastTwo >= 2)
                return Result.TwoPair;

            if (atLeastTwo >= 1)
                return Result.OnePair;

            return Result.HighCard;
        }
    }

    public class Part2 : ResultEvaluator
    {
        public override Result Find(ReadOnlySpan<char> cards)
        {
            if (cards.Length != 5) throw new InvalidOperationException("Only works for 5 cards");

            Span<byte> counts = stackalloc byte[N];
            var jokers = 0;

            for (var i = 0; i < 5; i++)
            {
                var card = cards[i];
                var index = GetIndex(card);
                if (card == 'J')
                    jokers++;
                else
                    counts[index]++;
            }


            var max = 0;
            var second = 0;

            for (var i = 0; i < N; i++)
            {
                var c = counts[i];
                if (c > max)
                {
                    second = max;
                    max = c;
                }
                else if (c > second)
                {
                    second = c;
                }
            }

            // Add jokers to the largest bucket
            max += jokers;

            if (max >= 5) return Result.FiveOfAKind;
            if (max >= 4) return Result.FourOfAKind;
            if (max == 3 && second == 2) return Result.FullHouse;
            if (max == 3) return Result.ThreeOfAKind;
            if (max == 2 && second == 2) return Result.TwoPair;
            if (max == 2) return Result.OnePair;
            return Result.HighCard;

            static int GetIndex(char card) => card - '0';
        }
    }
}