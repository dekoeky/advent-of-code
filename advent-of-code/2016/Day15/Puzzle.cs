namespace advent_of_code._2016.Day15;

/// <summary>
/// Year 2016 Day 15 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/15"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var disks = Disks.Parse(Inputs.Example);

        // Act
        var result = Calculations.FindEarliestStartTime(disks);

        // Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var disks = Disks.Parse(Inputs.Puzzle);

        // Act
        var result = Calculations.FindEarliestStartTime(disks);

        // Assert
        Assert.AreEqual(16824, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var disks = Disks.Parse(Inputs.Puzzle);
        disks.Add(new DiskInput(11, 0));

        // Act
        var result = Calculations.FindEarliestStartTime(disks);

        // Assert
        Assert.AreEqual(3543984, result);
    }
}