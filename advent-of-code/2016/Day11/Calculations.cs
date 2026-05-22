namespace advent_of_code._2016.Day11;

internal static partial class Calculations
{
    public static int Solve(State start)
    {
        var seen = new HashSet<string> { Key(start.Canonical()) };
        var queue = new Queue<(State State, int Steps)>();
        queue.Enqueue((start, 0));

        while (queue.Count > 0)
        {
            var (state, steps) = queue.Dequeue();
            if (state.IsGoalAchieved) return steps;

            foreach (var n in NeighborStates(state))
            {
                var key = Key(n.Canonical());
                if (seen.Add(key))
                    queue.Enqueue((n, steps + 1));
            }
        }

        // All options looped, no result found
        return -1;
    }

    private static bool IsValid(int[] gen, int[] chip)
    {
        for (var floor = 0; floor < 4; floor++)
        {
            var generators = Enumerable.Range(0, gen.Length).Where(i => gen[i] == floor).ToHashSet();

            // If this floor has no generators, no chips can be fried
            if (generators.Count <= 0)
                continue;

            // At this moment we know at leat one generator is present.
            // This means that if chips are present, they NEED theyr linked generator to be protected

            // Loop each id/type
            foreach (var i in Enumerable.Range(0, chip.Length))
                // If a given chip is on this floor, and the linked generator is not present, the chip gets fried
                if (chip[i] == floor && !generators.Contains(i))
                    // Linked generator not present, chip not protected --> Chip fried!
                    return false;
        }

        // SAFE!
        return true;
    }

    private static IEnumerable<State> NeighborStates(State s)
    {
        var (currentElevatorFloor, gen, chip) = s;

        // Both generators and microchips on the current elevator floor can be taken on the elevator
        var carryableItems = new List<(int id, bool isGen)>();
        for (int id = 0; id < gen.Length; id++)
        {
            if (gen[id] == currentElevatorFloor) carryableItems.Add((id, true));
            if (chip[id] == currentElevatorFloor) carryableItems.Add((id, false));
        }

        // Elevator can move down and up
        foreach (var elevatorMove in new[] { -1, 1 })
        {
            var newElevetorFloor = currentElevatorFloor + elevatorMove;

            // States where the elevator is too low/high are invalid -> Skip
            if (newElevetorFloor < 0 || newElevetorFloor >= 4) continue;

            // The elevator can either take 1 or 2 items from this floor
            var combinationsCarryingOneItem = ItemCombinations(carryableItems, 1);
            var combinationsCarryingTwoItems = ItemCombinations(carryableItems, 2);
            var allCombos = combinationsCarryingOneItem.Concat(combinationsCarryingTwoItems);

            foreach (var itemsBeingMoved in allCombos)
            {
                // Clone the state (partially) to avoid changing the current state
                var g2 = (int[])gen.Clone();
                var c2 = (int[])chip.Clone();

                // Update the floors of the items being moved
                foreach (var (id, isGenerator) in itemsBeingMoved)
                {
                    // If the item being moved is a generator, update the generator floor
                    if (isGenerator) g2[id] = newElevetorFloor;

                    // Idem for chips
                    else c2[id] = newElevetorFloor;
                }

                // If the state is valid, return it as a neighbouring state
                if (IsValid(g2, c2))
                    yield return new State(newElevetorFloor, g2, c2);
            }
        }
    }

    /// <summary>
    /// Enumerates each combination of <paramref name="numberOfItems"/> items from <paramref name="items"/>.
    /// </summary>
    private static IEnumerable<List<T>> ItemCombinations<T>(List<T> items, int numberOfItems)
    {
        var n = items.Count;
        if (numberOfItems == 1)
        {
            foreach (var item in items)
                yield return new List<T> { item };
        }
        else if (numberOfItems == 2)
        {
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    yield return new List<T> { items[i], items[j] };
        }
    }

    static string Key(State s)
        => $"{s.Elevator}:{string.Join(',', s.Generators.Zip(s.Chips, (g, c) => $"{g}-{c}"))}";
}
