namespace advent_of_code._2017.Day21;

/// <summary>
/// Year 2017 Day 21 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/21"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;
        var n = 2;

        // Act
        var result = Calculations.Execute(input, n);

        // Assert
        Assert.AreEqual(12, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var n = 5;

        // Act
        var result = Calculations.Execute(input, n);

        // Assert
        Assert.AreEqual(190, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var n = 18;

        // Act
        var result = Calculations.Execute(input, n);

        // Assert
        Assert.AreEqual(2335049, result);
    }
}