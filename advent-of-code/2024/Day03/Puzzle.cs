namespace advent_of_code._2024.Day03;

[TestClass]
public class Puzzle1
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        var input = Input.Example1;

        //Act
        var count = Calculations.SumOfMultiplications(input, false);

        //Assert
        Assert.AreEqual(161, count);
    }

    [TestMethod]
    public void Puzzle()
    {
        //Arrange
        var input = Input.Puzzle1;

        //Act
        var count = Calculations.SumOfMultiplications(input, false);

        //Assert
        Console.WriteLine(count);
    }
}

[TestClass]
public class Puzzle2
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        var input = Input.Example2;

        //Act
        var count = Calculations.SumOfMultiplications(input, true);

        //Assert
        Assert.AreEqual(48, count);
    }

    [TestMethod]
    public void Puzzle()
    {
        //Arrange
        var input = Input.Puzzle2;

        //Act
        var count = Calculations.SumOfMultiplications(input, true);

        //Assert
        Console.WriteLine(count);
    }
}
