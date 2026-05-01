namespace AdventOfCode._2020.Day10;

/// <summary>
/// Year 2020 Day 10 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/10"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1ExampleSmall()
    {
        // Arrange
        var input = Inputs.ExampleSmall;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(7 * 5, result);
    }

    [TestMethod]
    public void Part1ExampleBig()
    {
        // Arrange
        var input = Inputs.ExampleBig;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(22 * 10, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(1980, result);
    }

    [TestMethod]
    public void Part2ExampleSmall()
    {
        // Arrange
        var input = Inputs.ExampleSmall;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(8, result);
    }

    [TestMethod]
    public void Part2ExampleBig()
    {
        // Arrange
        var input = Inputs.ExampleBig;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(19208, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(4628074479616, result);
    }
}