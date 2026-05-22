namespace advent_of_code._2018.Day09;

/// <summary>
/// Year 2018 Day 09 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2018/day/9"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(9, 25, 32)]
    [DataRow(10, 1618, 8317)]
    [DataRow(13, 7999, 146373)]
    [DataRow(17, 1104, 2764)]
    [DataRow(21, 6111, 54718)]
    [DataRow(30, 5807, 37305)]
    public void Part1Examples(int players, int highestMarble, int expectedScore)
    {
        // Act
        var result = Calculations.Part1(players, highestMarble);

        // Assert
        Assert.AreEqual(expectedScore, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var (players, lastMarbleWorth) = Calculations.ParseInput(Inputs.Puzzle);

        // Act
        var result = Calculations.Part1(players, lastMarbleWorth);

        // Assert
        Assert.AreEqual(390093, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var (players, lastMarbleWorth) = Calculations.ParseInput(Inputs.Puzzle);

        // Act
        var result = Calculations.Part2(players, lastMarbleWorth * 100);

        // Assert
        Assert.AreEqual(3150377341, result);
    }
}