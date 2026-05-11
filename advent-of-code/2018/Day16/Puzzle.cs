namespace advent_of_code._2018.Day16;

/// <summary>
/// Year 2018 Day 16 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/16"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(517, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(667, result);
    }
}