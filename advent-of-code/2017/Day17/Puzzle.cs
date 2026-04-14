namespace advent_of_code._2017.Day17;

/// <summary>
/// Year 2017 Day 17 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/17"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        int steps = 3;
        int n = 2017;

        // Act
        var result = Calculations.Part1(steps, n);

        // Assert
        Assert.AreEqual(638, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        int steps = 382;
        int n = 2017;

        // Act
        var result = Calculations.Part1(steps, n);

        // Assert
        Assert.AreEqual(1561, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        int steps = 382;
        int n = 50000000;

        // Act
        var result = Calculations.Part2(steps, n);

        // Assert
        Assert.AreEqual(33454823, result);
    }
}