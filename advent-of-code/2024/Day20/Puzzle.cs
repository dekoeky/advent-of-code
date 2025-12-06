namespace advent_of_code._2024.Day20;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.CountNumberOfShortcutsSavingAtLeast100PicoSeconds(input);

        //Assert
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.CountNumberOfShortcutsSavingAtLeast100PicoSeconds(input);

        //Assert
        Console.WriteLine($"Result: {result}");
        Assert.Equals(1381, result);
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.CountNumberOfShortcutsSavingAtLeast100PicoSeconds(input);

        //Assert
        Assert.AreEqual(00000000, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.CountNumberOfShortcutsSavingAtLeast100PicoSeconds(input);

        //Assert
        Console.WriteLine($"Result: {result}");
    }
}