namespace advent_of_code._2020.Day15;

/// <summary>
/// Year 2020 Day 15 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/15"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("0,3,6", 436)]
    [DataRow("1,3,2", 1)]
    [DataRow("2,1,3", 10)]
    [DataRow("1,2,3", 27)]
    [DataRow("2,3,1", 78)]
    [DataRow("3,2,1", 438)]
    [DataRow("3,1,2", 1836)]
    public void Part1Examples(string input, int expected)
    {
        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(289, result);
    }

    [TestMethod]
    [DataRow("0,3,6", 175594)]
    [DataRow("1,3,2", 2578)]
    [DataRow("2,1,3", 3544142)]
    [DataRow("1,2,3", 261214)]
    [DataRow("2,3,1", 6895259)]
    [DataRow("3,2,1", 18)]
    [DataRow("3,1,2", 362)]
    public void Part2Examples(string input, int expected)
    {
        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(1505722, result);
    }
}