namespace AdventOfCode._2016.Day04;

/// <summary>
/// Year 2016 Day 04 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/4"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("aaaaa-bbb-z-y-x-123[abxyz]", true)]
    [DataRow("a-b-c-d-e-f-g-h-987[abcde]", true)]
    [DataRow("not-a-real-room-404[oarel]", true)]
    [DataRow("totally-real-room-200[decoy]", false)]
    public void Part1Examples(string input, bool expectedReal)
    {
        // Arrange
        var data = RoomDefinition.Parse(input);

        // Act
        var result = data.IsReal();

        // Assert
        Assert.AreEqual(expectedReal, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var rooms = SplitOn.NewLines(input).Select(RoomDefinition.Parse);

        // Act
        var result = rooms.Where(r => r.IsReal()).Sum(r => r.SectorId);

        // Assert
        Assert.AreEqual(409147, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var rooms = SplitOn.NewLines(input).Select(RoomDefinition.Parse);

        // Act
        var result = rooms.FirstOrDefault(r => r.DecryptRoomName() == "northpole object storage");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(991, result.SectorId);
    }
}