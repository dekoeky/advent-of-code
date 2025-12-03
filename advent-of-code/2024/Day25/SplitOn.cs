namespace advent_of_code._2024.Day25;

internal static class SplitOn
{
    private static readonly string[] NewLineSeparators = ["\n", "\r", "\r\n"];
    private static readonly string[] EmptyLineSeparators = ["\n\n", "\r\r", "\r\n\r\n"];

    /// <summary>
    /// Splits each line into a separate string.
    /// </summary>
    public static string[] NewLines(string input) => input.Split(NewLineSeparators, StringSplitOptions.RemoveEmptyEntries);
    /// <summary>
    /// Splits parts of the input string, separated by a fully empty line, into separate strings.
    /// </summary>
    public static string[] EmptyLines(string input) => input.Split(EmptyLineSeparators, StringSplitOptions.RemoveEmptyEntries);
}