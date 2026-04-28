namespace advent_of_code._2020.Day05;

/// <summary>
/// Year 2020 Day 05 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2020/day/5"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("FBFBBFF", 44)]
    public void ParseRow(string input, int expected)
    {
        // Act
        var seatNumber = Seat.ParseRow(input);

        // Arrange
        Assert.AreEqual(expected, seatNumber);
    }

    [TestMethod]
    [DataRow("RLR", 5)]
    public void ParseColumn(string input, int expected)
    {
        // Act
        var seatNumber = Seat.ParseColumn(input);

        // Arrange
        Assert.AreEqual(expected, seatNumber);
    }

    [TestMethod]
    [DataRow("FBFBBFFRLR", 357)]
    [DataRow("BFFFBBFRRR", 567)]
    [DataRow("FFFBBBFRRR", 119)]
    [DataRow("BBFFBBFRLL", 820)]
    public void SeatId(string input, int expected)
    {
        // Act
        var seatNumber = Seat.ParseId(input);

        // Arrange
        Assert.AreEqual(expected, seatNumber);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(842, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(617, result);
    }
}