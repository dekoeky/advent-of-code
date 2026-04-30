namespace advent_of_code._2021.Day08;

/// <summary>
/// Year 2021 Day 08 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2021/day/8"/>
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
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(26, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(349, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(61229, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(1070957, result);
    }
}