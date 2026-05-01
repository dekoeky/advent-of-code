namespace AdventOfCode._2015.Day15;

internal static class Combinations
{
    /// <summary>
    /// Enumerates each combination of <paramref name="count"/> values that together add up to <paramref name="target"/>.
    /// </summary>
    /// <param name="count">The number of values in each result.</param>
    /// <param name="target">The sum of the values in each array.</param>
    /// <returns></returns>
    public static IEnumerable<int[]> AddingUpToTarget(int count, int target)
    {
        var buffer = new int[count];
        return EnumerateRecursive(0, target);

        IEnumerable<int[]> EnumerateRecursive(int index, int remaining)
        {
            if (index == count - 1)
            {
                buffer[index] = remaining;
                yield return (int[])buffer.Clone();
                yield break;
            }

            for (int value = 0; value <= remaining; value++)
            {
                buffer[index] = value;
                foreach (var result in EnumerateRecursive(index + 1, remaining - value))
                    yield return result;
            }
        }
    }
}
