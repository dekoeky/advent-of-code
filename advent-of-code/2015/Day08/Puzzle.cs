namespace AdventOfCode._2015.Day08;

[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("""
             ""
             """, 2, 0)]
    [DataRow("""
             "abc"
             """, 5, 3)]
    [DataRow("""
             "aaa\"aaa"
             """, 10, 7)]
    [DataRow("""
             "\x27"
             """, 6, 1)]
    public void Part1Examples(string input, int expectedCodeLength, int expectedStringLength)
    {
        // Act
        var codeLength = input.Length;
        int stringLength = Calculations.GetStringLength(input);

        // Assert
        Assert.AreEqual(expectedCodeLength, codeLength);
        Assert.AreEqual(expectedStringLength, stringLength);
    }

    [TestMethod]
    [DataRow("""
             ""
             """, 2 - 0)]
    [DataRow("""
             "abc"
             """, 5 - 3)]
    [DataRow("""
             "aaa\"aaa"
             """, 10 - 7)]
    [DataRow("""
             "\x27"
             """, 6 - 1)]
    public void Part1Examples(string input, int expectedDelta)
    {
        // Act;
        int delta = Calculations.Delta1(input);

        // Assert
        Assert.AreEqual(expectedDelta, delta);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var lines = SplitOn.NewLines(input);

        // Act
        int delta = lines.Sum(Calculations.Delta1);

        // Assert
        Assert.AreEqual(1371, delta);
    }

    [TestMethod]
    [DataRow("""
             ""
             """, 6 - 2)]
    [DataRow("""
             "abc"
             """, 9 - 5)]
    [DataRow("""
             "aaa\"aaa"
             """, 16 - 10)]
    [DataRow("""
             "\x27"
             """, 11 - 6)]
    public void Part2Example(string input, int expectedEncodedLength)
    {
        // Act
        var encodedLength = Calculations.Delta2(input);

        // Assert
        Assert.AreEqual(expectedEncodedLength, encodedLength);
    }

    [TestMethod]
    public void Puzzle2()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var lines = SplitOn.NewLines(input);

        // Act
        int delta = lines.Sum(Calculations.Delta2);

        // Assert
        Assert.AreEqual(2117, delta);
    }
}