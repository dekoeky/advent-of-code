namespace advent_of_code._2017.Day15;

internal static class Calculations
{
    private const int FactorA = 16807;
    private const int FactorB = 48271;
    private const int Lowest16BitsMask = 0b1111111111111111;
    private const int MultiplesOfA = 4;
    private const int MultiplesOfB = 8;

    public static int Part1(int startA, int startB, int n) => Matches(startA, startB, n, null, null);

    public static int Part2(int startA, int startB, int n) => Matches(startA, startB, n, MultiplesOfA, MultiplesOfB);

    private static int Matches(int startA, int startB, int n, int? multipleOfA, int? multipleOfB)
    {
        var matches = 0;
        var a = new Generator(startA, FactorA, multipleOfA);
        var b = new Generator(startB, FactorB, multipleOfB);

        for (var i = 0; i < n; i++)
        {
            a.MoveNext();
            b.MoveNext();

            // Very slow. Commented out to have a fast output in debug too
            //Debug.WriteLine($"A: {a.Current:b32} {a.Current}");
            //Debug.WriteLine($"B: {b.Current:b32} {b.Current}");
            //Debug.WriteLine();

            var lowestBitsA = a.Current & Lowest16BitsMask;
            var lowestBitsB = b.Current & Lowest16BitsMask;

            if (lowestBitsA == lowestBitsB)
                matches++;
        }

        return matches;
    }
}