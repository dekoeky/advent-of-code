namespace advent_of_code._2016.Day11;

/// <summary>
/// Year 2016 Day 11 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/11"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Solve(input.ParseState());

        // Assert
        Assert.AreEqual(11, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Solve(input.ParseState());

        // Assert
        Assert.AreEqual(47, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.PuzzlePart2;

        // Act
        var result = Calculations.Solve(input.ParseState());

        // Assert
        Assert.AreEqual(71, result);
    }
}
