using AdventOfCode._2016.Day21.Operations;

namespace AdventOfCode._2016.Day21;

internal static class Calculations
{
    public static string Scramble(string password, IEnumerable<Operation> operations)
    {
        Span<char> scrambled = stackalloc char[password.Length];

        password.CopyTo(scrambled);


        Debug.WriteLine($"Original: {scrambled}");
        Debug.WriteLine(scrambled.ToString());
        Debug.WriteLine();

        foreach (var op in operations)
        {
            Debug.WriteLine(op);
            op.Apply(scrambled);
            Debug.WriteLine(scrambled.ToString());
            Debug.WriteLine();
        }

        return scrambled.ToString();
    }

    public static string Unscramble(string scrambled, IEnumerable<Operation> operations)
    {
        Span<char> unscrambled = stackalloc char[scrambled.Length];

        scrambled.CopyTo(unscrambled);

        // Reverse, so that the last operation gets reverted first
        operations = [.. operations.Reverse()];

        Debug.WriteLine($"Scrambled: {unscrambled}");
        Debug.WriteLine(unscrambled.ToString());
        Debug.WriteLine();

        foreach (var op in operations)
        {
            Debug.WriteLine(op);
            op.Revert(unscrambled);
            Debug.WriteLine(unscrambled.ToString());
            Debug.WriteLine();
        }

        return unscrambled.ToString();
    }
}
