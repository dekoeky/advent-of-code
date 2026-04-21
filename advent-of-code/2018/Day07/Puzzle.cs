namespace advent_of_code._2018.Day07;

/// <summary>
/// Year 2018 Day 07 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/7"/>
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
        Assert.AreEqual("CABDFE", result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual("BHRTWCYSELPUVZAOIJKGMFQDXN", result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;
        var threshold = 2;

        // Act
        var result = Calculations.Part2(input, threshold, Durations.Example);

        // Assert
        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var workers = 5;

        // Act
        var result = Calculations.Part2(input, workers, Durations.Puzzle);

        // Assert
        Assert.AreEqual(959, result);
    }
}