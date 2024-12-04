namespace advent_of_code._2024.Day01;

[TestClass]
public class Puzzle1Tests
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        var input = Inputs.Example;
        InputParsing.ParseInput(input, out var list1, out var list2);

        //Act
        var result = Calculations.CalculateTotalDistance(list1, list2);

        //Assert
        Assert.AreEqual(11, result);
    }

    [TestMethod]
    public void ActualPuzzle()
    {
        //Arrange
        var input = Inputs.Puzzle1;
        InputParsing.ParseInput(input, out var list1, out var list2);

        //Act
        var result = Calculations.CalculateTotalDistance(list1, list2);

        //Assert
        Console.WriteLine($"Total Distance: {result}");
    }
}
