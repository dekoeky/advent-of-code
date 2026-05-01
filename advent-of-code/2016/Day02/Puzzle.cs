namespace AdventOfCode._2016.Day02;

/// <summary>
/// Year 2016 Day 02 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/2"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;
        var keypad = Keypad.Simple;
        var startKey = '5';

        // Act
        var result = Calculations.FindBathroomCode(input, keypad, startKey);

        // Assert
        Assert.AreEqual("1985", result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var keypad = Keypad.Simple;
        var startKey = '5';

        // Act
        var result = Calculations.FindBathroomCode(input, keypad, startKey);

        // Assert
        Assert.AreEqual("98575", result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;
        var keypad = Keypad.Advanced;
        var startKey = '5';

        // Act
        var result = Calculations.FindBathroomCode(input, keypad, startKey);

        // Assert
        Assert.AreEqual("5DB3", result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var keypad = Keypad.Advanced;
        var startKey = '5';

        // Act
        var result = Calculations.FindBathroomCode(input, keypad, startKey);

        // Assert
        Assert.AreEqual("CD8D4", result);
    }
}