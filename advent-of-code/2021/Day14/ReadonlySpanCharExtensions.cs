namespace advent_of_code._2021.Day14;

public static class ReadonlySpanCharExtensions
{
    extension(ReadOnlySpan<char> input)
    {
        public ReadOnlySpan<char> FirstLine()
        {
            var i = input.IndexOfAny('\n', '\r');

            return i == -1 ? input : input[..i];
        }
    }
}