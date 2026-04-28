using System.Text.RegularExpressions;

using advent_of_code.Helpers;

namespace advent_of_code._2020.Day04;

internal static partial class Calculations
{
    public static int Part1(string input)
        => CountValidPassports(input, Validate1);

    public static int Part2(string input)
        => CountValidPassports(input, Validate2);

    private static int CountValidPassports(string input, Func<Dictionary<string, string>, bool> isValid)
    {
        var passportStrings = SplitOn.EmptyLines(input);
        var passportDictionaries = passportStrings.Select(Parse).ToArray();

        return passportDictionaries.Count(isValid);
    }

    private static Dictionary<string, string> Parse(string passport)
    {
        var parts = passport.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
        return parts
            .Select(p => p.Split(':'))
            .ToDictionary(p => p[0], p => p[1]);
    }

    private static bool Validate1(Dictionary<string, string> passport)
        => RequiredProperties.Keys.All(passport.ContainsKey);

    private static bool Validate2(Dictionary<string, string> passport)
        => RequiredProperties.All(kv =>
        {
            var property = kv.Key;
            var validate = kv.Value;
            return passport.TryGetValue(property, out var value) && validate(value);
        });

    private static readonly string[] ValidEyeColors = ["amb", "blu", "brn", "gry", "grn", "hzl", "oth",];
    private static readonly Dictionary<string, Func<string, bool>> RequiredProperties = new()
    {
        ["byr"] = s => int.TryParse(s, out var byr) && byr >= 1920 && byr <= 2002,
        ["iyr"] = s => int.TryParse(s, out var iyr) && iyr >= 2010 && iyr <= 2020,
        ["eyr"] = s => int.TryParse(s, out var eyr) && eyr >= 2020 && eyr <= 2030,
        ["hgt"] = s =>
        {
            if (!int.TryParse(s[..^2], out var hgt)) return false;

            if (s.EndsWith("cm")) return hgt >= 150 && hgt <= 193;
            if (s.EndsWith("in")) return hgt >= 59 && hgt <= 76;

            return false;
        },
        ["hcl"] = s => HclRegex.IsMatch(s),
        ["ecl"] = s => ValidEyeColors.Contains(s),
        ["pid"] = s => int.TryParse(s, out _) && s.Trim().Length == 9,
    };

    [GeneratedRegex("#[0-9a-f]{6}")]
    private static partial Regex HclRegex { get; }
}