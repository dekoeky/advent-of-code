namespace advent_of_code._2020.Day07;

/// <summary>
/// Year 2020 Day 07 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/7"/>
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
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(213, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example2;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(126, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(38426, result);
    }
}