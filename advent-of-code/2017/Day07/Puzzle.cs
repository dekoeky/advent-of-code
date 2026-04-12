namespace advent_of_code._2017.Day07;

/// <summary>
/// Year 2017 Day 07 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/7"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;
        var blocks = Calculations.Parse(input);

        // Act
        var result = Calculations.TowerBottom(blocks);

        // Assert
        Assert.AreEqual("tknk", result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var blocks = Calculations.Parse(input);

        // Act
        var result = Calculations.TowerBottom(blocks);

        // Assert
        Assert.AreEqual("hlhomy", result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;
        var blocks = Calculations.Parse(input);

        // Act
        var result = Calculations.Part2(blocks);

        // Assert
        Assert.AreEqual(60, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var blocks = Calculations.Parse(input);

        // Act
        var result = Calculations.Part2(blocks);

        // Assert
        Assert.AreEqual(2392, result);
    }
}