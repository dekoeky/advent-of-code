namespace advent_of_code._2018.Day20;

/// <summary>
/// Year 2018 Day 18 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/18"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("^WNE$", 3)]
    [DataRow("^ENWWW(NEEE|SSE(EE|N))$", 10)]
    [DataRow("^ENNWSWW(NEWS|)SSSEEN(WNSE|)EE(SWEN|)NNN$", 18)]
    [DataRow("^ESSWWN(E|NNENN(EESS(WNSE|)SSS|WWWSSSSE(SW|NNNE)))$", 23)]
    [DataRow("^WSSEESWWWNW(S|NENNEEEENN(ESSSSW(NWSW|SSEN)|WSWWN(E|WWS(E|SS))))$", 31)]
    public void Part1Examples(string input, int expected)
    {
        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(3415, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(8583, result);
    }
}