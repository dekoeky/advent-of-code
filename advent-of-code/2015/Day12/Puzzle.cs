namespace advent_of_code._2015.Day12;

[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("[1,2,3]", 6)]
    [DataRow("{\"a\":2,\"b\":4}", 6)]
    [DataRow("[[[3]]]", 3)]
    [DataRow("{\"a\":{\"b\":4},\"c\":-1}", 3)]
    [DataRow("{\"a\":[-1,1]}", 0)]
    [DataRow("[-1,{\"a\":1}]", 0)]
    [DataRow("[]", 0)]
    [DataRow("{}", 0)]
    public void Part1Examples(string input, int expectedSum)
    {
        //Act
        var result = Calculations.JsonSum(input, false);

        //Assert
        Assert.AreEqual(expectedSum, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.JsonSum(input, false);

        //Assert
        Assert.AreEqual(119433, result);
    }

    [TestMethod]
    [DataRow("[1,2,3]", 6)]
    [DataRow("[1,{\"c\":\"red\",\"b\":2},3]", 4)]
    [DataRow("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}", 0)]
    [DataRow("[1,\"red\",5]", 6)]
    public void Part2Examples(string input, int expectedSum)
    {
        //Act
        var result = Calculations.JsonSum(input, true);

        //Assert
        Assert.AreEqual(expectedSum, result);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = Inputs.Puzzle;

        //Act
        var result = Calculations.JsonSum(input, true);

        //Assert
        Assert.AreEqual(68466, result);
    }
}