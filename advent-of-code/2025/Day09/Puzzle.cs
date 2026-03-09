namespace advent_of_code._2025.Day09;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.Perform(input);

        //Assert
        Assert.AreEqual(50, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.Perform(input);

        //Assert
        Assert.AreEqual(4767418746, result);
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.Perform3(input);

        //Assert
        Assert.AreEqual(24, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        throw new NotImplementedException("dead end");
        var result = Calculations.Perform3(input);

        //Assert
        Assert.IsLessThan(2147380284, result);
        Console.WriteLine($"Result: {result}");
    }
}