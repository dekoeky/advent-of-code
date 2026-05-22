namespace advent_of_code._2018.Day14;

/// <summary>
/// Year 2018 Day 14 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/14"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(9, 5158916779)]
    [DataRow(5, 0124515891)]
    [DataRow(18, 9251071085)]
    [DataRow(2018, 5941429882)]
    public void Part1Examples(int recipes, long expected)
    {
        // Act
        var result = Calculations.Part1(recipes);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = 890691;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(8176111038, result);
    }

    [TestMethod]
    [DataRow("51589", 9)]
    [DataRow("01245", 5)]
    [DataRow("92510", 18)]
    [DataRow("59414", 2018)]
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
        var input = "890691";

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(20225578, result);
    }
}