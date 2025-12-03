namespace advent_of_code._2025.Day03;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var sum = Calculations.CalculateJoltageSum(input);

        //Assert
        Assert.AreEqual(357, sum);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var sum = Calculations.CalculateJoltageSum(input);

        //Assert
        Console.WriteLine($"Sum of Max Joltages: {sum}");
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = Inputs.Example;
        var numberOfBatteries = 12;

        //Act
        var sum = Calculations.CalculateJoltageSum2(input, numberOfBatteries);

        //Assert
        Assert.AreEqual(3121910778619, sum);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;
        var numberOfBatteries = 12;

        //Act
        var sum = Calculations.CalculateJoltageSum2(input, numberOfBatteries);

        //Assert
        Console.WriteLine($"Sum of Max Joltages: {sum}");
    }
}