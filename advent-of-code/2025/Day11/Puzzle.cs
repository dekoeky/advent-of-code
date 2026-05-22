namespace advent_of_code._2025.Day11;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        // Arrange
        var input = Inputs.Example1;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Console.WriteLine($"Result: {result}");
        Assert.AreEqual(423, result);
    }

    [TestMethod]
    public void Example2()
    {
        // Arrange
        var input = Inputs.Example2;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(333657640517376, result);
    }
}