namespace advent_of_code._2025.Day09;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(50, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(4767418746, result);
    }

    [TestMethod]
    public void Example2()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(24, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(1461987144, result);
    }
}