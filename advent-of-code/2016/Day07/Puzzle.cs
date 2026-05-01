namespace AdventOfCode._2016.Day07;

/// <summary>
/// Year 2016 Day 07 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/7"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("abba[mnop]qrst", true)]
    [DataRow("abcd[bddb]xyyx", false)]
    [DataRow("aaaa[qwer]tyui", false)]
    [DataRow("ioxxoj[asdfgh]zxcvbn", true)]
    public void Part1Example(string input, bool expectedSupportsTls)
    {
        // Act
        var result = IPv7.SupportsTls(input);

        // Assert
        Assert.AreEqual(expectedSupportsTls, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = IPv7.CountTlsSupportingIps(input);

        // Assert
        Assert.AreEqual(115, result);
    }

    [TestMethod]
    [DataRow("aba[bab]xyz", true)]
    [DataRow("xyx[xyx]xyx", false)]
    [DataRow("aaa[kek]eke", true)]
    [DataRow("zazbz[bzb]cdb", true)]
    public void Part2Example(string input, bool expectedSupportsTls)
    {
        // Act
        var result = IPv7.SupportsSsl(input);

        // Assert
        Assert.AreEqual(expectedSupportsTls, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = IPv7.CountSslSupportingIps(input);

        // Assert
        Assert.AreEqual(231, result);
    }
}