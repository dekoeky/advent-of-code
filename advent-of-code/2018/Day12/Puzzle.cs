namespace advent_of_code._2018.Day12;

/// <summary>
/// Year 2018 Day 12 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/12"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Act
        var input = Inputs.Example;
        var generations = 20;

        // Act
        var result = Calculations.Part1(input, generations);

        // Assert
        Assert.AreEqual(325, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var generations = 20;

        // Act
        var result = Calculations.Part1(input, generations);

        // Assert
        Assert.AreEqual(3410, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var generations = 50000000000;

        // Act
        var result = Calculations.Part2(input, generations);

        // Assert
        Assert.AreEqual(10333, result);
    }
}