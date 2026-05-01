namespace AdventOfCode.ProgressScraper;

internal static class DictionaryAssert
{
    extension(Assert)
    {
        public static void ValuesNotNull<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
            where TKey : notnull
        {
            CollectionAssert.AllItemsAreNotNull(dictionary.Values);
        }
    }
}