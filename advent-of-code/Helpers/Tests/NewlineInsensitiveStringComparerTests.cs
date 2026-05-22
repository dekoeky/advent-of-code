namespace advent_of_code.Helpers.Tests;

/// <summary>
/// <seealso cref="NewlineInsensitiveStringComparer"/> related tests.
/// </summary>
[TestClass]
public class NewlineInsensitiveStringComparerTests
{
    [TestMethod]
    public void InstanceNotNull()
        => Assert.IsNotNull(NewlineInsensitiveStringComparer.Instance);

    [TestMethod]
    [DataRow("hello\r\nworld", "hello\rworld", true)]
    [DataRow("hello\r\nworld", "hello\nworld", true)]
    [DataRow("hello\r\nworld", "helloworld", true)]
    public void Equals(string a, string b, bool expected)
    {
        // Arrange
        var comparer = NewlineInsensitiveStringComparer.Instance;

        // Act
        var result = comparer.Equals(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
