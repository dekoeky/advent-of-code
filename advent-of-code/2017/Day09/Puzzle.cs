namespace AdventOfCode._2017.Day09;

/// <summary>
/// Year 2017 Day 09 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/9"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("{}", 1)]
    [DataRow("{{{}}}", 6)]
    [DataRow("{{},{}}", 5)]
    [DataRow("{{{},{},{{}}}}", 16)]
    [DataRow("{<a>,<a>,<a>,<a>}", 1)]
    [DataRow("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
    [DataRow("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
    [DataRow("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
    public void Part1Examples(string input, int expectedScore)
    {
        // Act
        var result = Calculations.Solve(input, out _);

        // Assert
        Assert.AreEqual(expectedScore, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Solve(input, out _);

        // Assert
        Assert.AreEqual(12396, result);
    }

    [TestMethod]
    [DataRow("<>", 0)]
    [DataRow("<random characters>", 17)]
    [DataRow("<<<<>", 3)]
    [DataRow("<{!>}>", 2)]
    [DataRow("<!!>", 0)]
    [DataRow("<!!!>>", 0)]
    [DataRow("<{o\"i!a,<{i<a>", 10)]
    public void Part2Examples(string input, int expectedGarbabe)
    {
        // Act
        _ = Calculations.Solve(input, out var garbage);

        // Assert
        Assert.AreEqual(expectedGarbabe, garbage);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        _ = Calculations.Solve(input, out var garbage);

        // Assert
        Assert.AreEqual(6346, garbage);
    }
}