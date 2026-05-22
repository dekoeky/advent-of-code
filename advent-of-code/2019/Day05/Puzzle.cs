namespace advent_of_code._2019.Day05;

/// <summary>
/// Year 2019 Day 05 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2019/day/5"/>
/// <seealso cref="Day02.Puzzle"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Execute(input, 1);

        // Assert
        Assert.AreEqual(6731945, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var puzzleInput = Inputs.Puzzle;

        // Act
        var result = Calculations.Execute(puzzleInput, 5);

        // Assert
        Assert.AreEqual(9571668, result);
    }
}