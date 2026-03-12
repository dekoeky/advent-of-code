namespace advent_of_code._2015.Day18;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.LightsOnAfterNSteps(input, 4, false);

        //Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.LightsOnAfterNSteps(input, 100, false);

        //Assert
        Assert.AreEqual(821, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.LightsOnAfterNSteps(input, 5, true);

        //Assert
        Assert.AreEqual(17, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.LightsOnAfterNSteps(input, 100, true);

        //Assert
        Assert.AreEqual(886, result);
    }
}