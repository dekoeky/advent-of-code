namespace advent_of_code._2016.Day18;

/// <summary>
/// Year 2016 Day 18 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/18"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;
        var rows = 10;

        // Act
        var result = Calculations.SafeRows(input, rows);

        // Assert
        Assert.AreEqual(38, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var rows = 40;

        // Act
        var result = Calculations.SafeRows(input, rows);

        // Assert
        Assert.AreEqual(1982, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var rows = 400000;

        // Act
        var result = Calculations.SafeRows(input, rows);

        // Assert
        Assert.AreEqual(20005203, result);
    }
}