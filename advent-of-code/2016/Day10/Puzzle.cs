namespace advent_of_code._2016.Day10;

/// <summary>
/// Year 2016 Day 10 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/10"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Puzzle()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.Part1(input);

        //Assert
        Assert.AreEqual(113, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.Part2(input);

        //Assert
        Assert.AreEqual(12803, result);
    }
}