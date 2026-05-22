using System.Text.RegularExpressions;

namespace advent_of_code._2022.Day11;

internal partial record Monkey
{
    //private const string Pattern = "Monkey\\s+(?<id>\\d+):\\s*Starting items:\\s*(?<items>[0-9,\\s]+)\\s*Operation:\\s*new\\s*=\\s*(?<operation>old\\s*[+*]\\s*(?:old|\\d+))\\s*Test:\\s*divisible by\\s+(?<test>\\d+)\\s*If true:\\s*throw to monkey\\s+(?<true>\\d+)\\s*If false:\\s*throw to monkey\\s+(?<false>\\d+)";
    private const string Pattern = "Monkey\\s+(?<id>\\d+):\\s*Starting items:\\s*(?<items>[0-9,\\s]+)\\s*Operation:\\s*new\\s*=\\s*(?<operation>old\\s*[+*]\\s*(?:old|\\d+))\\s*Test:\\s*(?<test>divisible by\\s+\\d+)\\s*If true:\\s*throw to monkey\\s+(?<true>\\d+)\\s*If false:\\s*throw to monkey\\s+(?<false>\\d+)";

    [GeneratedRegex(Pattern)]
    private static partial Regex Rgx { get; }

    public int Id { get; private set; }
    public long[] StartingItems
    {
        get => field;
        private init
        {
            field = value;
            CurrentItems = [.. value];
        }
    }
    public List<long> CurrentItems { get; private set; } = [];
    public Func<long, long> Operation { get; private set; }
    public Func<long, bool> IsDivisible { get; private set; }
    public long Divisor { get; set; }
    public int MonkeyTrue { get; private set; }
    public int MonkeyFalse { get; private set; }
    public long InspectionCounter { get; set; }

    public static Monkey Parse(Match match) => new Monkey
    {
        Id = int.Parse(match.Groups["id"].ValueSpan),
        StartingItems = CommaSeparatedNumbers.Parse<long>(match.Groups["items"].ValueSpan),
        Operation = ParseOperation(match.Groups["operation"].ValueSpan),
        IsDivisible = ParseTest(match.Groups["test"].ValueSpan, out var divisor),
        Divisor = divisor,
        MonkeyTrue = int.Parse(match.Groups["true"].ValueSpan),
        MonkeyFalse = int.Parse(match.Groups["false"].ValueSpan),
    };


    private static Func<long, long> ParseOperation(ReadOnlySpan<char> input)
    {
        // left op right
        Span<Range> ranges = stackalloc Range[3];

        // split into "left op right"
        if (input.Split(ranges, ' ', StringSplitOptions.RemoveEmptyEntries) != 3)
            throw new ArgumentException("Invalid expression format");

        var l = input[ranges[0]];
        var o = input[ranges[1]];
        var r = input[ranges[2]];

        var left = ParseOldOrConst(l);
        var right = ParseOldOrConst(r);

        return o switch
        {
            "+" => old => left(old) + right(old),
            "-" => old => left(old) - right(old),
            "*" => old => left(old) * right(old),
            "/" => old => left(old) / right(old),
            _ => throw new NotSupportedException($"Operator '{o}' not supported")
        };
    }

    private static Func<long, long> ParseOldOrConst(ReadOnlySpan<char> expr)
    {
        if (expr.SequenceEqual("old"))
            return old => old;

        // Parse at parsetime
        var constant = int.Parse(expr);

        // Use as 'constant' value in func (to avoid passing readonlyspan<char> as argument
        return _ => constant;
    }

    private static Func<long, bool> ParseTest(ReadOnlySpan<char> input, out long divisor)
    {
        const string db = "divisible by ";

        if (input.StartsWith(db))
        {
            var d = long.Parse(input[db.Length..]);
            divisor = d;
            return x => x % d == 0;
        }

        throw new NotImplementedException();
    }

    public static Dictionary<int, Monkey> ParseMany(string input)
    {
        Dictionary<int, Monkey> monkeys = [];

        foreach (Match m in Rgx.Matches(input))
        {
            var monkey = Parse(m);
            monkeys.Add(monkey.Id, monkey);
        }

        return monkeys;
    }
}