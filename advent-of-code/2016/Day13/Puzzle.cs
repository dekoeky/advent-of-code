namespace AdventOfCode._2016.Day13;

/// <summary>
/// Year 2016 Day 13 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/13"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var fav = 10;
        var target = (7, 4);

        // Act
        var result = Calculations.Part1(fav, target);

        // Assert
        Assert.AreEqual(11, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var fav = 1350;
        var target = (31, 39);

        // Act
        var result = Calculations.Part1(fav, target);

        // Assert
        Assert.AreEqual(92, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var fav = 1350;
        var maxSteps = 50;

        // Act
        var result = Calculations.Part2(fav, maxSteps);

        // Assert
        Assert.AreEqual(124, result);
    }
}