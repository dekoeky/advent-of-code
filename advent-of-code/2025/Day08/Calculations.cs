namespace advent_of_code._2025.Day08;

internal static class Calculations
{
    public static long Perform(JunctionBoxPosition[] input, int connectionsToMake, int nLargestCircuits)
    {
        var junctionBoxes = input.ToJunctionBoxes();
        var circuits = junctionBoxes.Select(jb => jb.Circuit).ToList();
        var distances = GetDistances(junctionBoxes);

        // Make the 10 shortest connections
        for (int i = 0; i < connectionsToMake; i++)
        {
            // Can't make more connections if no distances remain
            if (distances.Count == 0) break;

            // The first element in the list contains the two closest junction boxes
            var closest = distances[0];
            distances.RemoveAt(0);

            // If the 2 closest junction boxes are in the same circuit,
            // no circuits need to be merged
            if (closest.A.Circuit == closest.B.Circuit)
                continue;

            // Merge the 
            Circuit.Merge(closest.A.Circuit, closest.B.Circuit);

            // Remove/Forget empty circuits
            circuits.RemoveAll(c => c.JunctionBoxes.Count == 0);
        }

        circuits.Sort(CircuitComparerByJunctionBoxCount.Instance);

        //foreach (var circuit in circuits)
        //    Debug.WriteLine($"[{circuit.Id}] {circuit.JunctionBoxes.Count}");

        // Grab the N largest circuits
        var largestCircuits = circuits.Take(nLargestCircuits);

        // Get the product of the number of junctionboxes in these largest circuits
        var product = largestCircuits.Product(f => (long)f.JunctionBoxes.Count);

        return product;
    }

    private static List<(double Distance, JunctionBox A, JunctionBox B)> GetDistances(JunctionBox[] junctionBoxes)
    {
        if (junctionBoxes.Length < 2) return [];

        var results = new List<(double, JunctionBox, JunctionBox)>();

        for (var iA = 0; iA < junctionBoxes.Length - 1; iA++)
            for (var iB = iA + 1; iB < junctionBoxes.Length; iB++)
            {
                var a = junctionBoxes[iA];
                var b = junctionBoxes[iB];

                var distance = JunctionBoxPosition.Distance(a.Position, b.Position);
                results.Add(new(distance, a, b));
            }

        results.Sort(JunctionBoxDistanceComparer.Instance);

        return results;
    }
}
