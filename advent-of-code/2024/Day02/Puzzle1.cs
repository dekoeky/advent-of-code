namespace advent_of_code._2024.Day02;

[TestClass]
public class Puzzle1
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        var input = UnusualData.Parse(Input.Example);

        //Act
        var numberOfReportsSafe = input.Reports.Count(Calculations.IsSafe);

        //Assert
        Assert.AreEqual(2, numberOfReportsSafe);
    }

    [TestMethod]
    public void Puzzle()
    {
        //Arrange
        var input = UnusualData.Parse(Input.Puzzle1);

        //Act
        var numberOfReportsSafe = input.Reports.Count(Calculations.IsSafe);

        //Assert
        Console.WriteLine($"{numberOfReportsSafe} reports are safe");
    }
}
