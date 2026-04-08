namespace advent_of_code._2016.Day19;

/// <summary>
/// Year 2016 Day 19 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/19"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var elves = 5;

        // Act
        var shortestPath = Calculations.SolvePart1(elves);

        // Assert
        Assert.AreEqual(3, shortestPath);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var elves = 3018458;

        // Act
        var shortestPath = Calculations.SolvePart1(elves);

        // Assert
        Assert.AreEqual(1842613, shortestPath);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var elves = 5;

        // Act
        var shortestPath = Calculations.SolvePart2(elves);

        // Assert
        Assert.AreEqual(2, shortestPath);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var elves = 3018458;

        // Act
        var shortestPath = Calculations.SolvePart2(elves);

        // Assert
        Assert.AreEqual(1424135, shortestPath);
    }
}