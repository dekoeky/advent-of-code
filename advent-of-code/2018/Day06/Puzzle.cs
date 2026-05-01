namespace AdventOfCode._2018.Day06;

/// <summary>
/// Year 2018 Day 06 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/6"/>
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
        Assert.AreEqual(17, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(3010, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;
        var threshold = 32;

        // Act
        var result = Calculations.Part2(input, threshold);

        // Assert
        Assert.AreEqual(16, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var threshold = 10000;

        // Act
        var result = Calculations.Part2(input, threshold);

        // Assert
        Assert.AreEqual(48034, result);
    }
}