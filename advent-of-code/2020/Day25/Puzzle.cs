namespace advent_of_code._2020.Day25;

/// <summary>
/// Year 2020 Day 25 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/25"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var cardPublicKey = 5764801;
        var doorPublicKey = 17807724;

        // Act
        var result = Calculations.Part1(cardPublicKey, doorPublicKey);

        // Assert
        Assert.AreEqual(14897079, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var cardPublicKey = 10212254;
        var doorPublicKey = 12577395;

        // Act
        var result = Calculations.Part1(cardPublicKey, doorPublicKey);

        // Assert
        Assert.AreEqual(290487, result);
    }
}