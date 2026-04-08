namespace advent_of_code._2015.Day11;

[TestClass]
public class Puzzle
{
    private const string SolutionPart1 = "hepxxyzz";

    [TestMethod]
    [DataRow("hijklmmn", true)]
    [DataRow("abbceffg", false)]
    public void FirstRequirement(string input, bool expected)
    {
        // Act
        var result = PasswordRequirements.FirstRequirement(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("hijklmmn", false)]
    public void SecondRequirement(string input, bool expected)
    {
        // Act
        var result = PasswordRequirements.SecondRequirement(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("abbceffg", true)]
    [DataRow("abbcegjk", false)]
    public void ThirdRequirement(string input, bool expected)
    {
        // Act
        var result = PasswordRequirements.ThirdRequirement(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("abcdefgh", "abcdffaa")]
    [DataRow("ghijklmn", "ghjaabcc")]
    public void Part1Example(string input, string expected)
    {
        // Act
        var newPassword = NewPasswordFinder.FindNext(input);

        // Assert
        Assert.AreEqual(expected, newPassword);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var newPassword = NewPasswordFinder.FindNext(input);

        // Assert
        Assert.AreEqual(SolutionPart1, newPassword);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = SolutionPart1;

        // Act
        var newPassword = NewPasswordFinder.FindNext(input);

        // Assert
        Assert.AreEqual("heqaabcc", newPassword);
    }
}