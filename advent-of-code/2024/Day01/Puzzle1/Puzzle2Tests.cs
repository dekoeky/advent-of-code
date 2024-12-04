namespace advent_of_code._2024._01.Puzzle1;

[TestClass]
public class Puzzle2Tests
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        var input = Inputs.Example;
        InputParsing.ParseInput(input, out var list1, out var list2);

        //Act
        var result = Calculations.CalculateSimilarityScore(list1, list2);

        //Assert
        Assert.AreEqual(31, result);
    }

    [TestMethod]
    public void ActualPuzzle()
    {
        //Arrange
        var input = Inputs.Puzzle2;
        InputParsing.ParseInput(input, out var list1, out var list2);

        //Act
        var result = Calculations.CalculateSimilarityScore(list1, list2);

        //Assert
        Console.WriteLine($"Similarity Score: {result}");
    }
}
