namespace advent_of_code._2024.Day07;


[TestClass]
public class Puzzles
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        Calculations.Operators = ["+", "*"];
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
        Calculations.Operators = ["+", "*"];
        var input = PuzzleInput.Parse(Inputs.Puzzle);

        //Act
        var possibleEquations = input.Equations.Where(Calculations.IsPossible);
        var sum = possibleEquations.Sum(e => e.TestValue);

        //Assert
        Console.WriteLine(sum);
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        Calculations.Operators = ["+", "*", "||"];
        var input = PuzzleInput.Parse(Inputs.Example);

        //Act
        var possibleEquations = input.Equations.Where(Calculations.IsPossible);
        var sum = possibleEquations.Sum(e => e.TestValue);

        //Assert
        Assert.AreEqual(11387, sum);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        Calculations.Operators = ["+", "*", "||"];
        var input = PuzzleInput.Parse(Inputs.Puzzle);

        //Act
        var possibleEquations = input.Equations.Where(Calculations.IsPossible);
        var sum = possibleEquations.Sum(e => e.TestValue);

        //Assert
        Console.WriteLine(sum);
    }
}