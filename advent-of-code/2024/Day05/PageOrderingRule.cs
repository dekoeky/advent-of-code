namespace advent_of_code._2024.Day05;

internal readonly record struct PageOrderingRule(int A, int B)
{
    public const char Splitter = '|';

    public static PageOrderingRule Parse(ReadOnlySpan<char> input)
    {
        var i = input.IndexOf(Splitter);
        var a = int.Parse(input[..i++]);
        var b = int.Parse(input[i..]);

        return new PageOrderingRule(a, b);
    }
}