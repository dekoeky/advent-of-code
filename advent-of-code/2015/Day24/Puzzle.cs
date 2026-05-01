namespace AdventOfCode._2015.Day24;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;
        var weights = Weights.Parse(input);

        // Act
        var result = Calculations.Solve(weights, 3);

        // Assert
        Assert.AreEqual(99, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var weights = Weights.Parse(input);

        // Act
        var result = Calculations.Solve(weights, 3);

        // Assert
        Assert.AreEqual(10723906903L, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;
        var weights = Weights.Parse(input);

        // Act
        var result = Calculations.Solve(weights, 4);

        // Assert
        Assert.AreEqual(44, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var weights = Weights.Parse(input);

        // Act
        var result = Calculations.Solve(weights, 4);

        // Assert
        Assert.AreEqual(74850409L, result);
    }
}