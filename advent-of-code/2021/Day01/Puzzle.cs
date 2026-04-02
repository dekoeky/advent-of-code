using advent_of_code.Helpers;

namespace advent_of_code._2021.Day01;

/// <summary>
/// Year 2021 Day 01 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2021/day/1"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = SplitOn.NewLines(Inputs.Example)
            .Select(int.Parse)
            .ToArray();

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = SplitOn.NewLines(Inputs.Puzzle)
            .Select(int.Parse)
            .ToArray();

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(1154, result);
    }

    [TestMethod]
    public void Part2Examples()
    {
        // Arrange
        var input = SplitOn.NewLines(Inputs.Example)
            .Select(int.Parse)
            .ToArray();

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = SplitOn.NewLines(Inputs.Puzzle)
            .Select(int.Parse)
            .ToArray();

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(1127, result);
    }
}