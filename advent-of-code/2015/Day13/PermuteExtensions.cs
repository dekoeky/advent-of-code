namespace advent_of_code._2015.Day13;

public static class PermuteExtensions
{

    extension<T>(IReadOnlyCollection<T> items)
    {
        public IEnumerable<IReadOnlyCollection<T>> AllPermutations()
        {
            if (items.Count == 1)
            {
                yield return items;
                yield break;
            }

            for (int i = 0; i < items.Count; i++)
            {
                var head = items.ElementAt(i);
                var tail = items.Where((_, idx) => idx != i).ToList();

                foreach (var perm in AllPermutations(tail))
                    yield return new[] { head }.Concat(perm).ToList();
            }
        }
    }
}