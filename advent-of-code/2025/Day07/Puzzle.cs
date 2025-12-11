namespace advent_of_code._2025.Day07;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var beamSplits = Calculations.CountBeamSplits(input);

        //Assert
        Console.WriteLine($"Beam Splits: {beamSplits}");
        Assert.AreEqual(21, beamSplits);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var beamSplits = Calculations.CountBeamSplits(input);

        //Assert
        Console.WriteLine($"Beam Splits: {beamSplits}");
        Assert.AreEqual(1570, beamSplits);
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.CountPaths(input);

        //Assert
        Assert.AreEqual(40, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.CountPaths(input);

        //Assert
        Console.WriteLine($"Result: {result}");
        Assert.AreEqual(15118009521693, result);
    }
}