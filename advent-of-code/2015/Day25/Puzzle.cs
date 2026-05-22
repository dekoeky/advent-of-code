namespace advent_of_code._2015.Day25;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Puzzle()
    {
        // Act
        var result = Calculations.Solve(2947, 3029);

        // Assert
        Assert.AreEqual(19980801L, result);
    }
}