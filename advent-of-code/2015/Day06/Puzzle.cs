namespace AdventOfCode._2015.Day06;

[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("turn on 0,0 through 999,999", Command.TurnOn, 0, 0, 999, 999)]
    [DataRow("toggle 0,0 through 999,0", Command.Toggle, 0, 0, 999, 0)]
    [DataRow("turn off 499,499 through 500,500", Command.TurnOff, 499, 499, 500, 500)]
    public void Part1Examples(string input, Command expectedCommand, int eX1, int eY1, int eX2, int eY2)
    {
        // Act
        var instruction = Instruction.Parse(input);

        // Assert
        Assert.AreEqual(expectedCommand, instruction.Command);
        Assert.AreEqual(eX1, instruction.X1);
        Assert.AreEqual(eY1, instruction.Y1);
        Assert.AreEqual(eX2, instruction.X2);
        Assert.AreEqual(eY2, instruction.Y2);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var lightsOn = Calculations.Perform(input);

        // Assert
        Assert.AreEqual(569999, lightsOn);
    }

    [TestMethod]
    public void Puzzle2()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Perform2(input);

        // Assert
        Assert.AreEqual(17836115, result);
    }
}