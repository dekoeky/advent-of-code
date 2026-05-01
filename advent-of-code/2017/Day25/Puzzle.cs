namespace AdventOfCode._2017.Day25;

/// <summary>
/// Year 2017 Day 25 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/25"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Execute(input);

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Execute(input);

        // Assert
        Assert.AreEqual(633, result);
    }

    // No Part 2
}