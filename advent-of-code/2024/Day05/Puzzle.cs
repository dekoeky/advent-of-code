namespace advent_of_code._2024.Day05;

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
        Assert.AreEqual(143, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Input.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(5391, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Input.Example;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(123, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Input.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(6142, result);
    }
}