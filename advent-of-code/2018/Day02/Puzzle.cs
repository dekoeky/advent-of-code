namespace advent_of_code._2018.Day02;

/// <summary>
/// Year 2018 Day 02 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/2"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("abcdef", false, false)]
    [DataRow("bababc", true, true)]
    [DataRow("abbcde", true, false)]
    [DataRow("abcccd", false, true)]
    [DataRow("aabcdd", true, false)]
    [DataRow("abcdee", true, false)]
    [DataRow("ababab", false, true)]
    public void Analyze(string input, bool expectedTwo, bool expectedThree)
    {
        // Act
        var (containsTwos, containsThrees) = Calculations.Analyze(input);

        // Assert
        Assert.AreEqual(expectedTwo, containsTwos);
        Assert.AreEqual(expectedThree, containsThrees);
    }

    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(12, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(7657, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example2;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual("fgij", result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual("ivjhcadokeltwgsfsmqwrbnuy", result);
    }
}