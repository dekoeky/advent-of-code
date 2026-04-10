namespace advent_of_code._2016.Day24;

/// <summary>
/// Year 2016 Day 24 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/24"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Calculate(input);

        // Assert
        Assert.AreEqual(14, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Calculate(input);

        // Assert
        Assert.AreEqual(474, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Calculate(input, returnToStart: true);

        // Assert
        Assert.AreEqual(696, result);
    }
}