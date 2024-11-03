namespace advent_of_code._2023._06;

[TestClass]
public class Part1
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        var input = Input.FromFile("2024/06/input/example.txt");

        //Act
        var result = input.PossibilitiesMultiplied();

        //Assert
        Assert.AreEqual(288ul, result);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = Input.FromFile("2024/06/input/input1.txt");

        //Act
        var result = input.PossibilitiesMultiplied();

        //Assert
        Console.WriteLine(result);
    }


}