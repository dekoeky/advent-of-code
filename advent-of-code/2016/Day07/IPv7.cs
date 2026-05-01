namespace AdventOfCode._2016.Day07;

internal static class IPv7
{
    public static int CountTlsSupportingIps(ReadOnlySpan<char> lines)
    {
        int count = 0;

        foreach (var line in lines.EnumerateLines())
            if (SupportsTls(line))
                count++;

        return count;
    }

    public static int CountSslSupportingIps(ReadOnlySpan<char> lines)
    {
        int count = 0;

        foreach (var line in lines.EnumerateLines())
            if (SupportsSsl(line))
                count++;

        return count;
    }

    public static bool SupportsTls(ReadOnlySpan<char> input)
    {
        bool hasABBA = false;
        bool insideBrackets = false;

        for (var i = 0; i <= input.Length - 4; i++)
        {
            if (input[i] == '[')
            {
                insideBrackets = true;
                continue;
            }
            if (input[i] == ']')
            {
                insideBrackets = false;
                continue;
            }

            if (input[i + 1] is '[' or ']')
                continue;

            if (input[i] != input[i + 3])
                continue;

            if (input[i + 1] != input[i + 2])
                continue;

            // AAAA is not valid, must be ABBA
            if (input[i] == input[i + 1])
                continue;

            // ABBA pattern inside brackets, indicates TLS is not supported
            if (insideBrackets)
            {
                return false;
            }

            // We now have ABBA pattern
            hasABBA = true;

            // We need to check the rest of the input, to validate no ABBA pattern in brackets
        }

        return hasABBA;
    }

    public static bool SupportsSsl(ReadOnlySpan<char> input)
    {
        Span<(char A, char B)> abas = stackalloc (char, char)[32];
        Span<(char A, char B)> babs = stackalloc (char, char)[32];
        int abaCount = 0;
        int babCount = 0;

        bool insideBrackets = false;

        for (int i = 0; i <= input.Length - 3; i++)
        {
            char c = input[i];

            if (c == '[')
            {
                insideBrackets = true;
                continue;
            }
            if (c == ']')
            {
                insideBrackets = false;
                continue;
            }

            // ABA = A B A, A != B
            char a = input[i];
            char b = input[i + 1];
            char a2 = input[i + 2];

            if (b == '[' || b == ']') continue;
            if (a != a2) continue;
            if (a == b) continue;

            // ABA gevonden
            if (!insideBrackets)
            {
                // ABA buiten brackets → sla op als (A,B)
                if (abaCount < abas.Length)
                    abas[abaCount++] = (a, b);
            }
            else
            {
                // BAB binnen brackets → sla op als (B,A)
                if (babCount < babs.Length)
                    babs[babCount++] = (b, a);
            }
        }

        // Check of er een ABA buiten brackets is waarvoor een BAB binnen brackets bestaat
        for (int i = 0; i < abaCount; i++)
        {
            var aba = abas[i];
            for (int j = 0; j < babCount; j++)
            {
                var bab = babs[j];
                if (aba.A == bab.A && aba.B == bab.B)
                    return true;
            }
        }

        return false;
    }
}