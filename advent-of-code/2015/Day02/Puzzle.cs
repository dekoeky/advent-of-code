namespace AdventOfCode._2015.Day02;

/// <summary>
/// Solves puzzle <see href="https://adventofcode.com/2015/day/2"/>
/// </summary>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(58, "2x3x4")]
    [DataRow(43, "1x1x10")]
    public void Part1Examples(int expectedSquareFeet, string input)
    {
        // Arrange
        var dimension = Dimensions.Parse(input);

        // Act
        var result = dimension.PaperNeeded();

        // Assert
        Assert.AreEqual(expectedSquareFeet, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var dimensions = SplitOn.NewLines(input).Select(Dimensions.Parse);

        // Act
        var result = dimensions.Sum(d => d.PaperNeeded());

        // Assert
        Assert.AreEqual(1586300, result);
    }

    [TestMethod]
    [DataRow(34, "2x3x4")]
    [DataRow(14, "1x1x10")]
    public void Part2Examples(int expected, string input)
    {
        // Arrange
        var dimensions = Dimensions.Parse(input);

        // Act
        var result = dimensions.RibbonNeeded();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var dimensions = SplitOn.NewLines(input).Select(Dimensions.Parse);

        // Act
        var result = dimensions.Sum(d => d.RibbonNeeded());

        // Assert
        Assert.AreEqual(3737498, result);
    }
}
