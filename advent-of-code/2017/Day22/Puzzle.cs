namespace AdventOfCode._2017.Day22;

/// <summary>
/// Year 2017 Day 22 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/22"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(70, 41)]
    [DataRow(10000, 5587)]
    public void Part1Examples(int bursts, int expected)
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Perform(input, bursts);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var bursts = 10000;

        // Act
        var result = Calculations.Perform(input, bursts);

        // Assert
        Assert.AreEqual(5176, result);
    }

    [TestMethod]
    [DataRow(100, 26)]
    [DataRow(10000000, 2511944)]
    public void Part2Examples(int bursts, int expected)
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part2(input, bursts);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var bursts = 10000000;

        // Act
        var result = Calculations.Part2(input, bursts);

        // Assert
        Assert.AreEqual(2512017, result);
    }
}