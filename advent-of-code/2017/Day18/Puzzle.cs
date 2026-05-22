namespace advent_of_code._2017.Day18;

/// <summary>
/// Year 2017 Day 18 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/18"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var instructions = Inputs.Example;

        // Act
        var result = Calculations.Part1(instructions);

        // Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var instructions = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(instructions);

        // Assert
        Assert.AreEqual(1187, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var instructions = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(instructions);

        // Assert
        Assert.AreEqual(5969, result);
    }
}