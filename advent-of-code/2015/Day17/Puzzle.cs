namespace advent_of_code._2015.Day17;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Puzzle1()
    {
        // Arrange
        var input = Inputs.Puzzle;
        int totalLiters = 150;

        // Act
        var containerSizes = SplitOn.NewLines(input).Select(int.Parse).ToArray();
        var result = ContainerCombinations.SolvePart1(totalLiters, containerSizes);

        // Assert
        Assert.AreEqual(654, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        // Arrange
        var input = Inputs.Puzzle;
        int totalLiters = 150;

        // Act
        var containerSizes = SplitOn.NewLines(input).Select(int.Parse).ToArray();
        var result = ContainerCombinations.SolvePart2(totalLiters, containerSizes);

        // Assert
        Assert.AreEqual(57, result);
    }
}