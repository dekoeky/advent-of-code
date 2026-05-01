namespace AdventOfCode._2017.Day24;

/// <summary>
/// Year 2017 Day 24 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/24"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var (part1, _) = Calculations.Solve(input);

        // Assert
        Assert.AreEqual(31, part1);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var (part1, _) = Calculations.Solve(input);

        // Assert
        Assert.AreEqual(1511, part1);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var (_, part2) = Calculations.Solve(input);

        // Assert
        Assert.AreEqual(19, part2);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var (_, part2) = Calculations.Solve(input);

        // Assert
        Assert.AreEqual(1471, part2);
    }
}