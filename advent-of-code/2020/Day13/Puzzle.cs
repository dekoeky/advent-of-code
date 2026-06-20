namespace advent_of_code._2020.Day13;

/// <summary>
/// Year 2020 Day 13 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/13"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(59 * 5, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(2095, result);
    }

    [TestMethod]
    [DataRow("17,x,13,19", 3417)]
    [DataRow("67,7,59,61", 754018)]
    [DataRow("67,x,7,59,61", 779210)]
    [DataRow("67,7,x,59,61", 1261476)]
    [DataRow("1789,37,47,1889", 1202161486)]
    public void Part2Examples(string input, long expected)
    {
        // Act
        var result = Calculations.Part2Internal(input);

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
        Assert.AreEqual(598411311431841, result);
    }
}