namespace advent_of_code._2025.Day10.Models;

internal class JoltageRequirements
{
    public static int[] Parse(string s)
    {
        if (!s.StartsWith('{')) throw new InvalidOperationException();
        if (!s.EndsWith('}')) throw new InvalidOperationException();

        return s.Substring(1, s.Length - 2).Split(',').Select(int.Parse).ToArray();
    }
}