namespace advent_of_code.Helpers;

internal static class CombinationExtensions
{
    extension<T>(ICollection<T> source)
    {
        public IEnumerable<(T a, T b)> UniqueCombinationsOfTwo()
        {
            for (var ia = 0; ia < source.Count; ia++)
                for (var ib = ia; ib < source.Count; ib++)
                    yield return (source.ElementAt(ia), source.ElementAt(ib));
        }
    }
}