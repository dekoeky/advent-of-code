namespace AdventOfCode._2015.Day05;

[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("ugknbfddgicrmopn", true)]
    [DataRow("aaa", true)]
    [DataRow("jchzalrnumimnmhp", false)]
    [DataRow("haegwjzuvuyypxyu", false)]
    [DataRow("dvszwmarrgswjxmb", false)]
    public void Part1Examples(string input, bool expected)
    {
        // Act
        var isNice = input.IsNice();

        // Assert
        Assert.AreEqual(expected, isNice);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var inputs = SplitOn.NewLines(input);

        // Act
        var result = inputs.Count(i => i.IsNice());

        // Assert
        Assert.AreEqual(258, result);
    }

    [TestMethod]
    [DataRow("qjhvhtzxzqqjkmpb", true)]
    [DataRow("xxyxx", true)]
    [DataRow("uurcxstgmygtbstg", false)]
    [DataRow("ieodomkazucvgmuy", false)]
    public void Part2Examples(string input, bool expectedNice)
    {
        // Act
        var result = input.IsNiceV2();

        // Assert
        Assert.AreEqual(expectedNice, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var inputs = SplitOn.NewLines(input);

        // Act
        var result = inputs.Count(i => i.IsNiceV2());

        // Assert
        Assert.AreEqual(53, result);
    }
}