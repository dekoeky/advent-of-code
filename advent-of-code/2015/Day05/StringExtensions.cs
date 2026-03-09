namespace advent_of_code._2015.Day05;

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
    }
}