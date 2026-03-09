using advent_of_code.Helpers;

namespace advent_of_code._2015.Day05;

[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("ugknbfddgicrmopn", true)]
    [DataRow("aaa", true)]
    [DataRow("jchzalrnumimnmhp", false)]
    [DataRow("haegwjzuvuyypxyu", false)]
    [DataRow("dvszwmarrgswjxmb", false)]
    public void Example1(string input, bool expected)
    {
        //Act
        var isNice = input.IsNice();

        //Assert
        Assert.AreEqual(expected, isNice);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;
        var inputs = SplitOn.NewLines(input);

        //Act
        var result = inputs.Count(i => i.IsNice());

        //Assert
        Assert.AreEqual(258, result);
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = "";

        //Act
        var result = Calculations.Perform(input);

        //Assert
        Assert.AreEqual(00000000, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.Perform(input);

        //Assert
        Console.WriteLine($"Result: {result}");
    }
}