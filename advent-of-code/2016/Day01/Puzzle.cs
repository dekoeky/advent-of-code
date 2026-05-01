namespace AdventOfCode._2016.Day01;

/// <summary>
/// Year 2016 Day 01 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/1"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("R2, L3", 5)]
    [DataRow("R2, R2, R2", 2)]
    [DataRow("R5, L5, R5, R3", 12)]
    public void Part1Examples(string input, int expectedBlocksAway)
    {
        // Act
        var result = Calculations.BlocksAwayAfterFollowingInstructions(input);

        // Assert
        Assert.AreEqual(expectedBlocksAway, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.BlocksAwayAfterFollowingInstructions(input);

        // Assert
        Assert.AreEqual(234, result);
    }

    [TestMethod]
    [DataRow("R8, R4, R4, R8", 4)]
    public void Part2Example(string input, int expectedBlocksAway)
    {
        // Act
        var result = Calculations.BlocksAwayAfterSecondVisit(input);

        // Assert
        Assert.AreEqual(expectedBlocksAway, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.BlocksAwayAfterSecondVisit(input);

        // Assert
        Assert.AreEqual(113, result);
    }
}
