namespace advent_of_code._2020.Day03;

/// <summary>
/// Year 2020 Day 03 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/3"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(156, result);
    }

    [TestMethod]
    public void Part2Examples()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(2 * 7 * 3 * 4 * 2, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(3521829480, result);
    }
}