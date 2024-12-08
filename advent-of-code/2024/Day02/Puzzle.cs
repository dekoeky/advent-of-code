namespace advent_of_code._2024.Day02;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example1()
    {
        //Arrange
        var input = UnusualData.Parse(Input.Example);

        //Act
        var numberOfReportsSafe = input.Reports.Count(Calculations.IsSafe);

        //Assert
        Assert.AreEqual(2, numberOfReportsSafe);
    }

    [TestMethod]
    public void Puzzle1()
    {
        //Arrange
        var input = UnusualData.Parse(Input.Puzzle);

        //Act
        var numberOfReportsSafe = input.Reports.Count(Calculations.IsSafe);

        //Assert
        Console.WriteLine($"{numberOfReportsSafe} reports are safe");
    }

    [TestMethod]
    public void Example2()
    {
        //Arrange
        var input = UnusualData.Parse(Input.Example);

        //Act
        var reportsSafe = input.Reports.ToDictionary(r => r.ToString()!, Calculations.IsSafeOneLevelForgiving);
        var numberOfReportsSafe = reportsSafe.Count(kv => kv.Value);

        foreach (var item in reportsSafe)
        {
            Console.WriteLine($"{item.Key}: {(item.Value ? "Safe" : "Unsafe")}");
        }

        //Assert
        Assert.AreEqual(4, numberOfReportsSafe);
    }

    [TestMethod]
    public void Puzzle2()
    {
        //Arrange
        var input = UnusualData.Parse(Input.Puzzle);

        //Act
        var numberOfReportsSafe = input.Reports.Count(Calculations.IsSafeOneLevelForgiving);

        //Assert
        Console.WriteLine(numberOfReportsSafe);
    }
}
