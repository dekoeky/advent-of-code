namespace AdventOfCode._2017.Day10;

/// <summary>
/// Year 2017 Day 10 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/10"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;
        var n = 5;

        // Act
        var result = Calculations.Part1(input, n);

        // Assert
        Assert.AreEqual(12, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var n = 256;

        // Act
        var result = Calculations.Part1(input, n);

        // Assert
        Assert.AreEqual(62238, result);
    }

    [TestMethod]
    [DataRow("", "a2582a3a0e66e6e86e3812dcb672a272")]
    [DataRow("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
    [DataRow("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
    [DataRow("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
    public void Part2Examples(string input, string expectedHash)
    {
        // Arrange
        var n = 256;

        // Act
        var result = Calculations.Part2(input, n);

        // Assert
        Assert.AreEqual(expectedHash, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var n = 256;

        // Act
        var result = Calculations.Part2(input, n);

        // Assert
        Assert.AreEqual("2b0c9cc0449507a0db3babd57ad9e8d8", result);
    }
}