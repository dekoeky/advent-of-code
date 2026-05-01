namespace AdventOfCode._2019.Day02;

/// <summary>
/// Year 2019 Day 02 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2019/day/2"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(Inputs.Example, 3500)]
    [DataRow("1,0,0,0,99", 2)]
    [DataRow("2,3,0,3,99", 2)]
    [DataRow("2,4,4,5,99,0", 2)]
    [DataRow("1,1,1,4,99,5,6,0,99", 30)]
    public void Part1Examples(string input, int expected)
    {
        // Arrange
        var program = Calculations.Parse(input);

        // Act
        var result = Calculations.Part1(program);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var program = Calculations.Parse(input);

        // Act
        var result = Calculations.Part1(program, 12, 02);

        // Assert
        Assert.AreEqual(6327510, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var program = Calculations.Parse(input);
        var target = 19690720;

        // Act
        var result = Calculations.Part2(program, target);

        // Assert
        Assert.AreEqual(4112, result);
    }
}