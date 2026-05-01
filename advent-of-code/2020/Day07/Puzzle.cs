namespace AdventOfCode._2020.Day09;

/// <summary>
/// Year 2020 Day 09 solution.
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
        var preambleSize = 5;

        // Act
        var result = Calculations.Part1(input, preambleSize);

        // Assert
        Assert.AreEqual(127, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var preambleSize = 25;

        // Act
        var result = Calculations.Part1(input, preambleSize);

        // Assert
        Assert.AreEqual(552655238, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;
        var preambleSize = 5;

        // Act
        var result = Calculations.Part2(input, preambleSize);

        // Assert
        Assert.AreEqual(62, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var preambleSize = 25;

        // Act
        var result = Calculations.Part2(input, preambleSize);

        // Assert
        Assert.AreEqual(70672245, result);
    }
}