namespace advent_of_code._2023.Day06;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        //Arrange
        var input = Input.Parse(Inputs.Example);

        //Act
        var result = input.PossibilitiesMultiplied();

        //Assert
        Assert.AreEqual(288uL, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        //Arrange
        var input = Input.Parse(Inputs.Puzzle);

        //Act
        var result = input.PossibilitiesMultiplied();

        //Assert
        Assert.AreEqual(1731600uL, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        //Arrange
        var input = InputWithBadKerning.Parse(Inputs.Example);

        //Act
        var result = input.PossibilitiesMultiplied();

        //Assert
        Assert.AreEqual(71503uL, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        //Arrange
        var input = InputWithBadKerning.Parse(Inputs.Puzzle);

        //Act
        var result = input.PossibilitiesMultiplied();

        //Assert
        Assert.AreEqual(40087680uL, result);
    }
}