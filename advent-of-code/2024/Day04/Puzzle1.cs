namespace advent_of_code._2024.Day04;

[TestClass]
public class Puzzle1
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        var input = Input.Example;
        var wordToSearch = "XMAS";

        //Act
        var count = Calculations.CountOccurances(input, wordToSearch);

        //Assert
        Assert.AreEqual(18, count);
    }

    [TestMethod]
    public void Puzzle()
    {
        //Arrange
        var input = Input.Puzzle1;
        var wordToSearch = "XMAS";

        //Act
        var count = Calculations.CountOccurances(input, wordToSearch);

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
        var input = Input.Example;

        //Act
        var count = Calculations.CountMasCrossings(input);

        //Assert
        Assert.AreEqual(9, count);
    }

    [TestMethod]
    public void Puzzle()
    {
        //Arrange
        var input = Input.Puzzle1;

        //Act
        var count = Calculations.CountMasCrossings(input);

        //Assert
        Console.WriteLine(count);
    }
}
