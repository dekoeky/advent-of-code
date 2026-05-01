namespace AdventOfCode._2020.Day01;

/// <summary>
/// Year 2020 Day 01 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/1"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = SplitOn.NewLines(Inputs.Example)
            .Select(int.Parse)
            .ToArray();

        // Act
        var result = Calculations.Part1(input, 2020);

        // Assert
        Assert.AreEqual(514579, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = SplitOn.NewLines(Inputs.Puzzle)
            .Select(int.Parse)
            .ToArray();

        // Act
        var result = Calculations.Part1(input, 2020);

        // Assert
        Assert.AreEqual(567171, result);
    }

    [TestMethod]
    public void Part2Examples()
    {
        // Arrange
        var input = SplitOn.NewLines(Inputs.Example)
            .Select(int.Parse)
            .ToArray();

        // Act
        var result = Calculations.Part2(input, 2020);

        // Assert
        Assert.AreEqual(241861950, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = SplitOn.NewLines(Inputs.Puzzle)
            .Select(int.Parse)
            .ToArray();

        // Act
        var result = Calculations.Part2(input, 2020);

        // Assert
        Assert.AreEqual(212428694, result);
    }
}