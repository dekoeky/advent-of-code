namespace advent_of_code._2022.Day09;

/// <summary>
/// Year 2022 Day 09 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/9"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(13, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(6175, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example2;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(36, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(2578, result);
    }
}