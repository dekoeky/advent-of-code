namespace advent_of_code._2015.Day01;

/// <summary>
/// Solves puzzle <see href="https://adventofcode.com/2015/day/1"/>
/// </summary>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(0, "(())")]
    [DataRow(0, "()()")]
    [DataRow(3, "(((")]
    [DataRow(3, "(()(()(")]
    [DataRow(3, "))(((((")]
    [DataRow(-1, "())")]
    [DataRow(-1, "))(")]
    [DataRow(-3, ")))")]
    [DataRow(-3, ")())())")]
    public void Part1Examples(int expectedFloor, string instructions)
    {
        //Act
        var result = Calculations.FinalFloor(instructions);

        //Assert
        Assert.AreEqual(expectedFloor, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.FinalFloor(input);

        //Assert
        Assert.AreEqual(138, result);
    }

    [TestMethod]
    [DataRow(1, ")")]
    [DataRow(5, "()())")]
    public void Part2Examples(int expectedPosition, string instructions)
    {
        //Act
        var result = Calculations.BasementEnteredInStep(instructions);

        //Assert
        Assert.AreEqual(expectedPosition, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.BasementEnteredInStep(input);

        //Assert
        Assert.AreEqual(1771, result);
    }
}