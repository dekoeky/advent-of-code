namespace advent_of_code._2016.Day21;

/// <summary>
/// Year 2016 Day 21 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/21"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var operations = Inputs.Example;
        var password = "abcde";

        // Act
        var result = Calculations.Scramble(password, operations.ParseOperations());

        // Assert
        Assert.AreEqual("decab", result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var operations = Inputs.Puzzle;
        var password = "abcdefgh";

        // Act
        var result = Calculations.Scramble(password, operations.ParseOperations());

        // Assert
        Assert.AreEqual("ghfacdbe", result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var operations = Inputs.Example;
        var password = "decab";

        // Act
        var result = Calculations.Unscramble(password, operations.ParseOperations());

        // Assert
        Assert.AreEqual("abcde", result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var operations = Inputs.Puzzle;
        var password = "fbgdceah";

        // Act
        var result = Calculations.Unscramble(password, operations.ParseOperations());

        // Assert
        Assert.AreEqual("fhgcdaeb", result);
    }
}
