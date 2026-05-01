namespace AdventOfCode._2025.Day08;

/// <summary>
/// Comparer to sort <see cref="Circuit"/> references by <see cref="Circuit.JunctionBoxes"/> count.
/// </summary>
internal class CircuitComparerByJunctionBoxCount : IComparer<Circuit>
{
    public static CircuitComparerByJunctionBoxCount Instance { get; } = new();

    public int Compare(Circuit? x, Circuit? y)
        => y?.JunctionBoxes?.Count.CompareTo(x?.JunctionBoxes?.Count) ?? 0;
}