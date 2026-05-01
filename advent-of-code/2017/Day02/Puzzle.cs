namespace AdventOfCode._2017.Day02;

/// <summary>
/// Year 2017 Day 02 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/2"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example1;

        // Act
        var result = Calculations.Checksum1(input);

        // Assert
        Assert.AreEqual(18, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Checksum1(input);

        // Assert
        Assert.AreEqual(39126, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example2;

        // Act
        var result = Calculations.Checksum2(input);

        // Assert
        Assert.AreEqual(9, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Checksum2(input);

        // Assert
        Assert.AreEqual(258, result);
    }
}