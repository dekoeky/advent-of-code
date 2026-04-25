namespace advent_of_code._2022.Day07;

/// <summary>
/// Year 2022 Day 07 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2022/day/7"/>
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
        Assert.AreEqual(95437, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(1175, result);
    }

    [TestMethod]
    public void Part2Examples()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(24933642, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(3866390, result);
    }
}