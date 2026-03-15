namespace advent_of_code._2015.Day21;

[TestClass]
public class Puzzle
{
    private static readonly Shop Shop = Shop.Parse(Inputs.ItemShop);

    [TestMethod]
    public void Part1Puzzle()
    {
        //Arrange
        var player = new Character("player", 100, 0, 0);
        var boss = Character.Parse(Inputs.Puzzle, "boss");

        //Act
        var result = Calculations.CheapestWin(player, boss, Shop);

        //Assert
        Assert.AreEqual(78, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        //Arrange
        var player = new Character("player", 100, 0, 0);
        var boss = Character.Parse(Inputs.Puzzle, "boss");

        //Act
        var result = Calculations.MostExpensiveLoss(player, boss, Shop);

        //Assert
        Assert.AreEqual(148, result);
    }
}
