namespace advent_of_code._2024.Day25;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var count = Calculations.CountFittingCombinations(input);

        //Assert
        Assert.AreEqual(3, count);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var count = Calculations.CountFittingCombinations(input);

        //Assert
        Console.WriteLine($"Unique Combinations: {count}");
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange

        //Act
        throw new NotImplementedException();

        //Assert

    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange

        //Act
        throw new NotImplementedException();

        //Assert

    }
}