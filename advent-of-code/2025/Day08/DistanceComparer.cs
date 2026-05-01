using JunctionBoxDistance = (double Distance,
    AdventOfCode._2025.Day08.JunctionBox a,
    AdventOfCode._2025.Day08.JunctionBox b);

namespace AdventOfCode._2025.Day08;

internal class JunctionBoxDistanceComparer : IComparer<JunctionBoxDistance>
{
    /// <summary>
    /// Singleton Instance.
    /// </summary>
    public static JunctionBoxDistanceComparer Instance { get; } = new();
    public int Compare(JunctionBoxDistance x, JunctionBoxDistance y)
        => x.Distance.CompareTo(y.Distance);
}
