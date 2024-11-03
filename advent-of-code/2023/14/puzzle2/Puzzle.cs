namespace advent_of_code._2024._14.puzzle2;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example()
    {
        //Arrange
        const int expectedLoad = 64;
        const int cycles = 1000000000;
        const string inputFile = "2024/14/puzzle1/input/example-input.txt";
        const string cycled1File = "2024/14/puzzle2/input/after-cycle-1.txt";
        const string cycled2File = "2024/14/puzzle2/input/after-cycle-2.txt";
        const string cycled3File = "2024/14/puzzle2/input/after-cycle-3.txt";
        var workData = PlatformData.FromFile(inputFile);
        var exampleCycled1 = PlatformData.FromFile(cycled1File);
        var exampleCycled2 = PlatformData.FromFile(cycled2File);
        var exampleCycled3 = PlatformData.FromFile(cycled3File);

        //Act
        workData.Cycle();
        var cycled1 = workData.Duplicate();
        workData.Cycle();
        var cycled2 = workData.Duplicate();
        workData.Cycle();
        var cycled3 = workData.Duplicate();

        workData.Cycle(cycles - 3);
        var actualLoad = workData.GetLoad();

        //Assert
        Assert.AreEqual(exampleCycled1.ToString(), cycled1.ToString());
        Assert.AreEqual(exampleCycled2.ToString(), cycled2.ToString());
        Assert.AreEqual(exampleCycled3.ToString(), cycled3.ToString());
        Assert.AreEqual(expectedLoad, actualLoad);
    }

    [DataTestMethod]
    [DataRow("2024/14/puzzle1/input/input.txt", 1000000000)]
    public void Solve(string inputPath, int cycles)
    {
        //Arrange
        var data = PlatformData.FromFile(inputPath);

        //Act
        data.Cycle(cycles);
        var load = data.GetLoad();

        //Assert
        Console.WriteLine(load);
    }
}