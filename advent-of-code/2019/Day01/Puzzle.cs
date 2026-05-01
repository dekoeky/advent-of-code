namespace AdventOfCode._2019.Day01;

/// <summary>
/// Year 2019 Day 01 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2019/day/1"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(12, 2)]
    [DataRow(14, 2)]
    [DataRow(1969, 654)]
    [DataRow(100756, 33583)]
    public void Part1Examples(int mass, int expectedFuel)
    {
        // Act
        var fuel = Calculations.FuelRequired(mass);

        // Assert
        Assert.AreEqual(expectedFuel, fuel);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var masses = SplitOn.NewLines(input).Select(int.Parse);

        // Act
        var fuel = masses.Sum(Calculations.FuelRequired);

        // Assert
        Assert.AreEqual(3323874, fuel);
    }

    [TestMethod]
    [DataRow(100756, 50346)]
    [DataRow(1969, 966)]
    public void Part2Examples(int mass, int expected)
    {
        // Act
        var result = Calculations.FuelRequiredRecursive(mass);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var masses = SplitOn.NewLines(input).Select(int.Parse);

        // Act
        var fuel = masses.Sum(Calculations.FuelRequiredRecursive);

        // Assert
        Assert.AreEqual(4982961, fuel);
    }
}