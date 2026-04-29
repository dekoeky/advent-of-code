namespace advent_of_code._2020.Day24;

/// <summary>
/// Year 2020 Day 24 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/24"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part1(input).Count;

        // Assert
        Assert.AreEqual(10, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input).Count;

        // Assert
        Assert.AreEqual(341, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;
        var days = 100;

        // Act
        var result = Calculations.Part2(input, days).Count;

        // Assert
        Assert.AreEqual(2208, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var days = 100;

        // Act
        var result = Calculations.Part2(input, days).Count;

        // Assert
        Assert.AreEqual(3700, result);
    }
}