namespace advent_of_code._2024.Day11;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Input.Example;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(55312, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Input.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(239714, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Input.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(284973560658514, result);
    }
}