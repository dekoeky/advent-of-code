namespace advent_of_code._2017.Day04;

/// <summary>
/// Year 2017 Day 04 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/4"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("aa bb cc dd ee", true)]
    [DataRow("aa bb cc dd aa", false)]
    [DataRow("aa bb cc dd aaa", true)]
    public void Part1Examples(string input, bool expectedValid)
    {
        // Act
        var result = Calculations.IsValidPart1(input);

        // Assert
        Assert.AreEqual(expectedValid, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.CountValid(input, Calculations.IsValidPart1);

        // Assert
        Assert.AreEqual(325, result);
    }

    [TestMethod]
    [DataRow("abcde fghij", true)]
    [DataRow("abcde xyz ecdab", false)]
    [DataRow("a ab abc abd abf abj", true)]
    [DataRow("iiii oiii ooii oooi oooo", true)]
    [DataRow("oiii ioii iioi iiio", false)]
    public void Part2Examples(string input, bool expectedValid)
    {
        // Act
        var result = Calculations.IsValidPart2(input);

        // Assert
        Assert.AreEqual(expectedValid, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.CountValid(input, Calculations.IsValidPart2);

        // Assert
        Assert.AreEqual(119, result);
    }
}