namespace advent_of_code._2015.Day16;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Puzzle()
    {
        //Arrange
        var sues = Inputs.PuzzleInput;
        var tickerTape = Inputs.TickerTape;

        //Act
        var result = Calculations.Perform1(sues, tickerTape);

        //Assert
        Assert.AreEqual(40, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        //Arrange
        var sues = Inputs.PuzzleInput;
        var tickerTape = Inputs.TickerTape;

        //Act
        var result = Calculations.Perform2(sues, tickerTape);

        //Assert
        Assert.AreEqual(241, result);
    }
}
