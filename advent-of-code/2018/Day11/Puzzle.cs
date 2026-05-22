namespace advent_of_code._2018.Day11;

/// <summary>
/// Year 2018 Day 11 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/11"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(3, 5, 8, 4)]
    [DataRow(122, 79, 57, -5)]
    [DataRow(217, 196, 39, 0)]
    [DataRow(101, 153, 71, 4)]
    public void PowerLevel(int x, int y, int serial, int expectedPowerLevel)
    {
        // Act
        var result = Calculations.PowerLevel(x, y, serial);

        // Assert
        Assert.AreEqual(expectedPowerLevel, result);
    }

    [TestMethod]
    [DataRow(18, "33,45")]
    [DataRow(42, "21,61")]
    public void Part1Examples(int gridSerial, string expected)
    {
        // Act
        var result = Calculations.Part1(gridSerial);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var gridSerial = 1309;

        // Act
        var result = Calculations.Part1(gridSerial);

        // Assert
        Assert.AreEqual("20,43", result);
    }

    [TestMethod]
    [DataRow(18, "90,269,16")]
    [DataRow(42, "232,251,12")]
    public void Part2Examples(int gridSerial, string expected)
    {
        // Act
        var result = Calculations.Part2(gridSerial);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var gridSerial = 1309;

        // Act
        var result = Calculations.Part2(gridSerial);

        // Assert
        Assert.AreEqual("233,271,13", result);
    }
}