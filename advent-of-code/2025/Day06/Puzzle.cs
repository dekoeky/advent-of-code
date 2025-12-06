namespace advent_of_code._2025.Day06;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.SumOfOperations(input);

        //Assert
        Assert.AreEqual(4277556, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.SumOfOperations(input);

        //Assert
        Console.WriteLine($"Result: {result}");
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.SumOfOperations2(input);

        //Assert
        Assert.AreEqual(3263827, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.SumOfOperations2(input);

        //Assert
        Console.WriteLine($"Result: {result}");
    }
}