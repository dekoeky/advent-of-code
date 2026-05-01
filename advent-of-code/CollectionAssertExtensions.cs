namespace AdventOfCode;

/// <summary>
/// <see cref="CollectionAssert"/> extensions.
/// </summary>
public static class CollectionAssertExtensions
{
    extension(CollectionAssert)
    {
        public static void TrueForEach<T>(ICollection<T> collection, Func<T, bool> predicate)
            => Assert.IsTrue(collection.All(predicate));

        public static void TrueForEach<T>(ICollection<T> collection, Func<T, bool> predicate, string message)
            => Assert.IsTrue(collection.All(predicate), message);
    }
}