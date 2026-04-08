namespace advent_of_code._2015.Day23;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;
        var registerSeedValues = new Dictionary<char, uint>()
        {
            { 'a', 0 },
            { 'b', 0 },
        };

        // Act
        var result = Calculations.Perform(input, 'a', registerSeedValues);

        // Assert
        Assert.AreEqual(2u, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var registerSeedValues = new Dictionary<char, uint>()
        {
            { 'a', 0 },
            { 'b', 0 },
        };

        // Act
        var result = Calculations.Perform(input, 'b', registerSeedValues);

        // Assert
        Assert.AreEqual(170u, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var registerSeedValues = new Dictionary<char, uint>()
        {
            { 'a', 1 },
            { 'b', 0 },
        };

        // Act
        var result = Calculations.Perform(input, 'b', registerSeedValues);

        // Assert
        Assert.AreEqual(247u, result);
    }
}