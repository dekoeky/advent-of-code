namespace AdventOfCode._2017.Day20;

/// <summary>
/// Year 2017 Day 20 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/20"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example1;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(161, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(438, result);
    }
}