namespace advent_of_code._2023._14;

static class ArrayDuplicate
{
    public static T[,] Duplicate<T>(this T[,] data)
    {
        var duplicated = new T[data.GetLength(0), data.GetLength(1)];
        Array.Copy(data, 0, duplicated, 0, data.Length);
        return duplicated;
    }
}