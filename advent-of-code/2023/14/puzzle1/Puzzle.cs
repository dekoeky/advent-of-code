namespace advent_of_code._2023._14.puzzle1;

[TestClass]
public class Puzzle
{
    [DataTestMethod]
    [DataRow("2024/14/puzzle1/input/example-input.txt")]
    [DataRow("2024/14/puzzle1/input/example-shifted.txt")]
    public void ReadAndToString(string file)
    {
        //Arrange
        var expected = File.ReadAllText(file);

        //Act
        var actual = PlatformData.FromFile(file).ToString();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Example()
    {
        //Arrange
        const int expectedLoad = 136;
        const string inputFile = "2024/14/puzzle1/input/example-input.txt";
        const string shiftedFile = "2024/14/puzzle1/input/example-shifted.txt";

        //Act
        var exampleInput = PlatformData.FromFile(inputFile);
        var exampleShifted = PlatformData.FromFile(shiftedFile);
        var shifted = exampleInput.Duplicate(); shifted.Shift(ShiftDirection.N);

        var loadFromShiftedInput = exampleShifted.GetLoad();
        var actualLoad = shifted.GetLoad();

        //Assert
        Assert.AreEqual(expectedLoad, loadFromShiftedInput);
        Assert.AreEqual(expectedLoad, actualLoad);
    }

    [DataTestMethod]
    [DataRow("2024/14/puzzle1/input/input.txt")]
    public void Solve(string inputPath)
    {
        //Arrange
        var input = PlatformData.FromFile(inputPath);

        //Act
        input.Shift(ShiftDirection.N);
        var load = input.GetLoad();

        //Assert
        Console.WriteLine(load);
    }
}