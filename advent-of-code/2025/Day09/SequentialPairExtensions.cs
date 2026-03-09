namespace advent_of_code._2025.Day09;

internal static class SequentialPairExtensions
{
    extension<T>(IEnumerable<T> values)
    {
        public IEnumerable<(T, T)> SequentialPairs()
        {
            using var enumerator = values.GetEnumerator();

            // get the first element
            enumerator.MoveNext();
            var first = enumerator.Current;
            var previous = first;

            while (enumerator.MoveNext())
            {
                yield return (previous, enumerator.Current);
                previous = enumerator.Current;
            }

            yield return (previous, first);
        }
    }

    extension<T>(ICollection<T> values)
    {
        public IEnumerable<(T, T)> UniqueCombinations()
        {
            for (var i = 0; i < values.Count - 1; i++)
                for (var j = 1; j < values.Count; j++)
                    yield return (values.ElementAt(i), values.ElementAt(j));
        }
    }
}