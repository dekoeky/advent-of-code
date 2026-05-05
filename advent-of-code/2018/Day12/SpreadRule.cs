namespace advent_of_code._2018.Day12;

public readonly record struct SpreadRule(bool[] Pattern, bool Result)
{
    private const int N = 5;

    public static SpreadRule Parse(ReadOnlySpan<char> input)
        => new(ParsePattern(input), HasPlant(input[9]));

    private static bool[] ParsePattern(ReadOnlySpan<char> input)
    {
        var pattern = new bool[N];

        for (var i = 0; i < N; i++)
            pattern[i] = HasPlant(input[i]);

        return pattern;
    }

    private static bool HasPlant(char input) => input == '#';

    public override string ToString()
    {
        var chars = new char[10];

        int i;
        for (i = 0; i < N; i++)
            chars[i] = Pattern[i] ? '#' : '.';

        chars[5] = ' ';
        chars[6] = '=';
        chars[7] = '>';
        chars[8] = ' ';
        chars[9] = Result ? '#' : '.';

        return new string(chars);
    }
}