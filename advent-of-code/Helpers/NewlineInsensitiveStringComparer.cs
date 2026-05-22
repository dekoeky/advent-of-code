using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace advent_of_code.Helpers;

/// <summary>
/// StringComparer
/// </summary>
public sealed class NewlineInsensitiveStringComparer : IEqualityComparer<string>, IEqualityComparer<ReadOnlySpan<char>>
{
    public static readonly NewlineInsensitiveStringComparer Instance = new();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsNewline(char c)
        => c == '\r' || c == '\n';

    public bool Equals(string? a, string? b)
    {
        if (ReferenceEquals(a, b))
            return true;

        if (a is null || b is null)
            return false;

        return Equals(a.AsSpan(), b.AsSpan());
    }

    public bool Equals(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
    {
        int iA = 0, iB = 0;

        while (true)
        {
            // Skip newline chars in both
            while (iA < a.Length && IsNewline(a[iA])) iA++;
            while (iB < b.Length && IsNewline(b[iB])) iB++;

            // End?
            var enda = iA >= a.Length;
            var endb = iB >= b.Length;

            if (enda || endb)
                return enda == endb; // both must end at same time

            if (a[iA] != b[iB])
                return false;

            iA++;
            iB++;
        }
    }

    public int GetHashCode(string obj)
    {
        if (obj is null)
            return 0;

        return GetHashCode(obj.AsSpan());
    }

    public int GetHashCode([DisallowNull] ReadOnlySpan<char> obj)
    {
        unchecked
        {
            int hash = 17;

            foreach (char c in obj)
            {
                if (!IsNewline(c))
                    hash = hash * 31 + c;
            }

            return hash;
        }
    }
}
