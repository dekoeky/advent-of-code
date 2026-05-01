namespace AdventOfCode._2025.Day09;

internal static class HashSetExtensions
{
    extension<T>(HashSet<T> hashSet)
    {
        public int AddRange(IEnumerable<T> items)
        {
            var i = 0;

            foreach (var item in items)
                if (hashSet.Add(item))
                    i++;

            return i;
        }
    }
}