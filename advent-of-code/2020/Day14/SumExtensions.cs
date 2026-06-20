namespace advent_of_code._2020.Day14;

public static class SumExtensions
{
    extension(IEnumerable<ulong> elements)
    {
        public ulong Sum()
        {
            ulong sum = 0;

            foreach (var element in elements)
                sum += element;

            return sum;
        }
    }
}