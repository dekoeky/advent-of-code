namespace AdventOfCode._2019.Day04;

/// <summary>
/// Year 2019 Day 04 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2019/day/4"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(111111, true)]
    [DataRow(223450, false)]
    [DataRow(123789, false)]
    public void Part1Examples(int input, bool expected)
    {
        // Act
        var result = Calculations.IsValid(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(1640, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(1126, result);
    }
}