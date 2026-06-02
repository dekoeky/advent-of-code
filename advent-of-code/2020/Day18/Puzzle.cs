namespace advent_of_code._2020.Day18;

/// <summary>
/// Year 2020 Day 18 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/18"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("2 * 3 + (4 * 5)", 26)]
    [DataRow("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
    [DataRow("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
    [DataRow("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
    public void Part1Examples(string input, long expected)
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
        Assert.AreEqual(21022630974613, result);
    }

    [TestMethod]

    [DataRow("1 + (2 * 3) + (4 * (5 + 6))", 51)]
    [DataRow("2 * 3 + (4 * 5)", 46)]
    [DataRow("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
    [DataRow("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
    [DataRow("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
    public void Part2Examples(string input, long expected)
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
        Assert.AreEqual(169899524778212, result);
    }
}