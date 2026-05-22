namespace advent_of_code._2016.Day03;

/// <summary>
/// Year 2016 Day 03 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/3"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void IsValid()
    {
        // Arrange
        var expected = false;
        var input = Inputs.Example;
        var triangle = ArrayParser.Part1(input).First();

        // Act
        var result = triangle.IsValid();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var triangles = ArrayParser.Part1(input);

        // Act
        var result = triangles.Count(t => t.IsValid());

        // Assert
        Assert.AreEqual(993, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var triangles = ArrayParser.Part2(input);

        // Act
        var result = triangles.Count(t => t.IsValid());

        // Assert
        Assert.AreEqual(1849, result);
    }
}