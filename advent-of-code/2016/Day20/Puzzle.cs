namespace AdventOfCode._2016.Day20;

/// <summary>
/// Year 2016 Day 20 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/20"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.LowestValidIP(input);

        // Assert
        Assert.AreEqual(3u, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.LowestValidIP(input);

        // Assert
        Assert.AreEqual(23923783u, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.ValidIps(input, (0, 9));

        // Assert
        Assert.AreEqual(2ul, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.ValidIps(input);

        // Assert
        Assert.AreEqual(125u, result);
    }
}
