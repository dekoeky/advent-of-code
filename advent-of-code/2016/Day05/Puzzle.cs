namespace advent_of_code._2016.Day05;

/// <summary>
/// Year 2016 Day 05 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/5"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Examples()
    {
        // Arrange
        const string doorId = "abc";
        const string expectedPassword = "18f47a30";

        // Act
        var password = Calculations.CalculatePassword1(doorId);

        // Assert
        Assert.AreEqual(expectedPassword, password);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        const string doorId = "uqwqemis";

        // Act
        var password = Calculations.CalculatePassword1(doorId);

        // Assert
        Assert.AreEqual("1a3099aa", password);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        const string doorId = "abc";
        const string expectedPassword = "05ace8e3";

        // Act
        var password = Calculations.CalculatePassword2(doorId);

        // Assert
        Assert.AreEqual(expectedPassword, password);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        const string doorId = "uqwqemis";

        // Act
        var password = Calculations.CalculatePassword2(doorId);

        // Assert
        Assert.AreEqual("694190cd", password);
    }
}
