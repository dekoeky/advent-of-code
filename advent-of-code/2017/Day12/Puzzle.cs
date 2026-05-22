namespace advent_of_code._2017.Day12;

/// <summary>
/// Year 2017 Day 12 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/12"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        Calculations.Execute(input, out var group0Size, out _);

        // Assert
        Assert.AreEqual(6, group0Size);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        Calculations.Execute(input, out var group0Size, out _);

        // Assert
        Assert.AreEqual(115, group0Size);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        Calculations.Execute(input, out _, out var groups);

        // Assert
        Assert.AreEqual(2, groups);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        Calculations.Execute(input, out _, out var groups);

        // Assert
        Assert.AreEqual(221, groups);
    }
}