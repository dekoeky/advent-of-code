namespace AdventOfCode._2021.Day08;

internal static class Calculations
{
    //   0:      1:      2:      3:      4:
    //  aaaa    ....    aaaa    aaaa    ....
    // b    c  .    c  .    c  .    c  b    c
    // b    c  .    c  .    c  .    c  b    c
    //  ....    ....    dddd    dddd    dddd
    // e    f  .    f  e    .  .    f  .    f
    // e    f  .    f  e    .  .    f  .    f
    //  gggg    ....    gggg    gggg    ....

    //   5:      6:      7:      8:      9:
    //  aaaa    aaaa    aaaa    aaaa    aaaa
    // b    .  b    .  .    c  b    c  b    c
    // b    .  b    .  .    c  b    c  b    c
    //  dddd    dddd    ....    dddd    dddd
    // .    f  e    f  .    f  e    f  .    f
    // .    f  e    f  .    f  e    f  .    f
    //  gggg    gggg    ....    gggg    gggg

    private static readonly Dictionary<int, string> OriginalSignalPatterns = new(10)
    {
        { 0, "abcefg" },
        { 1, "cf" },
        { 2, "acdeg" },
        { 3, "acdfg" },
        { 4, "bcdf" },
        { 5, "abdfg" },
        { 6, "abdefg" },
        { 7, "acf" },
        { 8, "abcdefg" },
        { 9, "abcdfg" },
    };


    // Number of signals per digit
    // 0: 6
    // 1: 2 *
    // 2: 5
    // 3: 5
    // 4: 4 *
    // 5: 5
    // 6: 6
    // 7: 3 *
    // 8: 7 *
    // 9: 6

    // Number of digits the signal is included
    // a: 8 (all but 1, 4)
    // b: 6 (all but 1, 2, 3, 7)
    // c: 8 (all but 6, 7)
    // d: 7 (all but 0, 1, 7)
    // e: 4 (0, 2, 6, 8)
    // f: 9 (all but 2)
    // g: 7 (all but 1, 4, 7)

    public static int Part1(ReadOnlySpan<char> input)
    {
        var count = 0;
        var l = 1;

        foreach (var line in input.EnumerateLines())
        {
            Debug.WriteLine($"Line {l++}:");

            var indexOfVerticalLine = line.IndexOf('|');
            var behindLine = line[(indexOfVerticalLine + 2)..]; // +1 to skip |, +1 to skip leading space

            Debug.WriteLine($"Part behind line: '{behindLine}'");

            foreach (var r in behindLine.Split(' '))

                switch (behindLine[r].Length)
                {
                    case 2: // Digit '1'
                    case 4: // Digit '4'
                    case 3: // Digit '7'
                    case 7: // Digit '8'
                        count++;
                        Debug.WriteLine($"{behindLine[r]}: {behindLine[r].Length}     +1");
                        break;

                    default:
                        Debug.WriteLine($"{behindLine[r]}: {behindLine[r].Length}");
                        break;
                }

            Debug.WriteLine();
        }

        return count;
    }

    public static int Part2(string input) => SplitOn.NewLines(input).Sum(ProcessLine);

    private static int ProcessLine(string line)
    {
        var parts = line.Split('|', StringSplitOptions.TrimEntries);
        var (patterns, _) = ExtractPatterns(parts[0]);
        return ExtractOutputValue(parts[1], patterns);
    }

    private static (Dictionary<int, string> SignalPatterns, Dictionary<char, char> Signals) ExtractPatterns(string input)
    {
        var signalOccurrances = GetSignalOccurrences(input);
        var signalPatterns = GetSignalPatterns(input);

        // Find signal combinations for digits that have a unique count of lit segments
        var knownSignalPatterns = GetKnownSignalPatterns(signalPatterns);
        // We now know   Signal Patterns 1, 4, 7, 8
        // We still need Signal Patterns 0, 2, 3, 5, 6, 9

        var knownSignals = GetKnownSignals(signalOccurrances);
        // We now know   Signals b, e, f
        // We still need Signals a, c, d, g

        knownSignals['a'] = UnCommonSignal(knownSignalPatterns[7], knownSignalPatterns[1]);
        // We now know   Signals a, b, e, f
        // We still need Signals c, d, g

        knownSignalPatterns[3] = GetThree(signalPatterns, knownSignalPatterns[1]);
        knownSignalPatterns[6] = GetSix(signalPatterns, knownSignalPatterns[1]);
        // We now know   Signal Patterns 1, 3, 4, 7, 8
        // We still need Signal Patterns 0, 2, 5, 6, 9

        knownSignals['c'] = GetSignalC(knownSignalPatterns);
        knownSignals['d'] = GetSignalD(knownSignalPatterns);
        knownSignals['g'] = GetSignalG(knownSignals);
        // We now know all signals!

        foreach (var (digit, pattern) in OriginalSignalPatterns)
        {
            if (knownSignalPatterns.ContainsKey(digit))
                continue;

            var translated = pattern.Select(s => knownSignals[s]).Order();

            knownSignalPatterns.Add(digit, new string([.. translated]));
        }
        // We now know all signal patterns!

        return (knownSignalPatterns, knownSignals);
    }

