namespace advent_of_code._2016.Day06;

/// <summary>
/// Year 2016 Day 06 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/6"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Examples()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var password = Calculations.ErrorCorrect1(input);

        // Assert
        Assert.AreEqual("easter", password);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var password = Calculations.ErrorCorrect1(input);

        // Assert
        Assert.AreEqual("qrqlznrl", password);
    }

    [TestMethod]
    public void Part2Examples()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var password = Calculations.ErrorCorrect2(input);

        // Assert
        Assert.AreEqual("advent", password);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var password = Calculations.ErrorCorrect2(input);

        // Assert
        Assert.AreEqual("kgzdfaon", password);
    }
}
