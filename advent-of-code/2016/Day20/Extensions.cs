namespace advent_of_code._2016.Day20;

public static class Extensions
{
    extension<T>(IEnumerable<T> source)
    {
        public ulong Sum(Func<T, ulong> selector)
        {
            ulong sum = 0;

            foreach (var element in source)
                sum += selector(element);

            return sum;
        }
    }
}
