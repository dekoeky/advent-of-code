namespace AdventOfCode._2018.Day01;

/// <summary>
/// Year 2018 Day 01 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/1"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("+1, -2, +3, +1", +3)]
    [DataRow("+1, +1, +1", +3)]
    [DataRow("+1, +1, -2", +0)]
    [DataRow("-1, -2, -3", -6)]
    public void Part1Examples(string input, int expected)
    {
        // Act
        var result = Calculations.ResultingFrequencyCommaSeparated(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.ResultingFrequencyLineSeparated(input);

        // Assert
        Assert.AreEqual(525, result);
    }

    [TestMethod]
    [DataRow("+1, -1", 0)]
    [DataRow("+3, +3, +4, -2, -4", 10)]
    [DataRow("-6, +3, +8, +5, -6", 5)]
    [DataRow("+7, +7, -2, -7, -4", 14)]
    public void Part2Examples(string input, int expected)
    {
        // Act
        var result = Calculations.FirstDuplicateFrequencyCommaSeparated(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.FirstDuplicateFrequencyLineSeparated(input);

        // Assert
        Assert.AreEqual(75749, result);
    }
}