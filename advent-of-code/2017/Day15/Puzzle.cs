namespace AdventOfCode._2017.Day15;

/// <summary>
/// Year 2017 Day 15 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/15"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(65, 8921, 5, 1)]
    [DataRow(65, 8921, 40_000_000, 588)]
    public void Part1Examples(int startA, int startB, int n, int expectedMatches)
    {
        // Act
        var result = Calculations.Part1(startA, startB, n);

        // Assert
        Assert.AreEqual(expectedMatches, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        int startA = 516;
        int startB = 190;
        int n = 40_000_000;

        // Act
        var result = Calculations.Part1(startA, startB, n);

        // Assert
        Assert.AreEqual(597, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        int startA = 516;
        int startB = 190;
        int n = 5_000_000;

        // Act
        var result = Calculations.Part2(startA, startB, n);

        // Assert
        Assert.AreEqual(303, result);
    }
}
