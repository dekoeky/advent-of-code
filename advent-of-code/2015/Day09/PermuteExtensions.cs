namespace AdventOfCode._2015.Day09;

public static class PermuteExtensions
{

    extension<T>(IReadOnlyList<T> items)
    {
        public IEnumerable<IReadOnlyList<T>> AllPermutations()
        {
            if (items.Count == 1)
            {
                yield return items;
                yield break;
            }

            for (int i = 0; i < items.Count; i++)
            {
                var head = items[i];
                var tail = items.Where((_, idx) => idx != i).ToList();

                foreach (var perm in AllPermutations(tail))
                    yield return new[] { head }.Concat(perm).ToList();
            }
        }
    }
}