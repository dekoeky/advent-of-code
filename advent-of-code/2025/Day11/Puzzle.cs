namespace advent_of_code._2025.Day11;

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
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.Perform(input);

        //Assert
        Console.WriteLine($"Result: {result}");
        Assert.AreEqual(423, result);
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.Perform2(input);

        //Assert
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.Perform2(input);

        //Assert
        Console.WriteLine($"Result: {result}");
    }
}