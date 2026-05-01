namespace AdventOfCode.Helpers;

internal static class ListExtensions
{
    extension<T>(List<T> list)
    {
        public T RemoveLast()
        {
            var element = list.Last();

            list.RemoveAt(list.Count - 1);

            return element;
        }

        public void RemoveLast(int n)
        {
            var i = list.Count - 1;

            while (n-- > 0)
                list.RemoveAt(i--);
        }
    }
}