namespace advent_of_code._2024.Day08;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var map = String2D.StringTo2DArray(Inputs.Example);

        //Act
        var antiNodePositions = Calculations.UniqueAndValidAntiNodePositions(map, false);

        //Assert
        Assert.AreEqual(14, antiNodePositions.Length);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var map = String2D.StringTo2DArray(Inputs.Puzzle);

        //Act
        var antiNodePositions = Calculations.UniqueAndValidAntiNodePositions(map, false);

        //Assert
        Console.WriteLine(antiNodePositions.Length);
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var map = String2D.StringTo2DArray(Inputs.Example);

        //Act
        var antiNodePositions = Calculations.UniqueAndValidAntiNodePositions(map, true);

        ////Debug:
        //var map2 = map.Duplicate();
        //foreach (var pos in antiNodePositions) map2[pos.Row, pos.Col] = '#';
        //Console.WriteLine(String2D.Array2DToString(map2));


        //Assert
        Assert.AreEqual(34, antiNodePositions.Length);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var map = String2D.StringTo2DArray(Inputs.Puzzle);

        //Act
        var antiNodePositions = Calculations.UniqueAndValidAntiNodePositions(map, true);

        //Assert
        Console.WriteLine(antiNodePositions.Length);
    }
}