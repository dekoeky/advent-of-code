namespace advent_of_code._2025.Day01;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var zeros = Calculations.CountZeroes(input);

        //Assert
        Console.WriteLine($"Times the dial ended on '0': {zeros}");
        Assert.AreEqual(3, zeros);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var zeros = Calculations.CountZeroes(input);

        //Assert
        Console.WriteLine($"Times the dial ended on '0': {zeros}");
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var zeros = Calculations.CountZeroesV2(input);

        //Assert
        Console.WriteLine($"Times the dial passed '0': {zeros}");
        Assert.AreEqual(6, zeros);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var zeros = Calculations.CountZeroesV2(input);

        //Assert
        Console.WriteLine($"Times the dial passed '0': {zeros}");
    }
}