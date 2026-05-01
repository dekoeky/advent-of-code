namespace AdventOfCode._2025.Day09;

/// <summary>
/// <see cref="SequentialPairExtensions"/> tests.
/// </summary>
[TestClass]
public class SequentialPairExtensionsTests
{
    [TestMethod]
    public void MyTestMethod()
    {
        // Arrange
        char[] values = ['a', 'b', 'c', 'd'];
        (char, char)[] expected = [
            ('a','b'),
            ('b','c'),
            ('c','d'),
            ('d','a'),
            ];

        // Act
        var result = SequentialPairExtensions.SequentialPairs(values).ToArray(); ;

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }
}
