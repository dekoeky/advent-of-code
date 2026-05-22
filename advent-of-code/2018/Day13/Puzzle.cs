namespace advent_of_code._2018.Day13;

/// <summary>
/// Year 2018 Day 13 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/13"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Act
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual("7,3", result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual("14,42", result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example2;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual("6,4", result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual("8,7", result);
    }
}