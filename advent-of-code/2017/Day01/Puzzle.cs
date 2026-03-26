namespace advent_of_code._2017.Day01;

/// <summary>
/// Year 2017 Day 01 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2017/day/1"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("1122", 3)]
    [DataRow("1111", 4)]
    [DataRow("1234", 0)]
    [DataRow("91212129", 9)]
    public void Part1Examples(string input, int expected)
    {
        //Act
        var result = Calculations.Perform(input, +1);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.Perform(input, +1);

        //Assert
        Assert.AreEqual(1393, result);
    }

    [TestMethod]
    [DataRow("1212", 6)]
    [DataRow("1221", 0)]
    [DataRow("123425", 4)]
    [DataRow("123123", 12)]
    [DataRow("12131415", 4)]
    public void Part2Examples(string input, int expected)
    {
        //Act

        var result = Calculations.Perform(input, input.Length / 2);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.Perform(input, input.Length / 2);

        //Assert
        Assert.AreEqual(1292, result);
    }
}