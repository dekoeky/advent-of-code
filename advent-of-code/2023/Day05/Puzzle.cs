namespace advent_of_code._2023.Day05;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.Perform(input);

        //Assert
        Assert.AreEqual(35, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.Perform(input);

        //Assert
        Assert.AreEqual(525792406, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.Perform(input);

        //Assert
        Assert.AreEqual(00000000, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.Perform(input);

        //Assert
        Assert.AreEqual(00000000, result);
    }
}
