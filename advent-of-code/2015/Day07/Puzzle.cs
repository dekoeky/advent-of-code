namespace advent_of_code._2015.Day07;


[TestClass]
public class Puzzle
{
    private const ushort expectedResultPart1 = 16076;
    private const ushort expectedResultPart2 = 2797;

    [TestMethod]
    public void Puzzle1()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var circuit = Circuit.Parse(input);
        var result = circuit.GetOrCalculate("a");

        // Assert
        Assert.AreEqual(expectedResultPart1, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var circuit = Circuit.Parse(input);
        circuit.Instructions["b"] = new SimpleOperation(Op.ASSIGN, expectedResultPart1.ToString(), null!);
        var result = circuit.GetOrCalculate("a");

        // Assert
        Assert.AreEqual(expectedResultPart2, result);
    }
}