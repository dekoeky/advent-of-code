namespace AdventOfCode._2015.Day05;

internal static class StringExtensions
{
    private const string vowels = "aeiou";
    private static readonly string[] notAllowed = [
        "ab",
        "cd",
        "pq",
        "xy",
        ];

    extension(string input)
    {
        public bool IsNice()
        {
            if (notAllowed.Any(input.Contains))
                return false;

            int vowelCount = 0;
            bool containsTwoSameLettersInARow = false;
            char last = default;

            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];

                if (vowels.Contains(c)) vowelCount++;

                if (last == c) containsTwoSameLettersInARow = true; ;
                last = c;
            }

            return vowelCount >= 3 && containsTwoSameLettersInARow;
        }

        public bool IsNiceV2()
        {
            var a = input.ContainsLetterThatRepeatsWithExactly1LetterBetween();

            var b = input.ContainsTwoLetterPatternTwice();

            var isNice = a & b;
            Debug.WriteLine($"{input}          -> {(isNice ? "Nice" : "Naughty")}");
            Debug.WriteLine("");

            return isNice;
        }

        public bool ContainsLetterThatRepeatsWithExactly1LetterBetween()
        {
            if (input.Length < 3) return false;

            for (var i = 0; i < input.Length - 2; i++)
                if (input[i] == input[i + 2])
                {
                    Debug.WriteLine($"{input} [?x?]    -> {input.Substring(i, 3)}");
                    return true;
                }
            return false;
        }
        public bool ContainsTwoLetterPatternTwice()
        {
            if (input.Length < 4) return false;
            // last index = length - 1

            for (var i = 0; i < input.Length - 2; i++)
            {
                var pattern = input.AsSpan(i, 2);
                var remaining = input.AsSpan(i + 2);

                if (remaining.IndexOf(pattern, StringComparison.Ordinal) != -1)
                {
                    Debug.WriteLine($"{input} [ab..ab] -> {input.Substring(i, 2)}");
                    return true;
                }
            }

            return false;
        }
    }
}