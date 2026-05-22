namespace advent_of_code._2015.Day04;

[TestClass]
public class Puzzle
{
    const string puzzleKey = "bgvyzdsv";

    [TestMethod]
    [DataRow("abcdef", 609043)]
    [DataRow("pqrstuv", 1048970)]
    public void Example1(string key, int expected)
    {
        // Act
        var result = Calculations.Perform(key, 5);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        // Arrange
        var key = puzzleKey;

        // Act
        var result = Calculations.Perform(key, 5);

        // Assert
        Assert.AreEqual(254575, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        // Arrange
        var input = puzzleKey;

        // Act
        var result = Calculations.Perform(input, 6);

        // Assert
        Assert.AreEqual(1038736, result);
    }
}