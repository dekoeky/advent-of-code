namespace advent_of_code._2024.Day06;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var map = String2D.StringTo2DArray(Inputs.Example);

        //Act
        var result = Calculations.GetDistinctGuardPositions(map);

        //Assert
        Assert.AreEqual(41, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var map = String2D.StringTo2DArray(Inputs.Puzzle);

        //Act
        var result = Calculations.GetDistinctGuardPositions(map);

        //Assert
        Console.WriteLine(result);
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