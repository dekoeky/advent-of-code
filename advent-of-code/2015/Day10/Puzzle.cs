namespace AdventOfCode._2015.Day10;

[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("1", "11")]
    [DataRow("11", "21")]
    [DataRow("21", "1211")]
    [DataRow("1211", "111221")]
    [DataRow("111221", "312211")]
    public void Part1Examples(string input, string expected)
    {
        // Act
        var result = Calculations.Expand(input, 1);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Expand(input, 40).Length;

        // Assert
        Assert.AreEqual(252594, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Expand(input, 50).Length;

        // Assert
        Assert.AreEqual(3579328, result);
    }
}