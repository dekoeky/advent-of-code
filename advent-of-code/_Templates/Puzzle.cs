namespace advent_of_code._Templates;

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
        Assert.AreEqual(00000000, result);
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
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.Perform(input);

        //Assert
        Assert.AreEqual(00000000, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.Perform(input);

        //Assert
        Console.WriteLine($"Result: {result}");
    }
}