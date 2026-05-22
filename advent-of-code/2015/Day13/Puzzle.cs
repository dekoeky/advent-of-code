namespace advent_of_code._2015.Day13;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.OptimalSeatingHappiness(input);

        // Assert
        Assert.AreEqual(330, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.OptimalSeatingHappiness(input);

        // Assert
        Assert.AreEqual(618, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.OptimalSeatingHappiness(input, true);

        // Assert
        Assert.AreEqual(601, result);
    }
}