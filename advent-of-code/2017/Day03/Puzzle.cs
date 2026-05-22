namespace advent_of_code._2017.Day03;

/// <summary>
/// Year 2017 Day 03 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/3"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(1, 0)]
    [DataRow(2, 1)]
    [DataRow(3, 1)]
    [DataRow(4, 1)]
    [DataRow(5, 1)]
    [DataRow(6, 1)]
    [DataRow(7, 1)]
    [DataRow(8, 1)]
    [DataRow(9, 1)]
    public void GetLayer(int input, int expectedLayer)
    {
        // Act
        var result = Calculations.GetLayer(input);

        // Assert
        Assert.AreEqual(expectedLayer, result);
    }

    [TestMethod]
    [DataRow(0, 1)]
    [DataRow(1, 9)]
    [DataRow(2, 25)]
    [DataRow(3, 49)]
    public void GetMaxValueOnLayer(int input, int expectedLayer)
    {
        // Act
        var result = Calculations.GetMaxValueOnLayer(input);

        // Assert
        Assert.AreEqual(expectedLayer, result);
    }

    [TestMethod]
    [DataRow(1, 0)]
    [DataRow(12, 3)]
    [DataRow(23, 2)]
    [DataRow(1024, 31)]
    public void Part1Examples(int input, int expected)
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
        var input = 289326;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(419, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = 289326;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(295229, result);
    }
}