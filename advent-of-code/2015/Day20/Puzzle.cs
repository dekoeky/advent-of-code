namespace AdventOfCode._2015.Day20;

[TestClass]
public class Puzzle
{
    private const int Input = 36000000;

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        int visits = 10;

        // Act
        var result = Calculations.Part1(Input, visits);

        // Assert
        Assert.AreEqual(831600, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var visits = 11;
        var limit = 50;

        // Act
        var result = Calculations.Part2(Input, visits, limit);

        // Assert
        Assert.AreEqual(884520, result);
    }
}