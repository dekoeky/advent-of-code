namespace advent_of_code._2016.Day14;

/// <summary>
/// Year 2016 Day 14 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/14"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        const string salt = "abc";
        const int n = 64;

        // Act
        var result = Calculations.Part1(salt, n);

        // Assert
        Assert.AreEqual(22728, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        const string salt = "ngcjuoqr";
        int n = 64;

        // Act
        var result = Calculations.Part1(salt, n);

        // Assert
        Assert.AreEqual(18626, result);
    }

    //[TestMethod]
    //public void Part2Puzzle()
    //{
    //    // Arrange
    //    var fav = 1350;
    //    var maxSteps = 50;

    //    // Act
    //    var result = Calculations.Part2(fav, maxSteps);

    //    // Assert
    //    Assert.AreEqual(124, result);
    //}
}