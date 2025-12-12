namespace advent_of_code._2025.Day10;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var fewestButtonPresses = Calculations.FewestButtonPressesRequired(input);

        //Assert
        Console.WriteLine($"Fewest button presses required to correctly configure the indicator lights on all of the machines: {fewestButtonPresses}");
        Assert.AreEqual(7, fewestButtonPresses);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var fewestButtonPresses = Calculations.FewestButtonPressesRequired(input);

        //Assert
        Console.WriteLine($"Fewest button presses required to correctly configure the indicator lights on all of the machines: {fewestButtonPresses}");
        Assert.AreEqual(494, fewestButtonPresses);
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var result = Calculations.FewestButtonPressesRequired(input);

        //Assert
        Assert.AreEqual(00000000, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.FewestButtonPressesRequired(input);

        //Assert
        Console.WriteLine($"Result: {result}");
    }
}