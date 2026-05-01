namespace AdventOfCode._2015.Day03;

[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(2, ">")]
    [DataRow(4, "^>v<")]
    [DataRow(2, "^v^v^v^v^v")]
    public void Part1Examples(int expected, string input)
    {
        // Act
        var result = Calculations.Perform(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Perform(input);

        // Assert
        Assert.AreEqual(2592, result);
    }


    [TestMethod]
    [DataRow(3, "^v")]
    [DataRow(3, "^>v<")]
    [DataRow(11, "^v^v^v^v^v")]
    public void Part2Examples(int expected, string input)
    {
        // Act
        var result = Calculations.Perform2(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Perform2(input);

        // Assert
        Assert.AreEqual(2360, result);
    }
}