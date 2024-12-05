namespace advent_of_code._2024.Day03;

[TestClass]
public class Puzzle1
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        var input = Input.Example;

        //Act
        var count = Calculations.SumOfMultiplications(input);

        //Assert
        Assert.AreEqual(161, count);
    }

    [TestMethod]
    public void Puzzle()
    {
        //Arrange
        var input = Input.Puzzle1;

        //Act
        var count = Calculations.SumOfMultiplications(input);

        //Assert
        Console.WriteLine(count);
    }
}
