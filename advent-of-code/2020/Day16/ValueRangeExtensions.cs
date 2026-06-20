namespace advent_of_code._2020.Day16;

internal static class ValueRangeExtensions
{
    extension<T>(T ranges) where T : ICollection<ValueRange[]>
    {
        public bool ContainsId(int id)
            => ranges.Any(ranges => ContainsId(ranges, id));
    }

    extension(ValueRange[] ranges)
    {
        public bool ContainsId(int id)
            => ranges.Any(r => r.ContainsId(id));
    }
}