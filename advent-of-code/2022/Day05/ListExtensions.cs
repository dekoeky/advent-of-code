namespace advent_of_code._2022.Day05;

internal static class ListExtensions
{
    extension<T>(List<T> list)
    {
        public void RemoveLast(int n = 1)
        {
            var i = list.Count - 1;

            while (n-- > 0)
                list.RemoveAt(i--);
        }
    }
}