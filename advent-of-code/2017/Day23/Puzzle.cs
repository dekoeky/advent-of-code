namespace advent_of_code._2017.Day23;

/// <summary>
/// Year 2017 Day 23 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/23"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var instructions = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(instructions);

        // Assert
        Assert.AreEqual(9409, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var instructions = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(instructions);

        // Assert
        Assert.AreEqual(913, result);
    }
}