    private static int ExtractDigit(string signals, Dictionary<int, string> patterns)
        => patterns.Single(p => p.Value.Length == signals.Length && p.Value.All(c => signals.Contains(c))).Key;

    private static char GetSignalG(Dictionary<char, char> knownSignals)
    {
        if (knownSignals.Count != 6) throw new InvalidOperationException("We need the 6 other signals");

        for (char c = 'a'; c <= 'g'; c++)
            if (!knownSignals.ContainsValue(c))
                return c;

        throw new InvalidOperationException();
    }

    private static char GetSignalD(Dictionary<int, string> knownSignalPatterns)
    {
        var three = knownSignalPatterns[3];
        var four = knownSignalPatterns[4];
        var one = knownSignalPatterns[1];

        return three.Single(c => four.Contains(c) && !one.Contains(c));
    }
    private static char GetSignalC(Dictionary<int, string> knownSignalPatterns)
    {
        var one = knownSignalPatterns[1];
        var six = knownSignalPatterns[6];

        return one.Single(c => !six.Contains(c));
    }

    // The Signal Pattern for digit '3' contains 5 signals, and fully contains all signals of digit '1'
    private static string GetThree(string[] signalPatterns, string one)
        => signalPatterns.Single(sp => sp.Length == 5 && one.All(c => sp.Contains(c)));

    private static string GetSix(string[] signalPatterns, string one)
        => signalPatterns.Single(sp => sp.Length == 6 && !one.All(c => sp.Contains(c)));

    private static Dictionary<char, char> GetKnownSignals(Dictionary<char, int> signalOccurrances)
        => new(7)
        {
            ['e'] = signalOccurrances.Single(kv => kv.Value == 4).Key,
            ['b'] = signalOccurrances.Single(kv => kv.Value == 6).Key,
            //['c'] = signalOccurrances.Single(kv => kv.Value == 8).Key,
            ['f'] = signalOccurrances.Single(kv => kv.Value == 9).Key
        };

    private static Dictionary<int, string> GetKnownSignalPatterns(string[] signalPatterns)
        => new(10)
        {
            { 1, signalPatterns.Single(p => p.Length == 2) },
            { 7, signalPatterns.Single(p => p.Length == 3) },
            { 4, signalPatterns.Single(p => p.Length == 4) },
            { 8, signalPatterns.Single(p => p.Length == 7) },
        };

    private static string[] GetSignalPatterns(string input)
    {
        if (input.Split(' ') is not { Length: 10 } signalPatterns) throw new Exception($"Expected 10 signal patterns");

        // Order Signals Alphabetically
        for (var i = 0; i < signalPatterns.Length; i++)
            signalPatterns[i] = new string([.. signalPatterns[i].Order()]);

        return signalPatterns;
    }

    private static Dictionary<char, int> GetSignalOccurrences(ReadOnlySpan<char> input)
    {
        Dictionary<char, int> signalOccurrances = new(7)
        {
            { 'a', 0 },
            { 'b', 0 },
            { 'c', 0 },
            { 'd', 0 },
            { 'e', 0 },
            { 'f', 0 },
            { 'g', 0 },
        };

        foreach (var ch in input)
            if (char.IsBetween(ch, 'a', 'g'))
                signalOccurrances[ch]++;

        return signalOccurrances;
    }

    private static char UnCommonSignal(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
    {
        foreach (var signal in a)
            if (!b.Contains(signal))
                return signal;

        foreach (var signal in b)
            if (!a.Contains(signal))
                return signal;

        throw new InvalidOperationException();
    }

    private static int ExtractOutputValue(string input, Dictionary<int, string> patterns)
    {
        var parts = input.Split(' ');
        var value = 0;

        foreach (var part in parts)
            value = (value * 10) + ExtractDigit(part, patterns);

        return value;
    }
}