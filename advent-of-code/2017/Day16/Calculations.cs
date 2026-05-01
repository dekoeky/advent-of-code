namespace AdventOfCode._2017.Day16;

internal static class Calculations
{
    public static string Part1(string start, ReadOnlySpan<char> instructions)
        => Dance(start, instructions, 1);

    private static string Dance(string start, ReadOnlySpan<char> instructions, int n)
    {
        Span<char> characters = stackalloc char[start.Length];
        start.CopyTo(characters);

        // cycle detection :)
        var seen = new Dictionary<string, int>(200);

        for (int i = 0; i < n; i++)
        {
            var key = characters.ToString();

            if (seen.TryGetValue(key, out int previous))
            {
                // cycle detected, no need to do all the cycles
                int cycleLength = i - previous;
                int remaining = (n - i) % cycleLength;

                return Dance(key, instructions, remaining);
            }

            seen[key] = i;

            foreach (var range in instructions.Split(','))
            {
                var instruction = instructions[range];
                var arguments = instruction[1..];

                if (instruction.StartsWith('s'))
                    Spin(characters, int.Parse(arguments));
                else if (instruction.StartsWith('p'))
                    Partner(characters, arguments[0], arguments[2]);
                else if (instruction.StartsWith('x'))
                {
                    var slash = arguments.IndexOf('/');
                    var a = int.Parse(arguments[..slash]);
                    var b = int.Parse(arguments[(slash + 1)..]);
                    Exchange(characters, a, b);
                }
            }
        }

        return characters.ToString();
    }

    public static string Part2(string start, ReadOnlySpan<char> instructions)
        => Dance(start, instructions, 1000000000);

    /// <summary>
    /// Spin <paramref name="n"/> to the right.
    /// </summary>
    private static void Spin(Span<char> characters, int n)
    {
        n %= characters.Length;

        if (n == 0) return;

        Span<char> temp = stackalloc char[characters.Length * 2];
        characters.CopyTo(temp);
        characters.CopyTo(temp[characters.Length..]);

        temp.Slice(characters.Length - n, characters.Length).CopyTo(characters);
    }

    private static void Exchange(Span<char> characters, int a, int b)
        => (characters[a], characters[b]) = (characters[b], characters[a]);

    private static void Partner(Span<char> characters, char a, char b)
    {
        for (var i = 0; i < characters.Length; i++)
            if (characters[i] == a)
                characters[i] = b;
            else if (characters[i] == b)
                characters[i] = a;
    }
}
