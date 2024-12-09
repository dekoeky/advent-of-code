namespace advent_of_code._2024.Day08;

internal static class ArrayExtensions
{
    public static T[,] Duplicate<T>(this T[,] original)
    {
        var copy = new T[original.GetLength(0), original.GetLength(1)];

        Array.Copy(original, copy, original.Length);

        return copy;
    }
}