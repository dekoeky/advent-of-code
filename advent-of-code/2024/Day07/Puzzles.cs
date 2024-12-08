namespace advent_of_code._2024.Day07;


[TestClass]
public class Puzzles
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        var input = PuzzleInput.Parse(Inputs.Example);

        //Act
        var possibleEquations = input.Equations.Where(Calculations.IsPossible);
        var sum = possibleEquations.Sum(e => e.TestValue);

        //Assert
        Assert.AreEqual(3749, sum);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = PuzzleInput.Parse(Inputs.Puzzle1);

        //Act
        var possibleEquations = input.Equations.Where(Calculations.IsPossible);
        var sum = possibleEquations.Sum(e => e.TestValue);

        //Assert
        Console.WriteLine(sum);
    }
}