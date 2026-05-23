using System.Runtime.CompilerServices;

public sealed class NewlineTypeInsensitiveStringComparer : IEqualityComparer<string>
{
    public static readonly NewlineTypeInsensitiveStringComparer Instance =
        new(ignoreExtraEdgeNewline: false);

    public static readonly NewlineTypeInsensitiveStringComparer IgnoreEdgeNewline =
        new(ignoreExtraEdgeNewline: true);

    private readonly bool _ignoreExtraEdgeNewline;

    private NewlineTypeInsensitiveStringComparer(bool ignoreExtraEdgeNewline)
    {
        _ignoreExtraEdgeNewline = ignoreExtraEdgeNewline;
    }

    public bool Equals(string? x, string? y)
    {
        if (ReferenceEquals(x, y))
            return true;

        if (x is null || y is null)
            return false;

        ReadOnlySpan<char> a = x.AsSpan();
        ReadOnlySpan<char> b = y.AsSpan();

        if (_ignoreExtraEdgeNewline)
        {
            a = TrimNewlines(a);
            b = TrimNewlines(b);
        }

        return CompareNormalized(a, b);
    }

    public int GetHashCode(string? obj)
    {
        if (obj is null)
            return 0;

        ReadOnlySpan<char> span = obj.AsSpan();

        if (_ignoreExtraEdgeNewline)
            span = TrimNewlines(span);

        return ComputeNormalizedHash(span);
    }

    // ------------------------------------------------------------
    //  Normalization helpers
    // ------------------------------------------------------------

    private static ReadOnlySpan<char> TrimNewlines(ReadOnlySpan<char> s)
    {
        // Leading
        while (s.Length > 0 && IsNewlineChar(s[0]))
            s = s[1..];

        // Trailing
        while (s.Length > 0 && IsNewlineChar(s[^1]))
            s = s[..^1];

        return s;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsNewlineChar(char c)
        => c == '\n' || c == '\r';

    private static bool CompareNormalized(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
    {
        int ia = 0;
        int ib = 0;

        while (true)
        {
            // Advance over CRs
            while (ia < a.Length && a[ia] == '\r') ia++;
            while (ib < b.Length && b[ib] == '\r') ib++;

            // End reached?
            bool enda = ia >= a.Length;
            bool endb = ib >= b.Length;

            if (enda || endb)
                return enda == endb;

            char ca = a[ia];
            char cb = b[ib];

            // Normalize newline types: treat '\n' and '\r\n' as equivalent
            bool aIsNl = ca == '\n';
            bool bIsNl = cb == '\n';

            if (aIsNl && bIsNl)
            {
                ia++;
                ib++;
                continue;
            }

            if (aIsNl != bIsNl)
                return false;

            // Normal character
            if (ca != cb)
                return false;

            ia++;
            ib++;
        }
    }

    private static int ComputeNormalizedHash(ReadOnlySpan<char> s)
    {
        unchecked
        {
            int hash = 17;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                // Skip CR
                if (c == '\r')
                    continue;

                // Normalize newline to '\n'
                if (c == '\n')
                {
                    hash = (hash * 31) + '\n';
                    continue;
                }

                hash = (hash * 31) + c;
            }

            return hash;
        }
    }
}
