namespace advent_of_code._2022.Day13;

/// <summary>
/// Year 2022 Day 13 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2022/day/13"/>
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
        Assert.AreEqual(13, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(5506, result);
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