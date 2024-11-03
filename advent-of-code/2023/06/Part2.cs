namespace advent_of_code._2023._06;

[TestClass]
public class Part2
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        var input = InputWithBadKerning.FromFile("2024/06/input/example.txt");

        //Act
        var result = input.PossibilitiesMultiplied();

        //Assert
        Assert.AreEqual(71503ul, result);
    }

    [TestMethod]
    public void Puzzle()
    {
        //Arrange
        var input = InputWithBadKerning.FromFile("2024/06/input/input2.txt");

        //Act
        var result = input.PossibilitiesMultiplied();

        //Assert
        Console.WriteLine(result);
    }
}