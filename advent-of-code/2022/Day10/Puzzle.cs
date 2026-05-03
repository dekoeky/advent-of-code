namespace advent_of_code._2022.Day10;

/// <summary>
/// Year 2020 Day 10 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/10"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(13140, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(13060, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Debug.WriteLine(result);
        AreEqual(
            """
            ##..##..##..##..##..##..##..##..##..##..
            ###...###...###...###...###...###...###.
            ####....####....####....####....####....
            #####.....#####.....#####.....#####.....
            ######......######......######......####
            #######.......#######.......#######.....
            """, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Debug.WriteLine(result);
        AreEqual(
            """
            ####...##.#..#.###..#..#.#....###..####.
            #.......#.#..#.#..#.#..#.#....#..#....#.
            ###.....#.#..#.###..#..#.#....#..#...#..
            #.......#.#..#.#..#.#..#.#....###...#...
            #....#..#.#..#.#..#.#..#.#....#.#..#....
            #.....##...##..###...##..####.#..#.####.
            """, result); // FJUBULRZ
    }

    private static void AreEqual(string expected, string actual)
        => Assert.AreEqual(
            expected.ReplaceLineEndings().Trim(),
            actual.ReplaceLineEndings().Trim());
}