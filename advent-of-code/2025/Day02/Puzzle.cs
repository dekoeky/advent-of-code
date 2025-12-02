namespace advent_of_code._2025.Day02;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var sum = Calculations.SumOfInvalidIds(input);

        //Assert
        Console.WriteLine($"Sum of invalid ids is : {sum}");
        Assert.AreEqual(1227775554, sum);
    }


    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var sum = Calculations.SumOfInvalidIds(input);

        //Assert
        Console.WriteLine($"Sum of invalid ids is : {sum}");
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange

        //Act

        //Assert

    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange

        //Act

        //Assert

    }
}