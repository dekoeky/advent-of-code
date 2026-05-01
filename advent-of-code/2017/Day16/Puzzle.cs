namespace AdventOfCode._2017.Day16;

/// <summary>
/// Year 2017 Day 16 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/16"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var instructions = Inputs.Example;
        var start = "abcde";

        // Act
        var result = Calculations.Part1(start, instructions);

        // Assert
        Assert.AreEqual("baedc", result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var start = "abcdefghijklmnop";

        // Act
        var result = Calculations.Part1(start, input);

        // Assert
        Assert.AreEqual("fgmobeaijhdpkcln", result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var instructions = Inputs.Puzzle;
        var start = "abcdefghijklmnop";

        // Act
        var result = Calculations.Part2(start, instructions);

        // Assert
        Assert.AreEqual("lgmkacfjbopednhi", result);
    }
}