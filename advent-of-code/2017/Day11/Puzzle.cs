namespace advent_of_code._2017.Day11;

/// <summary>
/// Year 2017 Day 11 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/11"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("ne,ne,ne", 3)]
    [DataRow("ne,ne,sw,sw", 0)]
    [DataRow("ne,ne,s,s", 2)]
    [DataRow("se,sw,se,sw,sw", 3)]
    public void Part1Examples(string input, int expectedDistance)
    {
        // Act
        var result = Calculations.Execute(input, out _);

        // Assert
        Assert.AreEqual(expectedDistance, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Execute(input, out _);

        // Assert
        Assert.AreEqual(715, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        _ = Calculations.Execute(input, out var max);

        // Assert
        Assert.AreEqual(1512, max);
    }
}