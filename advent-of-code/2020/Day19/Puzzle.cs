namespace advent_of_code._2020.Day19;

/// <summary>
/// Year 2020 Day 19 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/19"/>
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
        Assert.AreEqual(00000, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(00000, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(00000, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(00000, result);
    }
}
