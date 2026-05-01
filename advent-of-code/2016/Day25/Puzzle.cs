namespace AdventOfCode._2016.Day25;

/// <summary>
/// Year 2016 Day 25 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/25"/>
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
        Assert.AreEqual(196, result);
    }
}