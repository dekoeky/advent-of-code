namespace advent_of_code._2025.Day04;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = Inputs.Example;
        var remove = false;

        //Act
        var accessibleRolls = Calculations.RollsAccessibleByForklift(input, remove);

        //Assert
        Assert.AreEqual(13, accessibleRolls);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Inputs.Puzzle;
        var remove = false;

        //Act
        var accessibleRolls = Calculations.RollsAccessibleByForklift(input, remove);

        //Assert
        Console.WriteLine($"Accessible Paper Rolls: {accessibleRolls}");
        Assert.AreEqual(1363, accessibleRolls);
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = Inputs.Example;
        var remove = true;

        //Act
        var accessibleRolls = Calculations.RollsAccessibleByForklift(input, remove);

        //Assert
        Assert.AreEqual(43, accessibleRolls);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;
        var remove = true;

        //Act
        var accessibleRolls = Calculations.RollsAccessibleByForklift(input, remove);

        //Assert
        Console.WriteLine($"Accessible Paper Rolls: {accessibleRolls}");
        Assert.AreEqual(8184, accessibleRolls);
    }
}