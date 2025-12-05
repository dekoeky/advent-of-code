namespace advent_of_code._2024.Day24;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.CalculateBinaryZValues(input);

        //Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void LargerExample()
    {
        //Arrange
        var input = Inputs.LargerExample;

        //Act
        var result = Calculations.CalculateBinaryZValues(input);

        //Assert
        Assert.AreEqual(2024, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.CalculateBinaryZValues(input);

        //Assert
        Console.WriteLine($"Result: {result}");
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