using System.Diagnostics;

namespace advent_of_code._2015.Day14;

[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(Inputs.Comet, 1, 14)]
    [DataRow(Inputs.Dancer, 1, 16)]
    [DataRow(Inputs.Comet, 10, 140)]
    [DataRow(Inputs.Dancer, 10, 160)]
    [DataRow(Inputs.Comet, 11, 140)]
    [DataRow(Inputs.Dancer, 11, 176)]
    public void Part1Examples(string input, int raceTime, int expected)
    {
        // Arrange
        Debug.WriteLine($"Input: {input}");
        Debug.WriteLine($"RaceTime: {raceTime}");

        // Act
        var reindeer = ReindeerInfo.Parse(input);
        var result = reindeer.DistanceAfter(raceTime);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.WinnerByDistanceTraveled(input, 1000);

        // Assert
        Assert.AreEqual(1120, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.WinnerByDistanceTraveled(input, 2503);

        // Assert
        Assert.AreEqual(2640, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.WinnerByPoints(input, 1000);

        // Assert
        Assert.AreEqual(689, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.WinnerByPoints(input, 2503);

        // Assert
        Assert.AreEqual(1102, result);
    }
}
