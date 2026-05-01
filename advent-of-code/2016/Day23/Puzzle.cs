namespace AdventOfCode._2016.Day23;

/// <summary>
/// Year 2016 Day 23 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/23"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var eggs = 7;

        // Act
        var result = Calculations.Calculate(eggs);

        // Assert
        Assert.AreEqual(10661, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var eggs = 12;

        // Act
        var result = Calculations.Calculate(eggs);

        // Assert
        Assert.AreEqual(479007221, result);
    }
}