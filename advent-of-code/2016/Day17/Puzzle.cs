namespace AdventOfCode._2016.Day17;

/// <summary>
/// Year 2016 Day 17 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/17"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("hijkl", "NO RESULT")]
    [DataRow("ihgpwlah", "DDRRRD")]
    [DataRow("kglvqrro", "DDUDRLRRUDRD")]
    [DataRow("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")]
    public void Part1Examples(string passCode, string expectedShortestPath)
    {
        // Act
        var shortestPath = Calculations.ShortestPath(passCode);

        // Assert
        Assert.AreEqual(expectedShortestPath, shortestPath);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var passCode = "ioramepc";

        // Act
        var result = Calculations.ShortestPath(passCode);

        // Assert
        Assert.AreEqual("RDDRULDDRR", result);
    }

    [TestMethod]
    [DataRow("ihgpwlah", 370)]
    [DataRow("kglvqrro", 492)]
    [DataRow("ulqzkmiv", 830)]
    public void Part2Examples(string passCode, int expectedShortestPath)
    {
        // Act
        var longestPath = Calculations.LongestPath(passCode);

        // Assert
        Assert.AreEqual(expectedShortestPath, longestPath.Length);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var passCode = "ioramepc";

        // Act
        var longestPath = Calculations.LongestPath(passCode);

        // Assert
        Assert.AreEqual(766, longestPath.Length);
    }
}