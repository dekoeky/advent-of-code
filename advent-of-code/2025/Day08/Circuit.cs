namespace advent_of_code._2025.Day08;

public class Circuit
{
    private static int idCounter = 0;

    public int Id { get; init; } = idCounter++;

    public List<JunctionBox> JunctionBoxes { get; } = [];

    public override string ToString() => $"Circuit{Id}";

    public static Circuit Merge(Circuit a, Circuit b)
    {
        //Debug.WriteLine($"Attempting to merge circuits {a} and {b}");

        // No need to merge
        if (a == b)
        {
            Debug.WriteLine($"Attempted to merge the same circuit twice: {a}");
            return a;
        }
        // We migrate to the largest circuit, or else to the first
        // Ensure that a contains the largest circuit
        if (b.JunctionBoxes.Count > a.JunctionBoxes.Count)
            (a, b) = (b, a);

        //Debug.WriteLine($"Migrating junctionboxes from circuit {b} to {a}");

        var count = 0;

        foreach (var jb in b.JunctionBoxes)
        {
            // Add the junctionbox to the a circuit
            a.JunctionBoxes.Add(jb);

            // Update reference on junctionbox
            jb.Circuit = a;

            count++;
        }

        // Remove all junctionboxes from b circuit (after they migrated to a circuit)
        b.JunctionBoxes.Clear();

        //Debug.WriteLine($"Migrated {count} junctionboxes");
        //Debug.WriteLine($"Circuit {a} now contains {a.JunctionBoxes.Count} JunctionBoxes");

        return a;
    }
}