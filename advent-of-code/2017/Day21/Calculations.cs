using advent_of_code.Helpers;

namespace advent_of_code._2017.Day21;

internal static class Calculations
{

    private const char ON = '#';
    private const char OFF = '.';

    private const string Start =
        """
        .#.
        ..#
        ###
        """;


    public static int Execute(string input, int n)
    {
        var characters = Start.To2DArray();
        var rules = ParseRules(input);

        //Print(characters);

        for (var iteration = 0; iteration < n; iteration++)
        {
            var size = characters.GetLength(0);

            var px = size % 2 == 0 ? 2
                : size % 3 == 0 ? 3
                : throw new InvalidOperationException();
            var newPx = px + 1;

            var blocks = size / px;
            var newSize = newPx * blocks;
            var newCharacters = new char[newSize, newSize];
            var applicableRules = rules.Where(r => r.Size == px);

            for (var i = 0; i < blocks; i++)
                for (var j = 0; j < blocks; j++)
                {
                    var matchingRule = applicableRules.Single(r => r.AllVariants.Any(p => Matches(characters, i * px, j * px, p)));

                    Array.CopyRegion(matchingRule.ReplacePattern, 0, 0, newCharacters, i * newPx, j * newPx, newPx, newPx);
                }

            //Print(newCharacters);
            characters = newCharacters;
        }

        return characters.Count(c => c == ON);
    }

    [Conditional("DEBUG")]
    private static void Print(char[,] characters)
    {
        for (var r = 0; r < characters.GetLength(0); r++)
        {
            for (var c = 0; c < characters.GetLength(1); c++)
                Debug.Write(characters[r, c]);

            Debug.WriteLine();
        }

        Debug.WriteLine();
        Debug.WriteLine();
    }

    private static EnhancementRule[] ParseRules(string input)
        => [.. SplitOn.NewLines(input).Select(EnhancementRule.Parse)];

    public static bool Matches(
         char[,] src,
         int srcRow, int srcCol,
         char[,] pattern)
    {
        for (var r = 0; r < pattern.GetLength(0); r++)
            for (var c = 0; c < pattern.GetLength(1); c++)
                if (src[srcRow + r, srcCol + c] != pattern[r, c])
                    return false;

        return true;
    }
}
