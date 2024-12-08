namespace advent_of_code._2024.Day08;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        var map = String2D.StringTo2DArray(Inputs.Example);

        //Act
        var antiNodePositions = Calculations.UniqueAndValidAntiNodePositions(map);

        //Assert
        Assert.AreEqual(14, antiNodePositions.Length);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var map = String2D.StringTo2DArray(Inputs.Puzzle);

        //Act
        var antiNodePositions = Calculations.UniqueAndValidAntiNodePositions(map);

        //Assert
        Console.WriteLine(antiNodePositions.Length);
    }
}