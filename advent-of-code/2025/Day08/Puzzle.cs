namespace advent_of_code._2025.Day08;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        // Arrange
        var input = Inputs.Example;
        var junctionBoxPositions = JunctionBoxPosition.ParseList(input);
        const int connectionsToMake = 10;
        const int nLargestCircuits = 3;

        // Act
        var result = Calculations.Perform(junctionBoxPositions, connectionsToMake, nLargestCircuits);

        // Assert
        Assert.AreEqual(40, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var junctionBoxPositions = JunctionBoxPosition.ParseList(input);
        const int connectionsToMake = 1000;
        const int nLargestCircuits = 3;

        // Act
        var result = Calculations.Perform(junctionBoxPositions, connectionsToMake, nLargestCircuits);

        // Assert
        Console.WriteLine($"Result: {result}");
        Assert.AreEqual(352584, result);
    }

    [TestMethod]
    public void Example2()
    {
        // Arrange
        var input = Inputs.Example;
        var junctionBoxPositions = JunctionBoxPosition.ParseList(input);

        // Act
        var result = Calculations.Perform(junctionBoxPositions, int.MaxValue, -1);

        // Assert
        Assert.AreEqual(25272, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var junctionBoxPositions = JunctionBoxPosition.ParseList(input);

        // Act
        var result = Calculations.Perform(junctionBoxPositions, int.MaxValue, -1);

        // Assert
        Console.WriteLine($"Result: {result}");
        Assert.AreEqual(9617397716, result);
    }
}
