namespace AdventOfCode._2016.Day22;

/// <summary>
/// Year 2016 Day 22 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/22"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var operations = Inputs.Puzzle;

        // Act
        var result = Calculations.ViablePairs(operations.ParseNodeDiskUsages());

        // Assert
        Assert.AreEqual(941, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var operations = Inputs.Example;

        // Act
        var result = Calculations.Part2(operations.ParseNodeDiskUsages());

        // Assert
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var operations = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(operations.ParseNodeDiskUsages());

        // Assert
        Assert.AreEqual(249, result);
    }
}
