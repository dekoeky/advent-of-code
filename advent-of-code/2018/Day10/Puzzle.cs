namespace advent_of_code._2018.Day10;

/// <summary>
/// Year 2018 Day 10 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/10"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Act
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        EqualStrings(result,
            """
            #...#..###
            #...#...#.
            #...#...#.
            #####...#.
            #...#...#.
            #...#...#.
            #...#...#.
            #...#..###
            """);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        EqualStrings(result, // AHZLLCAL
            """
            ..##....#....#..######..#.......#........####.....##....#.....
            .#..#...#....#.......#..#.......#.......#....#...#..#...#.....
            #....#..#....#.......#..#.......#.......#.......#....#..#.....
            #....#..#....#......#...#.......#.......#.......#....#..#.....
            #....#..######.....#....#.......#.......#.......#....#..#.....
            ######..#....#....#.....#.......#.......#.......######..#.....
            #....#..#....#...#......#.......#.......#.......#....#..#.....
            #....#..#....#..#.......#.......#.......#.......#....#..#.....
            #....#..#....#..#.......#.......#.......#....#..#....#..#.....
            #....#..#....#..######..######..######...####...#....#..######
            """);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(10333, result);
    }

    // TODO: Consider making a performant, reusable assert extension for this.
    private static void EqualStrings(string result, string expected) => Assert.AreEqual(
            expected.ReplaceLineEndings().Trim(),
            result.ReplaceLineEndings().Trim());
}