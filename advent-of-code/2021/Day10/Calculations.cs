namespace advent_of_code._2021.Day10;

internal static class Calculations
{

    public static int Part1(ReadOnlySpan<char> input)
    {
        var syntaxErrorScore = 0;

        foreach (var line in input.EnumerateLines())
            syntaxErrorScore += SyntaxErrorScore(line);

        return syntaxErrorScore;
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        var n = input.Count('\n') + 1;
        var i = 0;
        Span<long> scores = stackalloc long[n];

        foreach (var line in input.EnumerateLines())
        {
            var autoCompleteScore = AutoCompleteScore(line, false, true);

            if (autoCompleteScore <= 0)
                continue;

            scores[i++] = autoCompleteScore;
        }

        scores[..i].Sort();

        return scores[i / 2];
    }


    private static int SyntaxErrorScore(ReadOnlySpan<char> line)
    {
        Span<char> currentlyOpen = stackalloc char[line.Length];
        var o = 0;

        for (var i = 0; i < line.Length; i++)
        {
            var c = line[i];

            if (IsOpening(c))
            {
                currentlyOpen[o++] = c;
            }
            else if (IsClosing(c))
            {
                if (o == 0)
                {
                    var pts = PointsForInvalid(c);

                    Debug.WriteLine($"Found closing character {c}, but no open characters. --> {pts}");

                    return pts;
                }

                var expected = GetClosing(currentlyOpen[o - 1]);

                if (c != expected)
                {
                    // INVALID!
                    var pts = PointsForInvalid(c);

                    Debug.WriteLine($"Expected {expected}, but found {c} instead. --> +{pts} => {line}");

                    return pts;
                }

                // The closing character found, is the one we expected :)
                o--;
            }
            else throw new NotImplementedException();
        }

        if (o > 0)
        {
            // currenyly also invalid will come here
            // Incomplete --> Ignore
            Debug.WriteLine($"Incomplete line => {line}");
            return 0;
        }

        Debug.WriteLine($"No Defects Found! {line}");
        return 0;
    }


    private static bool IsOpening(char c) => OpeningChars.Contains(c);
    private static bool IsClosing(char c) => ClosingChars.Contains(c);
    private static char GetClosing(char opening) => ClosingChars[OpeningChars.IndexOf(opening)];
    private static int PointsForInvalid(char invalid) => InvalidPoints[ClosingChars.IndexOf(invalid)];
    private static int PointsForAutoComplete(char autoComplete) => AutoCompletePoints[ClosingChars.IndexOf(autoComplete)];

    private static readonly char[] OpeningChars = ['(', '[', '{', '<'];
    private static readonly char[] ClosingChars = [')', ']', '}', '>'];
    private static readonly int[] InvalidPoints = [3, 57, 1197, 25137];
    private static readonly int[] AutoCompletePoints = [1, 2, 3, 4];



    private static long AutoCompleteScore(ReadOnlySpan<char> line, bool includeErrorScore, bool includeAutoCompleteScore)
    {
        Span<char> currentlyOpen = stackalloc char[line.Length];
        var o = 0;

        for (var i = 0; i < line.Length; i++)
        {
            var c = line[i];

            if (IsOpening(c))
            {
                currentlyOpen[o++] = c;
            }
            else if (IsClosing(c))
            {
                if (o == 0)
                    return 0;


                var expected = GetClosing(currentlyOpen[o - 1]);

                if (c != expected)
                {
                    return 0;

                }

                // The closing character found, is the one we expected :)
                o--;
            }
            else throw new InvalidOperationException();
        }

        if (o > 0)
        {
            var autoCompleteScore = 0l;

            while (o > 0)
            {
                var openingCharToClose = currentlyOpen[--o];
                var closingChar = GetClosing(openingCharToClose);
                autoCompleteScore *= 5;
                autoCompleteScore += PointsForAutoComplete(closingChar);
            }
            return autoCompleteScore;
        }

        Debug.WriteLine($"No Defects Found! {line}");
        return 0;
    }
}