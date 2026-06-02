namespace advent_of_code._2023.Day08;

[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(Inputs.Example1, 2)]
    [DataRow(Inputs.Example2, 6)]
    public void Part1Examples(string input, int expected)
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
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(20659, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example3;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(15690466351717, result);
    }
}