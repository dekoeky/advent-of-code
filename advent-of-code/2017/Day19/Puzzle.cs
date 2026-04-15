namespace advent_of_code._2017.Day19;

/// <summary>
/// Year 2017 Day 19 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/19"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.TracePacket(input, out _);

        // Assert
        Assert.AreEqual("ABCDEF", result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.TracePacket(input, out _);

        // Assert
        Assert.AreEqual("DTOUFARJQ", result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        _ = Calculations.TracePacket(input, out var steps);

        // Assert
        Assert.AreEqual(38, steps);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        _ = Calculations.TracePacket(input, out var steps);

        // Assert
        Assert.AreEqual(16642, steps);
    }
}