namespace advent_of_code._2016.Day09;

/// <summary>
/// Year 2016 Day 09 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/9"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("ADVENT", "ADVENT")]
    [DataRow("A(1x5)BC", "ABBBBBC")]
    [DataRow("(3x3)XYZ", "XYZXYZXYZ")]
    [DataRow("A(2x2)BCD(2x2)EFG", "ABCBCDEFEFG")]
    [DataRow("(6x1)(1x3)A", "(1x3)A")]
    [DataRow("X(8x2)(3x3)ABCY", "X(3x3)ABC(3x3)ABCY")]
    public void Part1Examples(string input, string expected)
    {
        // Act
        var result = Calculations.DecompressV1(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.DecompressV1(input);
        var count = result.Count(c => !char.IsWhiteSpace(c));

        // Assert
        Assert.AreEqual(97714, count);
    }

    [TestMethod]
    [DataRow("(3x3)XYZ", 9L)]
    [DataRow("X(8x2)(3x3)ABCY", 20L)]
    [DataRow("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920L)]
    [DataRow("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445L)]
    public void Part2Examples(string input, long expected)
    {
        // Act
        var result = Calculations.DecompressV2(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.DecompressV2(input);

        // Assert
        Assert.AreEqual(10762972461L, result);
    }
}