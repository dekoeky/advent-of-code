namespace AdventOfCode._2015.Day09;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        int length = Calculations.ShortestRoute(input);

        // Assert
        Assert.AreEqual(605, length);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        int length = Calculations.ShortestRoute(input);

        // Assert
        Assert.IsLessThan(316, length);
        Assert.AreEqual(141, length);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        int length = Calculations.LongestRoute(input);

        // Assert
        Assert.AreEqual(982, length);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        int length = Calculations.LongestRoute(input);

        // Assert
        Assert.AreEqual(736, length);
    }
}