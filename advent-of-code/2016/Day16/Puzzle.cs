namespace AdventOfCode._2016.Day16;

/// <summary>
/// Year 2016 Day 16 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/16"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var initialState = "10000";
        var length = 20;

        // Act
        var result = Calculations.Execute(initialState, length);

        // Assert
        Assert.AreEqual("01100", result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var initialState = "11110010111001001";
        var length = 272;

        // Act
        var result = Calculations.Execute(initialState, length);

        // Assert
        Assert.AreEqual("01110011101111011", result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var initialState = "11110010111001001";
        var length = 35651584;

        // Act
        var result = Calculations.Execute(initialState, length);

        // Assert
        Assert.AreEqual("11001111011000111", result);
    }
}