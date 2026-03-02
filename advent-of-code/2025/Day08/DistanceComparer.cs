using JunctionBoxDistance = (double Distance,
    advent_of_code._2025.Day08.JunctionBox a,
    advent_of_code._2025.Day08.JunctionBox b);

namespace advent_of_code._2025.Day08;

internal class JunctionBoxDistanceComparer : IComparer<JunctionBoxDistance>
{
    /// <summary>
    /// Singleton Instance.
    /// </summary>
    public static JunctionBoxDistanceComparer Instance { get; } = new();
    public int Compare(JunctionBoxDistance x, JunctionBoxDistance y)
        => x.Distance.CompareTo(y.Distance);
}
