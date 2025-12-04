namespace advent_of_code._2025.Day04;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        var accessibleRolls = Calculations.RollsAccessibleByForklift(input);

        //Assert
        Assert.AreEqual(13, accessibleRolls);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var accessibleRolls = Calculations.RollsAccessibleByForklift(input);

        //Assert
        Console.WriteLine($"Accessible Paper Rolls: {accessibleRolls}");
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = Inputs.Example;

        //Act
        throw new NotImplementedException();

        //Assert

    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        throw new NotImplementedException();

        //Assert

    }
}