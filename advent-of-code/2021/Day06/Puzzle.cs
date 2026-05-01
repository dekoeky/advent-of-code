namespace AdventOfCode._2021.Day06;

/// <summary>
/// Year 2021 Day 06 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2021/day/6"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(Inputs.Example, 18, 26)]
    [DataRow(Inputs.Example, 80, 5934)]
    public void Part1Examples(string input, int days, int expected)
    {
        // Act
        var result = Calculations.CountTotalFish(input, days);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var days = 80;

        // Act
        var result = Calculations.CountTotalFish(input, days);

        // Assert
        Assert.AreEqual(343441, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;
        var days = 256;

        // Act
        var result = Calculations.CountTotalFish(input, days);

        // Assert
        Assert.AreEqual(26984457539, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var days = 256;

        // Act
        var result = Calculations.CountTotalFish(input, days);

        // Assert
        Assert.AreEqual(1569108373832, result);
    }
}