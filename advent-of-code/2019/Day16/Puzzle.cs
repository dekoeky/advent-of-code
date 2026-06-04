namespace advent_of_code._2019.Day16;

/// <summary>
/// Year 2019 Day 16 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2019/day/16"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("12345678", 4, 01029498)]
    [DataRow("80871224585914546619083218645595", 100, 24176176)]
    [DataRow("19617804207202209144916044189917", 100, 73745418)]
    [DataRow("69317163492948606335995924319873", 100, 52432133)]
    public void Part1Examples(string input, int phases, int expected)
    {
        // Act
        var result = Calculations.Part1(input, phases);

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
        Assert.AreEqual(29795507, result);
    }

    [TestMethod]
    [DataRow("03036732577212944063491565474664", 84462026)]
    [DataRow("02935109699940807407585447034323", 78725270)]
    [DataRow("03081770884921959731165446850517", 53553731)]
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
        Assert.AreEqual(-1, result);
    }
}
