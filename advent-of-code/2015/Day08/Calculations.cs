using System.Text.RegularExpressions;

namespace AdventOfCode._2015.Day08;

internal static class Calculations
{
    public static int Delta1(string input) => GetCodeLength(input) - GetStringLength(input);

    public static int GetCodeLength(string input) => input.Length;

    public static int GetStringLength(string input) => GetUnEscaped(input).Length;

    private static string GetUnEscaped(string input) => Regex.Unescape(input[1..^1]);

    public static int Delta2(string input) => GetEncodedLength(input) - GetCodeLength(input);

    public static int GetEncodedLength(string input) => GetEncoded(input).Length;
    public static string GetEncoded(string input)
    {
        var encoded = Regex.Escape(input);

        encoded = encoded.Replace("\"", "\\\"");
        encoded = $"\"{encoded}\"";

        Debug.WriteLine($"{input} -> {encoded}");

        return encoded;
    }
}