namespace advent_of_code._2024.Day18;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Input.Example;

        // Act
        var result = Calculations.Part1(input, 7, 12);

        // Assert
        Assert.AreEqual(22, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Input.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(354, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Input.Example;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(2858, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Input.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(6227018762750, result);
    }
}