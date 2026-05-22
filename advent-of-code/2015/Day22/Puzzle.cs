namespace advent_of_code._2015.Day22;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Puzzle()
    {
        // Act
        var result = Solver.FindLeastManaToWin(bossHp: 71, bossDamage: 10, hardMode: false);

        // Assert
        Assert.AreEqual(1824, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Act
        var result = Solver.FindLeastManaToWin(bossHp: 71, bossDamage: 10, hardMode: true);

        // Assert

        Assert.AreEqual(1937, result);
    }
}
